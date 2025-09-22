using System;

class Animal { public virtual string Name => "Animal"; }
class Dog : Animal { public override string Name => "Dog"; }

class BaseFactory
{
    public virtual Animal Create() => new Animal();
}
class DogFactory : BaseFactory
{
    public override Dog Create() => new Dog();
}

class Program
{
    static void Main()
    {
        BaseFactory f = new DogFactory();
        Console.WriteLine(f.Create().Name);
    }
}
