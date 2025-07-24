using System;

namespace backendDay7
{

    public class CustomDivideByZeroException : Exception
    {
        public CustomDivideByZeroException(string message) : base(message) { }
    }

    internal class Program
    {
        public class InputHelper
        {
            public static int CheckInput(string prompt)
            {
                int value;
                bool valid;
                do
                {
                    Console.Write(prompt);
                    valid = int.TryParse(Console.ReadLine(), out value);
                    if (!valid)
                    {
                        Console.WriteLine("Please input a valid integer.");
                    }
                } while (!valid);
                return value;
            }
        }

        public class ProcessNumbers
        {
            public static void DivideNumbers(int numerator, int divisor)
            {
                if (divisor == 0)
                {
                    throw new CustomDivideByZeroException("Error: Division by zero is not allowed.");
                }

                int quotient = numerator / divisor;
                int remainder = numerator % divisor;

                Console.WriteLine($"\nResult:");
                Console.WriteLine($"Quotient: {quotient}");
                if (remainder != 0)
                {
                    Console.WriteLine($"Remainder: {remainder}");
                }
            }
        }

        static void Main(string[] args)
        {
            int successCount = 0;
            int failCount = 0;
            string useAgain;

            do
            {
                Console.WriteLine("\n=======\tDIVISION PROGRAM\t=======");
                try
                {
                    int numerator = InputHelper.CheckInput("Enter numerator (integer): ");
                    int divisor = InputHelper.CheckInput("Enter divisor (integer): ");
                    ProcessNumbers.DivideNumbers(numerator, divisor);
                    successCount++;
                }
                catch (CustomDivideByZeroException ex)
                {
                    Console.WriteLine(ex.Message);
                    failCount++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An unexpected error occurred: " + ex.Message);
                    failCount++;
                }

                Console.Write("\nDo you want to divide another set of numbers? (yes/no): ");
                useAgain = Console.ReadLine()?.Trim().ToLower();

                while (useAgain != "yes" && useAgain != "no")
                {
                    Console.Write("Invalid input. Please type 'yes' or 'no': ");
                    useAgain = Console.ReadLine()?.Trim().ToLower();
                }

            } while (useAgain == "yes");

            Console.WriteLine($"\nSummary:");
            Console.WriteLine($"Successful attempts: {successCount}");
            Console.WriteLine($"Failed attempts: {failCount}");
            Console.WriteLine("Thank you for using the division program!");
        }
    }
}
