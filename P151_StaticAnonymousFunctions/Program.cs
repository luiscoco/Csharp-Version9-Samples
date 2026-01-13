using System;

class Program
{
    static void Main()
    {
        Func<int,int> square = static x => x * x;
        Console.WriteLine(square(7));
    }
}
