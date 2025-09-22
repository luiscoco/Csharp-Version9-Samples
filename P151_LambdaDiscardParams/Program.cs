using System;

class Program
{
    static void Main()
    {
        Action<int,int> a = (_, _) => Console.WriteLine("discarded both");
        a(1,2);
    }
}
