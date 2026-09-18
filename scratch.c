#include <stdio.h>
#include <stdint.h>
#include <stdlib.h>

int main(int argc, char **argv) {
    if (argc < 3) return 1;
    FILE *fin = fopen(argv[1], "rb");
    FILE *fout = fopen(argv[2], "wb");
    if (!fin || !fout) return 1;

    fseek(fin, 0, SEEK_END);
    long size = ftell(fin);
    fseek(fin, 0, SEEK_SET);

    uint8_t *data = malloc(size);
    fread(data, 1, size, fin);

    uint32_t magic = *(uint32_t*)data;
    uint32_t mask1 = magic | 0x80808080u;

    uint8_t prev = 0;
    uint8_t b2 = 0;
    for (long i = 4; i < size; i++) {
        uint8_t shift = (b2 % 4) * 8;
        uint8_t mask = (mask1 >> shift) & 0xFF;
        uint8_t raw = data[i];
        uint8_t dec = raw ^ prev ^ mask;
        prev = raw;
        data[i] = dec;
        b2++;
    }

    fwrite(data, 1, size, fout);
    fclose(fin);
    fclose(fout);
    free(data);
    return 0;
}
