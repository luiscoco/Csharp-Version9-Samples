using System;
class Program
{
    static void Main()
    {
        nint a = 10;
        nuint b = 20;
        Console.WriteLine($"nint={a}, nuint={b}");
        Console.WriteLine($"Size of nint: {IntPtr.Size} bytes");
    }
}
