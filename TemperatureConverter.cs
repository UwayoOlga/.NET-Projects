using System;

namespace SimplePrograms
{
    class TemperatureConverter
    {
        // This class provides an interactive Run() method but no Main entrypoint
        // to avoid conflicting entrypoints in the same project. You can call
        // TemperatureConverter.Run() from another program, or create a
        // separate console project to run it standalone.
        public static void Run()
        {
            Console.WriteLine("Temperature Converter");
            Console.WriteLine("---------------------");

            while (true)
            {
                Console.WriteLine("\nChoose conversion:");
                Console.WriteLine("1. Celsius -> Fahrenheit");
                Console.WriteLine("2. Fahrenheit -> Celsius");
                Console.WriteLine("3. Exit");
                Console.Write("Enter choice (1-3): ");

                string choice = Console.ReadLine();
                if (choice == "3")
                {
                    Console.WriteLine("Goodbye!");
                    return;
                }

                Console.Write("Enter temperature: ");
                if (!double.TryParse(Console.ReadLine(), out double inputTemp))
                {
                    Console.WriteLine("Invalid temperature. Please enter a number.");
                    continue;
                }

                double result;
                switch (choice)
                {
                    case "1": // C -> F
                        result = (inputTemp * 9.0 / 5.0) + 32.0;
                        Console.WriteLine($"{inputTemp} °C = {result:F2} °F");
                        break;
                    case "2": // F -> C
                        result = (inputTemp - 32.0) * 5.0 / 9.0;
                        Console.WriteLine($"{inputTemp} °F = {result:F2} °C");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select 1, 2, or 3.");
                        break;
                }
            }
        }
    }
}