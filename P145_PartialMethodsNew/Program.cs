using System;

partial class Widget
{
    public partial int Compute(int x);
}

partial class Widget
{
    public partial int Compute(int x) => x * 2;
}

class Program
{
    static void Main()
    {
        var w = new Widget();
        Console.WriteLine(w.Compute(21));
    }
}
