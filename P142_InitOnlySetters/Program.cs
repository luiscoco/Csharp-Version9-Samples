using System;

public class Book
{
    public string Title { get; init; } = "";
    public string Author { get; init; } = "";
}

class Program
{
    static void Main()
    {
        var b = new Book { Title = "C# in Depth", Author = "Skeet" };
        Console.WriteLine($"{b.Title} by {b.Author}");
    }
}
