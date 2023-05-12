using System;

public interface IProcessor<in TInput, out TResult>
{
    TResult Process(TInput input);
}

public class Animal
{
    public string Name { get; set; }
}

public class Dog : Animal
{
    public void Bark()
    {
        Console.WriteLine("Woof!");
    }
}

public class Cat : Animal
{
    public void Meow()
    {
        Console.WriteLine("Meow!");
    }
}

public class AnimalProcessor : IProcessor<Animal, string>
{
    public string Process(Animal input)
    {
        return $"Processing animal: {input.Name}";
    }
}

public class DogProcessor : IProcessor<Dog, string>
{
    public string Process(Dog input)
    {
        input.Bark();
        return $"Processing dog: {input.Name}";
    }
}

public class Program
{
    static void Main(string[] args)
    {
        IProcessor<Dog, string> dogProcessor = new DogProcessor();
        Dog dog = new Dog { Name = "Max" };
        string resultDog = dogProcessor.Process(dog);
        Console.WriteLine(resultDog);

        IProcessor<Animal, string> animalProcessor = new AnimalProcessor();
        Dog dog2 = new Dog { Name = "Buddy" };
        string resultAnimal = animalProcessor.Process(dog2);
        Console.WriteLine(resultAnimal);
    }
}
