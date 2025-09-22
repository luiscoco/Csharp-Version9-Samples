using System;

class Program
{
    static string Describe(object o) => o switch
    {
        string s => $"string ({s.Length})",
        int n when n >= 1 && n <= 10 => "int between 1 and 10",
        int _ => "an int",
        _ => "something else"
    };

    static string Relational(int x) => x switch
    {
        < 0 => "neg",
        >= 0 and <= 10 => "0..10",
        _ => "big"
    };

    static void Main()
    {
        Console.WriteLine(Describe("hi"));  // string
        Console.WriteLine(Describe(5));     // int between 1 and 10
        Console.WriteLine(Describe(42));    // an int
        Console.WriteLine(Relational(5));   // 0..10
        Console.WriteLine(Relational(20));  // big
    }
}
