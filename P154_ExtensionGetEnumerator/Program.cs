using System;
using System.Collections.Generic;

class Bag<T> : List<T> {}

static class BagExtensions
{
    public static IEnumerator<T> GetEnumerator<T>(this Bag<T> bag)
    {
        return ((List<T>)bag).GetEnumerator();
    }
}

class Program
{
    static void Main()
    {
        var bag = new Bag<int>{1,2,3};
        foreach (var x in bag) Console.WriteLine(x);
    }
}
