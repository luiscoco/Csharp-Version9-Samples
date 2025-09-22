using System;

public record Person(string Name, int Age);

class Program
{
    static void Main()
    {
        var p1 = new Person("Ana", 20);
        var p2 = p1 with { Age = 21 };
        Console.WriteLine(p1 == p2);         // value semantics -> False
        Console.WriteLine(p1 with { } == p1); // True
        var (name, age) = p2;                 // deconstruction
        Console.WriteLine($"{name} is {age}");
    }
}
