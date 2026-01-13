using System;

class Program
{
    static string Classify(int x) => x switch
    {
        < 0           => "negative",
        >= 0 and < 10 => "small non-negative",
        10 or 11 or 12 => "ten-ish",
        not (> 100)   => "not greater than 100",
        _             => "big"
    };

    static string TypeCheck(object o) => o switch
    {
        string s when s.Length == 0 => "empty string",
        string s => $"string '{s}'",
        int n    => $"int {n}",
        _        => "other"
    };

    static void Main()
    {
        Console.WriteLine(Classify(-3));
        Console.WriteLine(Classify(5));
        Console.WriteLine(Classify(11));
        Console.WriteLine(Classify(150));
        Console.WriteLine(TypeCheck(""));
        Console.WriteLine(TypeCheck(42));
    }
}
