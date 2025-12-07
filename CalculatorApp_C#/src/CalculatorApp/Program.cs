using System;

namespace CalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            string input;
            double num1, num2, result;
            string operation;

            Console.WriteLine("Welcome to the Calculator App!");
            Console.WriteLine("Enter 'exit' to close the application.");

            while (true)
            {
                Console.Write("Enter first number: ");
                input = Console.ReadLine();
                if (input.ToLower() == "exit") break;
                num1 = Convert.ToDouble(input);

                Console.Write("Enter an operation (+, -, *, /): ");
                operation = Console.ReadLine();
                if (operation.ToLower() == "exit") break;

                Console.Write("Enter second number: ");
                input = Console.ReadLine();
                if (input.ToLower() == "exit") break;
                num2 = Convert.ToDouble(input);

                switch (operation)
                {
                    case "+":
                        result = calculator.Add(num1, num2);
                        break;
                    case "-":
                        result = calculator.Subtract(num1, num2);
                        break;
                    case "*":
                        result = calculator.Multiply(num1, num2);
                        break;
                    case "/":
                        result = calculator.Divide(num1, num2);
                        break;
                    default:
                        Console.WriteLine("Invalid operation. Please try again.");
                        continue;
                }

                Console.WriteLine($"Result: {result}");
            }

            Console.WriteLine("Thank you for using the Calculator App!");
        }
    }
}