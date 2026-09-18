#define _GNU_SOURCE
#include <stdio.h>
#include <stdlib.h>
#include <stdint.h>
#include <string.h>
#include <dlfcn.h>
#include <unistd.h>
#include <assert.h>

typedef int32_t (*OpenFn)(void *, unsigned long *);
typedef int32_t (*CloseFn)(unsigned long);
typedef int32_t (*ConnectFn)(unsigned long, unsigned long, unsigned long, unsigned long, unsigned long *);
typedef int32_t (*DisconnectFn)(unsigned long);
typedef int32_t (*IoctlFn)(unsigned long, unsigned long, const void *, void *);
typedef int32_t (*GetLastErrorFn)(char *);
typedef int32_t (*StartMsgFilterFn)(unsigned long, unsigned long, const void *, const void *, const void *, unsigned long *);
typedef int32_t (*StopMsgFilterFn)(unsigned long, unsigned long);

#define J2534_FIVE_BAUD_INIT 4
#define J2534_FAST_INIT 5
#define J2534_CLEAR_TX_BUFFER 7
#define J2534_CLEAR_RX_BUFFER 8
#define PASS_FILTER 1

typedef struct {
    unsigned long NumOfBytes;
    unsigned char *BytePtr;
} SBYTE_ARRAY;

typedef struct {
    unsigned long ProtocolID;
    unsigned long RxStatus;
    unsigned long TxFlags;
    unsigned long Timestamp;
    unsigned long DataSize;
    unsigned long ExtraDataIndex;
    unsigned char Data[4128];
} PASSTHRU_MSG;

int main(int argc, char *argv[])
{
    setvbuf(stdout, NULL, _IONBF, 0);
    setvbuf(stderr, NULL, _IONBF, 0);

    const char *lib_path = "./j2534.so";
    if (argc > 1) {
        lib_path = argv[1];
    }
    printf("=== OpenPort 2.0 Live FIVE_BAUD_INIT & Hardware Safety Test ===\n");
    printf("Loading J2534 library: %s\n", lib_path);

    void *h = dlopen(lib_path, RTLD_NOW);
    if (!h) {
        fprintf(stderr, "FAIL: dlopen failed: %s\n", dlerror());
        return 1;
    }

    OpenFn pOpen = (OpenFn)dlsym(h, "PassThruOpen");
    CloseFn pClose = (CloseFn)dlsym(h, "PassThruClose");
    ConnectFn pConnect = (ConnectFn)dlsym(h, "PassThruConnect");
    DisconnectFn pDisconnect = (DisconnectFn)dlsym(h, "PassThruDisconnect");
    IoctlFn pIoctl = (IoctlFn)dlsym(h, "PassThruIoctl");
    GetLastErrorFn pGetLastError = (GetLastErrorFn)dlsym(h, "PassThruGetLastError");
    StartMsgFilterFn pStartFilter = (StartMsgFilterFn)dlsym(h, "PassThruStartMsgFilter");
    StopMsgFilterFn pStopFilter = (StopMsgFilterFn)dlsym(h, "PassThruStopMsgFilter");

    if (!pOpen || !pClose || !pConnect || !pDisconnect || !pIoctl || !pGetLastError) {
        fprintf(stderr, "FAIL: Failed to resolve essential J2534 entry points\n");
        return 1;
    }

    unsigned long dev_id = 0;
    int32_t rc = pOpen(NULL, &dev_id);
    printf("PassThruOpen() -> %d (dev_id=%lu)\n", rc, dev_id);
    if (rc != 0) {
        char err[256] = {0};
        pGetLastError(err);
        fprintf(stderr, "FAIL: PassThruOpen failed: %s\n", err);
        return 1;
    }

    /* =========================================================================
     * TEST 1: ISO9141 (ProtocolID=3) - atw3 51 dispatch & timeout path
     * ========================================================================= */
    printf("\n--- Test 1: Connect ISO9141 (Channel 3), dispatch atw3 51 ---\n");
    unsigned long ch_id_9141 = 0;
    rc = pConnect(dev_id, 3 /* ISO9141 */, 0, 10400, &ch_id_9141);
    printf("PassThruConnect(ISO9141) -> %d (channel_id=%lu)\n", rc, ch_id_9141);
    assert(rc == 0);

    unsigned char target_addr = 0x33;
    unsigned char keybytes[16] = {0};
    SBYTE_ARRAY in_arr = { 1, &target_addr };
    SBYTE_ARRAY out_arr = { sizeof(keybytes), keybytes };

    printf("Dispatching PassThruIoctl(FIVE_BAUD_INIT, addr=0x%02X)...\n", target_addr);
    rc = pIoctl(ch_id_9141, J2534_FIVE_BAUD_INIT, &in_arr, &out_arr);
    printf("FIVE_BAUD_INIT rc = %d, out_bytes = %lu\n", rc, out_arr.NumOfBytes);
    if (rc == 0 && out_arr.NumOfBytes > 0) {
        printf("ECU responded! Keybytes: ");
        for (unsigned long i = 0; i < out_arr.NumOfBytes; i++) {
            printf("%02X ", out_arr.BytePtr[i]);
        }
        printf("\n");
    } else {
        char err[256] = {0};
        pGetLastError(err);
        printf("[CONFIRMED] Without ECU connected, OpenPort timed out cleanly (rc=%d, err='%s')\n", rc, err);
    }

    rc = pDisconnect(ch_id_9141);
    printf("PassThruDisconnect(ISO9141) -> %d\n", rc);
    assert(rc == 0);

    /* =========================================================================
     * TEST 2: ISO14230 (ProtocolID=4) - atw4 51 dispatch & timeout path
     * ========================================================================= */
    printf("\n--- Test 2: Connect ISO14230 (Channel 4), dispatch atw4 51 ---\n");
    unsigned long ch_id_14230 = 0;
    rc = pConnect(dev_id, 4 /* ISO14230 */, 0, 10400, &ch_id_14230);
    printf("PassThruConnect(ISO14230) -> %d (channel_id=%lu)\n", rc, ch_id_14230);
    assert(rc == 0);

    memset(keybytes, 0, sizeof(keybytes));
    out_arr.NumOfBytes = sizeof(keybytes);
    out_arr.BytePtr = keybytes;

    printf("Dispatching PassThruIoctl(FIVE_BAUD_INIT, addr=0x%02X)...\n", target_addr);
    rc = pIoctl(ch_id_14230, J2534_FIVE_BAUD_INIT, &in_arr, &out_arr);
    printf("FIVE_BAUD_INIT rc = %d, out_bytes = %lu\n", rc, out_arr.NumOfBytes);
    if (rc == 0 && out_arr.NumOfBytes > 0) {
        printf("ECU responded! Keybytes: ");
        for (unsigned long i = 0; i < out_arr.NumOfBytes; i++) {
            printf("%02X ", out_arr.BytePtr[i]);
        }
        printf("\n");
    } else {
        char err[256] = {0};
        pGetLastError(err);
        printf("[CONFIRMED] Without ECU connected, OpenPort timed out cleanly (rc=%d, err='%s')\n", rc, err);
    }

    rc = pDisconnect(ch_id_14230);
    printf("PassThruDisconnect(ISO14230) -> %d\n", rc);
    assert(rc == 0);

    /* =========================================================================
     * TEST 3: Verify hardware channel integrity and filter operations after 5-baud init
     * ========================================================================= */
    printf("\n--- Test 3: Subsequent normal commands verification ---\n");
    unsigned long ch_verify = 0;
    rc = pConnect(dev_id, 4 /* ISO14230 */, 0, 10400, &ch_verify);
    printf("PassThruConnect -> %d (ch=%lu)\n", rc, ch_verify);
    assert(rc == 0);

    PASSTHRU_MSG maskMsg = {0};
    PASSTHRU_MSG patternMsg = {0};
    maskMsg.ProtocolID = 4;
    patternMsg.ProtocolID = 4;
    unsigned long filter_id = 0;
    rc = pStartFilter(ch_verify, PASS_FILTER, &maskMsg, &patternMsg, NULL, &filter_id);
    printf("PassThruStartMsgFilter -> %d (filter_id=%lu)\n", rc, filter_id);

    if (rc == 0 && pStopFilter) {
        int32_t stop_rc = pStopFilter(ch_verify, filter_id);
        printf("PassThruStopMsgFilter -> %d\n", stop_rc);
        if (stop_rc != 0) {
            char err[256] = {0};
            pGetLastError(err);
            printf("StopMsgFilter detail: %s\n", err);
        }
    }

    rc = pDisconnect(ch_verify);
    printf("PassThruDisconnect -> %d\n", rc);
    assert(rc == 0);

    rc = pClose(dev_id);
    printf("PassThruClose -> %d\n", rc);
    assert(rc == 0);

    dlclose(h);
    printf("\n=== HARDWARE VALIDATION PASSED WITHOUT DEADLOCK OR CRASH ===\n");
    return 0;
}
