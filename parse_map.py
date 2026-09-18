import struct
with open('/home/spoqn/Desktop/Source Codes/OpenECU/OpenECU-src/tests/fixtures/20417Map.hex', 'rb') as f:
    data = bytearray(f.read())
num2 = struct.unpack('<I', data[0:4])[0] | 0x80808080
num = 4; b=0; b2=0
while num < len(data):
    b3 = (b2 % 4) * 8; b2 += 1
    key_byte = (num2 >> b3) & 0xFF
    curr = data[num]
    data[num] = curr ^ b ^ key_byte
    b = curr
    num += 1

num6 = struct.unpack('<h', data[28:30])[0]
num_val = data[num6 + 33]
num2_len = num_val * 8 + 38
for idx in range(num_val):
    v = struct.unpack('<i', data[num6 + idx * 8 + 38 : num6 + idx * 8 + 42])[0]
    num2_len += v

array2 = bytearray(num2_len)
array2[0:28] = data[0:28]
array2[28] = num_val
n_copy = num_val * 8
array2[30:30+n_copy] = data[num6+34 : num6+34+n_copy]

i = 30 + n_copy
offset = num6 + 34 + n_copy
remaining = num2_len - i
array2[i:i+remaining] = data[offset : offset+remaining]

addrTable = [
0x6000, 0x34DE0, 0x4FFE0, 0x20, 0x50000, 0x920, 0x51000, 0x160,
0x52000, 0x6A0, 0x53000, 0x600, 0x55000, 0x7DE0, 0x5FFE0, 0x20
]

memoMap = bytearray(1048576)
num_memo = 8 * 8 + 30 # = 94

for j in range(8):
    dest = addrTable[j*2]
    size = addrTable[j*2+1]
    for k in range(size):
        memoMap[dest+k] = array2[num_memo + k]
    num_memo += size

val_rev = (memoMap[0x5061C] << 8) | memoMap[0x5061D]
val_fan = (memoMap[0x5226E] << 8) | memoMap[0x5226F]
val_spd = (memoMap[0x533A2] << 8) | memoMap[0x533A3]

print(f"Rev Limit at 0x5061C: Raw {val_rev} (0x{val_rev:04X})")
print(f"Fan at 0x5226E: Raw {val_fan} (0x{val_fan:04X})")
print(f"Speed Adjust at 0x533A2: Raw {val_spd} (0x{val_spd:04X})")
print(f"mHeader[27]: {array2[27]}")
