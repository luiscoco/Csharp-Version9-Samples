using System;
using System.Runtime.CompilerServices;

class Program
{
    [SkipLocalsInit]
    static unsafe void RawStackDemo()
    {
        int* p = stackalloc int[3];
        p[0] = 1; p[1] = 2; p[2] = 3;
        Console.WriteLine(p[0] + p[1] + p[2]);
    }

    static void Main() => RawStackDemo();
}
