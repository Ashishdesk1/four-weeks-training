namespace CovariantAndContravariantGenerics
{
    interface IProcessor<in TInput, out TResult>
    {
        TResult Process(TInput input);
    }

    class StringToIntProcessor : IProcessor<string, int>
    {
        // Implement Process method
        TResult Process(TInput input);
        public int Process(string input)
        {
            IProcessor<string, int> processor = new StringToIntProcessor();
            string input = "Hello, World!";
            int length = processor.Process(input);
            throw new NotImplementedException();
        }
    }

    class DoubleToStringProcessor : IProcessor<double, string>
    {
        // Implement Process method
        public string Process(double input)
        {
            IProcessor<double, string> doubleProcessor = new DoubleToStringProcessor();
            double inputDouble = 3.14;
            string stringResult = doubleProcessor.Process(inputDouble);
            Console.WriteLine($"String representation of the input double: {stringResult}");
            throw new NotImplementedException();
        }
    }
    internal class Program
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
            // Demonstrate covariance and contravariance with IProcessor interface
        }
    }
}