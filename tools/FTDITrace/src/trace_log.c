#include "../include/ftditrace.h"
#include <windows.h>

#define EVENT_QUEUE_SIZE 4096

static ft_log_event_t g_queue[EVENT_QUEUE_SIZE];
static volatile uint64_t g_head = 0;
static volatile uint64_t g_tail = 0;
static volatile uint64_t g_dropped = 0;
static volatile uint64_t g_total_logged = 0;
static volatile bool g_shutdown = false;

static HANDLE g_log_thread = NULL;
static HANDLE g_log_event = NULL;

static LARGE_INTEGER g_qpf;
static uint32_t g_qpf_ms = 1;
static uint64_t g_session_start_qpc = 0;

static HANDLE g_hFileText = INVALID_HANDLE_VALUE;
static HANDLE g_hFileJson = INVALID_HANDLE_VALUE;
static CRITICAL_SECTION g_queue_lock;

uint64_t ftditrace_qpc(void) {
    LARGE_INTEGER li;
    QueryPerformanceCounter(&li);
    return (uint64_t)li.QuadPart;
}

uint64_t ftditrace_qpf(void) {
    return (uint64_t)g_qpf.QuadPart;
}

uint32_t ftditrace_qpc_to_ms(uint64_t delta) {
    return (uint32_t)delta / g_qpf_ms;
}

static const char* event_names[] = {
    "FT_CreateDeviceInfoList", "FT_ListDevices", "FT_Open", "FT_OpenEx", "FT_Close",
    "FT_Read", "FT_Write", "FT_SetBaudRate", "FT_SetDataCharacteristics", "FT_SetFlowControl",
    "FT_SetDtr", "FT_ClrDtr", "FT_SetRts", "FT_ClrRts", "FT_Purge", "FT_SetTimeouts",
    "FT_SetBreakOn", "FT_SetBreakOff", "FT_GetStatus", "FT_SetEventNotification",
    "FT_SetLatencyTimer", "FT_SetUSBParameters", "META_INFO", "DROPPED_EVENTS"
};

static const char hex_digits[] = "0123456789ABCDEF";

static int byte_to_dec(uint8_t val, char* out) {
    if (val >= 100) {
        out[0] = (char)('0' + (val / 100));
        out[1] = (char)('0' + ((val / 10) % 10));
        out[2] = (char)('0' + (val % 10));
        return 3;
    } else if (val >= 10) {
        out[0] = (char)('0' + (val / 10));
        out[1] = (char)('0' + (val % 10));
        return 2;
    } else {
        out[0] = (char)('0' + val);
        return 1;
    }
}

static void append_json_escaped(char* dest, int* offset, int max_len, const char* src) {
    if (!src) return;
    int n = *offset;
    for (int i = 0; src[i] && n < max_len - 2; i++) {
        if (src[i] == '\\') {
            dest[n++] = '\\';
            dest[n++] = '\\';
        } else if (src[i] == '"') {
            dest[n++] = '\\';
            dest[n++] = '"';
        } else {
            dest[n++] = src[i];
        }
    }
    *offset = n;
}

static void write_event(const ft_log_event_t* ev) {
    if (!ev) return;
    int ev_idx = (int)ev->ev_type;
    if (ev_idx < 0 || ev_idx >= (int)(sizeof(event_names) / sizeof(event_names[0]))) {
        return;
    }

    char buf[4096];
    DWORD w = 0;
    
    uint32_t elapsed_ms = ftditrace_qpc_to_ms(ev->ts_exit - ev->ts_entry);
    uint32_t rel_time = ftditrace_qpc_to_ms(ev->ts_entry - g_session_start_qpc);
    
    unsigned long entry_hi = (unsigned long)(ev->ts_entry >> 32);
    unsigned long entry_lo = (unsigned long)(ev->ts_entry & 0xFFFFFFFF);
    unsigned long exit_hi = (unsigned long)(ev->ts_exit >> 32);
    unsigned long exit_lo = (unsigned long)(ev->ts_exit & 0xFFFFFFFF);

    if (g_hFileText != INVALID_HANDLE_VALUE) {
        int n = wsprintfA(buf, "[%08lu] [T:%04X] (+%lu ms) %s (dur:%lu ms) qpc_in=%08lX%08lX qpc_out=%08lX%08lX st=%lu h=%08lX a=[%lu,%lu,%lu] b=%u/%u orig=%u trunc=%d",
                (unsigned long)ev->seq, ev->thread_id, (unsigned long)rel_time, event_names[ev_idx], (unsigned long)elapsed_ms,
                entry_hi, entry_lo, exit_hi, exit_lo,
                ev->status, (unsigned long)(ULONG_PTR)ev->handle, ev->arg1, ev->arg2, ev->arg3,
                ev->act_bytes, ev->req_bytes, ev->original_data_len, ev->truncated ? 1 : 0);
        if (ev->data_len > 0 && n > 0 && n < 3000) {
            buf[n++] = ' '; buf[n++] = 'D'; buf[n++] = ':'; buf[n++] = ' ';
            for (uint32_t i = 0; i < ev->data_len && n < 3800; i++) {
                uint8_t byte = ev->data[i];
                buf[n++] = hex_digits[(byte >> 4) & 0xF];
                buf[n++] = hex_digits[byte & 0xF];
                buf[n++] = ' ';
            }
        }
        if (n > 0 && n < 4094) {
            buf[n++] = '\r';
            buf[n++] = '\n';
            buf[n] = 0;
            WriteFile(g_hFileText, buf, n, &w, NULL);
        }
    }
    
    if (g_hFileJson != INVALID_HANDLE_VALUE) {
        int n = wsprintfA(buf, "{\"seq\":%lu,\"event\":\"%s\",\"tid\":%lu,\"qpc_entry\":\"%08lX%08lX\",\"qpc_exit\":\"%08lX%08lX\",\"rel_ms\":%lu,\"dur_ms\":%lu,\"status\":%lu,\"handle\":\"%08lX\",\"arg1\":%lu,\"arg2\":%lu,\"arg3\":%lu,\"req_bytes\":%lu,\"act_bytes\":%lu,\"original_data_len\":%lu,\"data_len\":%lu,\"truncated\":%s,\"data\":[",
                (unsigned long)ev->seq, event_names[ev_idx], ev->thread_id,
                entry_hi, entry_lo, exit_hi, exit_lo,
                (unsigned long)rel_time, (unsigned long)elapsed_ms,
                ev->status, (unsigned long)(ULONG_PTR)ev->handle, ev->arg1, ev->arg2, ev->arg3,
                ev->req_bytes, ev->act_bytes, ev->original_data_len, ev->data_len,
                ev->truncated ? "true" : "false");
                
        if (n > 0 && n < 2000) {
            for (uint32_t i = 0; i < ev->data_len && n < 3800; i++) {
                if (i > 0) buf[n++] = ',';
                n += byte_to_dec(ev->data[i], buf + n);
            }
            buf[n++] = ']';
            buf[n++] = '}';
            buf[n++] = '\n';
            WriteFile(g_hFileJson, buf, n, &w, NULL);
        }
    }
    g_total_logged++;
}

static DWORD WINAPI log_worker_thread(LPVOID param) {
    (void)param;
    while (!g_shutdown || g_tail < g_head) {
        if (g_tail == g_head) {
            if (g_shutdown) break;
            WaitForSingleObject(g_log_event, 50);
            continue;
        }
        ft_log_event_t ev;
        bool has_event = false;
        EnterCriticalSection(&g_queue_lock);
        if (g_tail < g_head) {
            ev = g_queue[g_tail % EVENT_QUEUE_SIZE];
            g_tail++;
            has_event = true;
        }
        LeaveCriticalSection(&g_queue_lock);
        if (has_event) {
            write_event(&ev);
        }
    }
    return 0;
}

void ftditrace_log_init(void) {
    QueryPerformanceFrequency(&g_qpf);
    g_qpf_ms = (uint32_t)g_qpf.QuadPart / 1000;
    if (g_qpf_ms == 0) g_qpf_ms = 1;
    InitializeCriticalSection(&g_queue_lock);
    
    char log_dir[MAX_PATH] = {0};
    if (GetEnvironmentVariableA("FTDITRACE_LOG_DIR", log_dir, MAX_PATH) == 0) {
        char dll_path[MAX_PATH] = {0};
        HMODULE hm = NULL;
        if (GetModuleHandleExA(GET_MODULE_HANDLE_EX_FLAG_FROM_ADDRESS | GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT, (LPCSTR)&ftditrace_log_init, &hm)) {
            GetModuleFileNameA(hm, dll_path, MAX_PATH);
            char* last_slash = NULL;
            int i = 0;
            while (dll_path[i]) {
                if (dll_path[i] == '\\' || dll_path[i] == '/') last_slash = &dll_path[i];
                i++;
            }
            if (last_slash) *last_slash = '\0';
            wsprintfA(log_dir, "%s\\FTDITrace-Logs", dll_path);
        } else {
            wsprintfA(log_dir, "FTDITrace-Logs");
        }
    }
    CreateDirectoryA(log_dir, NULL);
    
    DWORD pid = GetCurrentProcessId();
    SYSTEMTIME st;
    GetSystemTime(&st);
    
    char path_log[MAX_PATH];
    char path_json[MAX_PATH];
    wsprintfA(path_log, "%s\\%04d%02d%02d_%02d%02d%02d_pid%lu_ftditrace.log", log_dir, st.wYear, st.wMonth, st.wDay, st.wHour, st.wMinute, st.wSecond, pid);
    wsprintfA(path_json, "%s\\%04d%02d%02d_%02d%02d%02d_pid%lu_ftditrace.jsonl", log_dir, st.wYear, st.wMonth, st.wDay, st.wHour, st.wMinute, st.wSecond, pid);
    
    g_hFileText = CreateFileA(path_log, GENERIC_WRITE, FILE_SHARE_READ, NULL, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, NULL);
    g_hFileJson = CreateFileA(path_json, GENERIC_WRITE, FILE_SHARE_READ, NULL, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, NULL);
    
    g_session_start_qpc = ftditrace_qpc();
    
    unsigned long qpf_hi = (unsigned long)(g_qpf.QuadPart >> 32);
    unsigned long qpf_lo = (unsigned long)(g_qpf.QuadPart & 0xFFFFFFFF);
    unsigned long start_hi = (unsigned long)(g_session_start_qpc >> 32);
    unsigned long start_lo = (unsigned long)(g_session_start_qpc & 0xFFFFFFFF);

    char buf[2048];
    DWORD w = 0;
    
    const char* real_path = ftditrace_get_real_dll_path();
    const char* proxy_path = ftditrace_get_proxy_dll_path();

    if (g_hFileJson != INVALID_HANDLE_VALUE) {
        int n = wsprintfA(buf, "{\"meta\":\"start\",\"version\":\"%s\",\"arch\":\"win32-x86\",\"pid\":%lu,\"qpf\":\"%08lX%08lX\",\"session_start_qpc\":\"%08lX%08lX\",\"proxy_dll\":\"",
                FTDITRACE_VERSION, pid, qpf_hi, qpf_lo, start_hi, start_lo);
        append_json_escaped(buf, &n, sizeof(buf) - 256, proxy_path ? proxy_path : "");
        n += wsprintfA(buf + n, "\",\"real_dll\":\"");
        append_json_escaped(buf, &n, sizeof(buf) - 128, real_path ? real_path : "");
        n += wsprintfA(buf + n, "\",\"utc_start\":\"%04d-%02d-%02dT%02d:%02d:%02dZ\"}\n",
                st.wYear, st.wMonth, st.wDay, st.wHour, st.wMinute, st.wSecond);
        WriteFile(g_hFileJson, buf, n, &w, NULL);
    }
    if (g_hFileText != INVALID_HANDLE_VALUE) {
        int n = wsprintfA(buf, "=== FTDITrace Log Started (v%s, arch=x86) ===\r\nPID: %lu\r\nQPF: %08lX%08lX\r\nStart QPC: %08lX%08lX\r\nProxy DLL: %s\r\nReal DLL: %s\r\nUTC: %04d-%02d-%02dT%02d:%02d:%02dZ\r\n----------------------------------------\r\n",
                FTDITRACE_VERSION, pid, qpf_hi, qpf_lo, start_hi, start_lo,
                proxy_path ? proxy_path : "", real_path ? real_path : "",
                st.wYear, st.wMonth, st.wDay, st.wHour, st.wMinute, st.wSecond);
        WriteFile(g_hFileText, buf, n, &w, NULL);
    }
    
    g_log_event = CreateEventA(NULL, FALSE, FALSE, NULL);
    g_log_thread = CreateThread(NULL, 0, log_worker_thread, NULL, 0, NULL);
}

void ftditrace_log_enqueue(const ft_log_event_t *ev) {
    if (g_shutdown) return;
    EnterCriticalSection(&g_queue_lock);
    if (g_shutdown) {
        LeaveCriticalSection(&g_queue_lock);
        return;
    }
    bool was_empty = (g_head == g_tail);
    if (g_head - g_tail >= EVENT_QUEUE_SIZE) {
        g_dropped++;
    } else {
        g_queue[g_head % EVENT_QUEUE_SIZE] = *ev;
        g_head++;
    }
    LeaveCriticalSection(&g_queue_lock);
    if (was_empty && g_log_event) {
        SetEvent(g_log_event);
    }
}

void ftditrace_log_shutdown(bool is_process_exit) {
    g_shutdown = true;
    if (g_log_event) SetEvent(g_log_event);
    
    if (!is_process_exit) {
        if (g_log_thread) {
            WaitForSingleObject(g_log_thread, 2000);
            CloseHandle(g_log_thread);
            g_log_thread = NULL;
        }
    } else {
        EnterCriticalSection(&g_queue_lock);
        while (g_tail < g_head) {
            ft_log_event_t ev = g_queue[g_tail % EVENT_QUEUE_SIZE];
            g_tail++;
            write_event(&ev);
        }
        LeaveCriticalSection(&g_queue_lock);
        if (g_log_thread) {
            CloseHandle(g_log_thread);
            g_log_thread = NULL;
        }
    }
    
    uint64_t stop_qpc = ftditrace_qpc();
    unsigned long stop_hi = (unsigned long)(stop_qpc >> 32);
    unsigned long stop_lo = (unsigned long)(stop_qpc & 0xFFFFFFFF);
    unsigned long dropped_total = (unsigned long)g_dropped;
    unsigned long logged_total = (unsigned long)g_total_logged;
    
    char buf[512];
    DWORD w = 0;
    
    if (dropped_total > 0 && g_hFileJson != INVALID_HANDLE_VALUE) {
        int n = wsprintfA(buf, "{\"meta\":\"dropped_events\",\"dropped_total\":%lu}\n", dropped_total);
        WriteFile(g_hFileJson, buf, n, &w, NULL);
    }
    if (dropped_total > 0 && g_hFileText != INVALID_HANDLE_VALUE) {
        int n = wsprintfA(buf, "\r\n[WARNING] %lu events dropped due to queue overflow!\r\n", dropped_total);
        WriteFile(g_hFileText, buf, n, &w, NULL);
    }
    
    if (g_hFileJson != INVALID_HANDLE_VALUE) {
        int n = wsprintfA(buf, "{\"meta\":\"stop\",\"session_stop_qpc\":\"%08lX%08lX\",\"total_events_logged\":%lu,\"total_events_dropped\":%lu}\n",
                stop_hi, stop_lo, logged_total, dropped_total);
        WriteFile(g_hFileJson, buf, n, &w, NULL);
        CloseHandle(g_hFileJson);
        g_hFileJson = INVALID_HANDLE_VALUE;
    }
    
    if (g_hFileText != INVALID_HANDLE_VALUE) {
        int n = wsprintfA(buf, "=== FTDITrace Log Stopped ===\r\nStop QPC: %08lX%08lX\r\nTotal Logged: %lu\r\nTotal Dropped: %lu\r\n",
                stop_hi, stop_lo, logged_total, dropped_total);
        WriteFile(g_hFileText, buf, n, &w, NULL);
        CloseHandle(g_hFileText);
        g_hFileText = INVALID_HANDLE_VALUE;
    }
    
    if (g_log_event) {
        CloseHandle(g_log_event);
        g_log_event = NULL;
    }
    DeleteCriticalSection(&g_queue_lock);
}
