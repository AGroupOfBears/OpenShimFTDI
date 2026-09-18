using System;
public class Test {
    public static void Main() {
        int[] mapTable = new int[] { 0x5590 };
        int num3 = (mapTable[0] & 0xF0) << 12; // Decompiled C# output
        Console.WriteLine($"num3 = 0x{num3:X}");
        
        int num3_alt = (mapTable[0] & 0xF0000); 
        Console.WriteLine($"alt  = 0x{num3_alt:X}");
        
        int num3_alt2 = (mapTable[0] & 0xF000); 
        Console.WriteLine($"alt2 = 0x{num3_alt2:X} or shift: 0x{(mapTable[0] & 0xF0) << 12:X}");
    }
}
