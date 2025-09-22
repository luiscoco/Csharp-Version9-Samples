using System;
using System.Runtime.CompilerServices;

static class Startup
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.WriteLine("Module initializer ran before Main.");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Inside Main.");
    }
}
