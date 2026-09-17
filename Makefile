CC ?= i686-w64-mingw32-gcc
OBJDUMP ?= i686-w64-mingw32-objdump
WINE ?= wine

CFLAGS ?= -std=gnu11 -Os -Wall -Wextra -Wpedantic -D_WIN32_WINNT=0x0501
DLL_LDFLAGS ?= -shared -static-libgcc -Wl,--enable-stdcall-fixup -Wl,--kill-at -Wl,--out-implib,libftd2xx.a

.PHONY: all clean verify test

all: FTD2XX.dll

FTD2XX.dll: ftd2xx_shim.c ftd2xx_shim.h ftd2xx.def
	$(CC) $(CFLAGS) -o $@ ftd2xx_shim.c ftd2xx.def $(DLL_LDFLAGS)

test_shim.exe: test_shim.c FTD2XX.dll
	$(CC) $(CFLAGS) -o $@ test_shim.c -static-libgcc

verify: FTD2XX.dll
	file FTD2XX.dll
	$(OBJDUMP) -p FTD2XX.dll | sed -n '/Export Table/,$$p'

test: test_shim.exe
	WINEDLLOVERRIDES="ftd2xx=n" $(WINE) ./test_shim.exe

clean:
	rm -f FTD2XX.dll libftd2xx.a test_shim.exe ftd2xx-shim.log
