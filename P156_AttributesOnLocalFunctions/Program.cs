using System;

class Program
{
    static void Main()
    {
        [Obsolete("Just a demo")]
        static void Helper() => Console.WriteLine("Hello");
        Helper();
    }
}
