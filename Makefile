CC_HOST ?= gcc
CLANG_WIN ?= clang -target i686-pc-windows-gnu
WINE ?= wine

HOST_CFLAGS ?= -O2 -Wall -Wextra -pthread -Iinclude
WIN_CFLAGS ?= -O2 -mno-stack-arg-probe -Wall -Wextra -I/usr/include/wine/windows -I/usr/include/wine/msvcrt -Iinclude
WIN_LDFLAGS ?= -fuse-ld=lld -nostdlib -L/usr/lib/wine/i386-windows -lkernel32 -lucrtbase

.PHONY: all clean test test-loopback test-ipc test-helper test-break-decode

all: openshim-helper FTD2XX.dll test_ipc_framing test_helper_live test_shim.exe test/test_shim_ipc.exe test/test_shim_break_decode.exe

openshim-helper: src/helper/openshim_helper.c include/openshim_ipc.h
	$(CC_HOST) $(HOST_CFLAGS) src/helper/openshim_helper.c -o $@ -ldl

test_ipc_framing: test/test_ipc_framing.c include/openshim_ipc.h
	$(CC_HOST) $(HOST_CFLAGS) test/test_ipc_framing.c -o $@

test_helper_live: test/test_helper_live.c include/openshim_ipc.h
	$(CC_HOST) $(HOST_CFLAGS) test/test_helper_live.c -o $@

src/ftd2xx_shim.o: src/ftd2xx_shim.c src/ftd2xx_shim.h include/openshim_ipc.h
	$(CLANG_WIN) $(WIN_CFLAGS) -c $< -o $@

FTD2XX.dll: src/ftd2xx_shim.o
	$(CLANG_WIN) $(WIN_LDFLAGS) -shared -o $@ $< -lws2_32 -Wl,-e,_DllMain@12 -Wl,--kill-at

test_shim.exe: test/test_shim.c FTD2XX.dll
	$(CLANG_WIN) $(WIN_CFLAGS) -c test/test_shim.c -o test/test_shim.o
	$(CLANG_WIN) $(WIN_LDFLAGS) -o $@ test/test_shim.o -Wl,-e,_main -Wl,--subsystem,console

test/test_shim_ipc.exe: test/test_shim_ipc.c FTD2XX.dll
	$(CLANG_WIN) $(WIN_CFLAGS) -c test/test_shim_ipc.c -o test/test_shim_ipc.o
	$(CLANG_WIN) $(WIN_LDFLAGS) -o $@ test/test_shim_ipc.o -Wl,-e,_main -Wl,--subsystem,console

test/test_shim_break_decode.exe: test/test_shim_break_decode.c FTD2XX.dll
	$(CLANG_WIN) $(WIN_CFLAGS) -c test/test_shim_break_decode.c -o test/test_shim_break_decode.o
	$(CLANG_WIN) $(WIN_LDFLAGS) -o $@ test/test_shim_break_decode.o -Wl,-e,_main -Wl,--subsystem,console

test-loopback: FTD2XX.dll test_shim.exe
	@echo "=== Running synthetic loopback tests ==="
	WINEDLLOVERRIDES="ftd2xx=n" OPENSHIM_BACKEND=loopback $(WINE) ./test_shim.exe

test-break-decode: FTD2XX.dll test/test_shim_break_decode.exe
	@echo "=== Running 5-baud break decode & handshake virtualization tests ==="
	WINEDLLOVERRIDES="ftd2xx=n" OPENSHIM_BACKEND=loopback $(WINE) ./test/test_shim_break_decode.exe

test-ipc: all
	@echo "=== Running end-to-end IPC tests ==="
	./openshim-helper --port 19234 & HELPER_PID=$$!; \
	sleep 0.5; \
	WINEDLLOVERRIDES="ftd2xx=n" $(WINE) ./test/test_shim_ipc.exe; \
	RET=$$?; \
	kill $$HELPER_PID 2>/dev/null || true; \
	exit $$RET

test-helper: openshim-helper test_helper_live
	@echo "=== Running live helper test ==="
	./openshim-helper --port 19238 & HELPER_PID=$$!; \
	sleep 0.5; \
	./test_helper_live 19238; \
	RET=$$?; \
	kill $$HELPER_PID 2>/dev/null || true; \
	exit $$RET

test: test_ipc_framing test-loopback test-break-decode test-helper test-ipc
	@echo "=== Running IPC framing unit test ==="
	./test_ipc_framing
	@echo "=== ALL TEST SUITES PASSED ==="

clean:
	rm -f openshim-helper FTD2XX.dll test_ipc_framing test_helper_live test_shim.exe test/test_shim_ipc.exe test/test_shim_break_decode.exe test_five_baud_live
	rm -f src/*.o test/*.o ftd2xx-shim.log
