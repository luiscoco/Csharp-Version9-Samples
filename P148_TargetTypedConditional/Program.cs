using System;

class Animal {}
class Dog : Animal {}

class Program
{
    static void Main()
    {
        bool flag = DateTime.Now.Ticks % 2 == 0;
        Animal a = flag ? new Dog() : null;
        Console.WriteLine(a == null ? "null" : a.GetType().Name);
    }
}
