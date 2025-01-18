using System;
using Test;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Validation Form ===");

        string name = GetName();
        int age = GetAge();

        Console.WriteLine("=== Result ===");
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Age: {age}");

        Console.WriteLine("=== Run Test ===");
        ValidatorTests.RunTests();
    }

    static string GetName()
    {
        string name;
        while (true)
        {
            Console.Write("Enter your name: ");
            name = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(name) && name.Length >= 3)
                break;

            Console.WriteLine("Error: The name must have at least 3 characters and cannot be empty.");
        }
        return name;
    }

    static int GetAge()
    {
        int age;
        while (true)
        {
            Console.Write("Enter your age: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out age) && age > 0)
                break;

            Console.WriteLine("Error: The age must be a positive number.");
        }
        return age;
    }
}
