#include <stdio.h>
#include <stdint.h>
#include "/home/spoqn/Desktop/Source Codes/OpenShimFTDI/reference/j2534/nikolakozina-j2534/j2534/j2534.h"

int main(void)
{
    unsigned long device_id = 0;

    int32_t rc = PassThruOpen(NULL, &device_id);

    printf("PassThruOpen returned: %d\n", rc);
    printf("Device ID: %lu\n", device_id);

    if (rc != J2534_NOERROR) {
        return 1;
    }

    rc = PassThruClose(device_id);

    printf("PassThruClose returned: %d\n", rc);

    return rc == J2534_NOERROR ? 0 : 1;
}
