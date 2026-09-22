CLANG_WIN ?= clang -target i686-pc-windows-gnu
WINE ?= wine

WIN_CFLAGS ?= -O2 -mno-stack-arg-probe -Wall -Wextra -I/usr/include/wine/windows -I/usr/include/wine/msvcrt -Iinclude -Wno-format
WIN_LDFLAGS_DLL ?= -fuse-ld=lld -nostdlib -L/usr/lib/wine/i386-windows -lkernel32 -luser32 -lucrtbase -Wl,--kill-at
WIN_LDFLAGS_EXE ?= -fuse-ld=lld -nostdlib -L/usr/lib/wine/i386-windows -lkernel32 -luser32 -lucrtbase -Wl,--subsystem,console

.PHONY: all clean test

all: FTD2XX.dll FTD2XX_REAL.dll FTD2XX_MISSING_EXP.dll test_ftditrace.exe test_negative.exe

FTD2XX.dll: src/ftditrace.c src/real_d2xx.c src/trace_log.c FTD2XX.def
	$(CLANG_WIN) $(WIN_CFLAGS) -shared src/ftditrace.c src/real_d2xx.c src/trace_log.c FTD2XX.def $(WIN_LDFLAGS_DLL) -o $@ -Wl,-e,_DllMain@12

FTD2XX_REAL.dll: tests/fake_ftd2xx.c
	$(CLANG_WIN) $(WIN_CFLAGS) -shared tests/fake_ftd2xx.c $(WIN_LDFLAGS_DLL) -o $@ -Wl,-e,_DllMain@12

FTD2XX_MISSING_EXP.dll: tests/fake_missing_exp.c
	$(CLANG_WIN) $(WIN_CFLAGS) -shared tests/fake_missing_exp.c $(WIN_LDFLAGS_DLL) -o $@ -Wl,-e,_DllMain@12

test_ftditrace.exe: tests/test_ftditrace.c
	$(CLANG_WIN) $(WIN_CFLAGS) tests/test_ftditrace.c $(WIN_LDFLAGS_EXE) -o $@ -Wl,-e,_main

test_negative.exe: tests/test_negative.c
	$(CLANG_WIN) $(WIN_CFLAGS) tests/test_negative.c $(WIN_LDFLAGS_EXE) -o $@ -Wl,-e,_main

test: all
	@echo "=== Cleaning previous logs for clean test run ==="
	rm -rf FTDITrace-Logs
	@echo "=== Running FTDITrace positive, forwarding & concurrency tests ==="
	FTDITRACE_REAL_DLL=./FTD2XX_REAL.dll $(WINE) ./test_ftditrace.exe
	@echo "=== Running FTDITrace negative missing-DLL & missing-export tests ==="
	$(WINE) ./test_negative.exe
	@echo "=== Running JSONL validation ==="
	python3 tests/validate_jsonl.py FTDITrace-Logs
	@echo "=== Running installer & uninstaller fixture tests ==="
	python3 tests/test_installer_fixtures.py

clean:
	rm -f *.dll *.exe
	rm -rf FTDITrace-Logs
