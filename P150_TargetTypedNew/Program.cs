using System;

class Foo { public int X; public override string ToString() => "X=" + X; }

class Program
{
    static void Main()
    {
        Foo f = new();
        f.X = 5;
        Console.WriteLine(f);
    }
}
