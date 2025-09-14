using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Simple Calculator");

        bool keepRunning = true;

        while (keepRunning)
        {
            double num1 = 0, num2 = 0;
            string op = "";
            bool validInput = false;

            // Get first number with exception handling
            while (!validInput)
            {
                Console.Write("Enter the first number: ");
                string input = Console.ReadLine();
                if (double.TryParse(input, out num1))
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid number! Please enter a valid number.");
                }
            }

            // Get operator with validation
            validInput = false;
            while (!validInput)
            {
                Console.Write("Enter an operator (+, -, *, /): ");
                op = Console.ReadLine();
                if (op == "+" || op == "-" || op == "*" || op == "/")
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid operator! Please enter +, -, *, or /.");
                }
            }

            // Get second number with exception handling
            validInput = false;
            while (!validInput)
            {
                Console.Write("Enter the second number: ");
                string input = Console.ReadLine();
                if (double.TryParse(input, out num2))
                {
                    if (op == "/" && num2 == 0)
                    {
                        Console.WriteLine("Cannot divide by zero! Please enter a non-zero number.");
                    }
                    else
                    {
                        validInput = true;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid number! Please enter a valid number.");
                }
            }

            // Perform calculation
            double result = 0;
            switch (op)
            {
                case "+": result = num1 + num2; break;
                case "-": result = num1 - num2; break;
                case "*": result = num1 * num2; break;
                case "/": result = num1 / num2; break;
            }

            Console.WriteLine($"Result: {result}");

            // Ask user if they want to continue
            Console.WriteLine("Do you want to perform another calculation? (y/n): ");
            string choice = Console.ReadLine().ToLower();
            if (choice != "y")
            {
                keepRunning = false;
                Console.WriteLine("Thank you for using the calculator. Goodbye!");
            }

            Console.WriteLine(); // Empty line for spacing
        }

        // Wait for user to close window
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
