using System;
unsafe class Program
{
    static int Add(int a, int b) => a + b;

    static void Main()
    {
        delegate*<int,int,int> p = &Add;
        int result = p(2,3);
        Console.WriteLine(result);
    }
}
