#include "../include/ftditrace.h"
#include <windows.h>

#define EVENT_QUEUE_SIZE 4096

static ft_log_event_t g_queue[EVENT_QUEUE_SIZE];
static volatile uint64_t g_head = 0;
static volatile uint64_t g_tail = 0;
static volatile uint64_t g_dropped = 0;
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
    return li.QuadPart;
}

uint32_t ftditrace_qpc_to_ms(uint64_t delta) {
    return (uint32_t)delta / g_qpf_ms;
}

static const char* event_names[] = {
    "FT_CreateDeviceInfoList", "FT_ListDevices", "FT_Open", "FT_OpenEx", "FT_Close",
    "FT_Read", "FT_Write", "FT_SetBaudRate", "FT_SetDataCharacteristics", "FT_SetFlowControl",
    "FT_SetDtr", "FT_ClrDtr", "FT_SetRts", "FT_ClrRts", "FT_Purge", "FT_SetTimeouts",
    "FT_SetBreakOn", "FT_SetBreakOff", "FT_GetStatus", "FT_SetEventNotification",
    "FT_SetLatencyTimer", "FT_SetUSBParameters", "META_INFO"
};

static void write_event(const ft_log_event_t* ev) {
    char buf[1024];
    DWORD w = 0;
    
    uint32_t elapsed_ms = ftditrace_qpc_to_ms(ev->ts_exit - ev->ts_entry);
    uint32_t rel_time = ftditrace_qpc_to_ms(ev->ts_entry - g_session_start_qpc);
    
    if (g_hFileText != INVALID_HANDLE_VALUE) {
        int n = wsprintfA(buf, "[%08lu] [T:%04X] (+%lu ms) %s (duration: %lu ms) status=%lu handle=%08lX args=[%lu, %lu, %lu] bytes=%u/%u",
                (unsigned long)ev->seq, ev->thread_id, (unsigned long)rel_time, event_names[ev->ev_type], (unsigned long)elapsed_ms,
                ev->status, (unsigned long)(ULONG_PTR)ev->handle, ev->arg1, ev->arg2, ev->arg3, ev->act_bytes, ev->req_bytes);
        if (ev->data_len > 0 && n > 0 && n < 1000) {
            n += wsprintfA(buf + n, " DATA: ");
            for (uint32_t i = 0; i < ev->data_len && n < 1000; i++) {
                n += wsprintfA(buf + n, "%02X ", ev->data[i]);
            }
        }
        if (n > 0 && n < 1022) {
            buf[n++] = '\n';
            buf[n] = 0;
        }
        if (n > 0) WriteFile(g_hFileText, buf, n, &w, NULL);
    }
    
    if (g_hFileJson != INVALID_HANDLE_VALUE) {
        int n = wsprintfA(buf, "{\"seq\":%lu,\"event\":\"%s\",\"tid\":%lu,\"rel_ms\":%lu,\"dur_ms\":%lu,\"status\":%lu,\"handle\":%lu,\"arg1\":%lu,\"arg2\":%lu,\"arg3\":%lu,\"req\":%lu,\"act\":%lu,\"data\":[",
                (unsigned long)ev->seq, event_names[ev->ev_type], ev->thread_id, (unsigned long)rel_time, (unsigned long)elapsed_ms,
                ev->status, (unsigned long)(ULONG_PTR)ev->handle, ev->arg1, ev->arg2, ev->arg3, ev->req_bytes, ev->act_bytes);
                
        for (uint32_t i = 0; i < ev->data_len && n < 1000; i++) {
            n += wsprintfA(buf + n, "%s%u", (i > 0) ? "," : "", ev->data[i]);
        }
        if (n > 0 && n < 1020) {
            n += wsprintfA(buf + n, "]}\n");
            WriteFile(g_hFileJson, buf, n, &w, NULL);
        }
    }
}

static DWORD WINAPI log_worker_thread(LPVOID param) {
    (void)param;
    while (!g_shutdown) {
        if (g_tail == g_head) {
            WaitForSingleObject(g_log_event, 50);
            continue;
        }
        ft_log_event_t ev;
        EnterCriticalSection(&g_queue_lock);
        if (g_tail < g_head) {
            ev = g_queue[g_tail % EVENT_QUEUE_SIZE];
            g_tail++;
        }
        LeaveCriticalSection(&g_queue_lock);
        write_event(&ev);
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
            while(dll_path[i]) { if(dll_path[i] == '\\' || dll_path[i] == '/') last_slash = &dll_path[i]; i++; }
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
    
    char buf[1024];
    DWORD w = 0;
    
    g_session_start_qpc = ftditrace_qpc();
    uint32_t qpf32 = (uint32_t)g_qpf.QuadPart;
    uint32_t start_lo = (uint32_t)g_session_start_qpc;

    if (g_hFileJson != INVALID_HANDLE_VALUE) {
        int n = wsprintfA(buf, "{\"meta\":\"start\",\"pid\":%lu,\"qpf\":%lu,\"start_ts_lo\":%lu}\n", pid, qpf32, start_lo);
        WriteFile(g_hFileJson, buf, n, &w, NULL);
    }
    if (g_hFileText != INVALID_HANDLE_VALUE) {
        int n = wsprintfA(buf, "=== FTDITrace Log Started ===\nPID: %lu\nQPF: %lu\n", pid, qpf32);
        WriteFile(g_hFileText, buf, n, &w, NULL);
    }
    
    g_log_event = CreateEventA(NULL, FALSE, FALSE, NULL);
    g_log_thread = CreateThread(NULL, 0, log_worker_thread, NULL, 0, NULL);
}

void ftditrace_log_enqueue(ft_log_event_t *ev) {
    if (g_shutdown) return;
    EnterCriticalSection(&g_queue_lock);
    if (g_head - g_tail >= EVENT_QUEUE_SIZE) {
        g_dropped++;
    } else {
        g_queue[g_head % EVENT_QUEUE_SIZE] = *ev;
        g_head++;
    }
    LeaveCriticalSection(&g_queue_lock);
    if (g_log_event) SetEvent(g_log_event);
}

void ftditrace_log_shutdown(void) {
    g_shutdown = true; // Signals thread to exit its loop
    
    // Drain remaining queue synchronously on the detaching thread
    EnterCriticalSection(&g_queue_lock);
    while (g_tail < g_head) {
        ft_log_event_t ev = g_queue[g_tail % EVENT_QUEUE_SIZE];
        g_tail++;
        write_event(&ev);
    }
    LeaveCriticalSection(&g_queue_lock);
    
    if (g_dropped > 0 && g_hFileText != INVALID_HANDLE_VALUE) {
        char buf[128];
        DWORD w = 0;
        int n = wsprintfA(buf, "\n[WARNING] %lu events dropped due to queue overflow!\n", (unsigned long)g_dropped);
        WriteFile(g_hFileText, buf, n, &w, NULL);
    }
    
    if (g_hFileText != INVALID_HANDLE_VALUE) { CloseHandle(g_hFileText); g_hFileText = INVALID_HANDLE_VALUE; }
    if (g_hFileJson != INVALID_HANDLE_VALUE) { CloseHandle(g_hFileJson); g_hFileJson = INVALID_HANDLE_VALUE; }
    
    if (g_log_event) { CloseHandle(g_log_event); g_log_event = NULL; }
    DeleteCriticalSection(&g_queue_lock);
}
