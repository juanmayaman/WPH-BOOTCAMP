using System;

namespace backendDay2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool useAgain = true;  
            int calculatorOption = 0;
            int continueUsing = 0;
            int confirmExit = 1;
            bool valid;

            do
            {
                valid = false;

                Console.WriteLine("---------\t Advance Calculator \t---------");
                Console.WriteLine("1. Basic Calculator");
                Console.WriteLine("2. Continuous Calculator");
                Console.WriteLine("3. Scientific Calculator");
                Console.WriteLine("4. Exit");
                Console.Write("Please select an option: ");

                while (!valid)
                {
                    if (!int.TryParse(Console.ReadLine(), out calculatorOption) || calculatorOption < 1 || calculatorOption > 4)
                    {
                        Console.Write("Invalid input. Please enter a number from 1 to 4: ");
                    }
                    else
                    {
                        valid = true;
                    }
                }

                switch (calculatorOption)
                {
                    case 1:
                        do
                        {
                            Console.WriteLine("\nWelcome to the Basic Calculator!");
                            double num1 = 0, num2 = 0;
                            char operation;
                            valid = false;
                            continueUsing = 0;

                            while (!valid)
                            {
                                Console.Write("Enter first number: ");
                                if (double.TryParse(Console.ReadLine(), out num1))
                                    valid = true;
                                else
                                    Console.WriteLine("Invalid input. Try again.");
                            }

                            valid = false;
                            while (!valid)
                            {
                                Console.Write("Enter second number: ");
                                if (double.TryParse(Console.ReadLine(), out num2))
                                    valid = true;
                                else
                                    Console.WriteLine("Invalid input. Try again.");
                            }

                            Console.Write("Choose operation (+, -, *, /): ");
                            operation = Console.ReadKey().KeyChar;
                            Console.WriteLine();

                            switch (operation)
                            {
                                case '+':
                                    Console.WriteLine($"Result: {num1 + num2}");
                                    break;
                                case '-':
                                    Console.WriteLine($"Result: {num1 - num2}");
                                    break;
                                case '*':
                                    Console.WriteLine($"Result: {num1 * num2}");
                                    break;
                                case '/':
                                    if (num2 != 0)
                                        Console.WriteLine($"Result: {num1 / num2}");
                                    else
                                        Console.WriteLine("❌ Cannot divide by zero.");
                                    break;
                                default:
                                    Console.WriteLine("❌ Invalid operation.");
                                    break;
                            }

                            // Ask to continue
                            Console.Write("Do you want to calculate again? Type 1 for YES, 0 for NO: ");
                            while (!int.TryParse(Console.ReadLine(), out continueUsing) || (continueUsing != 0 && continueUsing != 1))
                            {
                                Console.Write("Invalid input. Please enter 1 or 0: ");
                            }

                        } while (continueUsing == 1);

                        Console.WriteLine("\nThank you for using the Basic Calculator!\n");

                        useAgain = true; 
                        break;

                    case 2:
                        do
                        {
                            double num1 = 0, num2 = 0;
                            valid = false;
                            continueUsing = 0;
                            int count = 0; 

                            Console.WriteLine("Welcome to the Continuous Calculator!");
                            Console.WriteLine("In this calculator you can continuously perform basic math operations and input number!");
                            while (!valid)
                            {
                                Console.Write("Enter first number: ");
                                if (double.TryParse(Console.ReadLine(), out num1))
                                    valid = true;
                                else
                                    Console.WriteLine("Invalid input. Try again.");
                            }

                            while(count < 10)
                            {
                                Console.Write("\nEnter an operation (+, -, *, /) or type 'exit' to stop: ");
                                string operation = Console.ReadLine().Trim().ToLower();

                                if (operation == "exit")
                                {
                                    Console.WriteLine("Exiting Continuous Calculator.");
                                    break;
                                }

                                valid = false;
                                while (!valid)
                                {
                                    Console.Write("Enter next number: ");
                                    if (double.TryParse(Console.ReadLine(), out num2))
                                        valid = true;
                                    else
                                        Console.WriteLine("Invalid input. Try again.");
                                }

                                switch (operation)
                                {
                                    case "+":
                                        num1 += num2;
                                        Console.WriteLine($"Result: {num1}");
                                        break;
                                    case "-":
                                        num1 -= num2;
                                        Console.WriteLine($"Result: {num1}");
                                        break;
                                    case "*":
                                        num1 *= num2;
                                        Console.WriteLine($"Result: {num1}");
                                        break;
                                    case "/":
                                        if (num2 != 0)
                                        {
                                            num1 /= num2;
                                            Console.WriteLine($"Result: {num1}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("❌ Cannot divide by zero.");
                                            continue; 
                                        }
                                        break;
                                    default:
                                        Console.WriteLine("❌ Invalid operation.");
                                        continue; 
                                }
                                Console.WriteLine($"Current Result: {num1}");
                                count++;
                            }

                            Console.Write("Do you want to calculate again? Type 1 for YES, 0 for NO: ");
                            while (!int.TryParse(Console.ReadLine(), out continueUsing) || (continueUsing != 0 && continueUsing != 1))
                            {
                                Console.Write("Invalid input. Please enter 1 or 0: ");
                            }

                        } while (continueUsing == 1);

                        Console.WriteLine("\nThank you for using the Continuous Calculator!\n");
                        useAgain = true;
                        break;

                    case 3:
                        do {
                            valid = false;
                            continueUsing = 0;
                            double num1 = 0, num2 = 0;
                            double inputNumber = 0;
                            string[] operations = { "add", "subtract", "multiply", "divide", "square", "cube", "sqrt" };
                            Console.WriteLine("\nWelcome to Scientific Calculator!");
                            Console.WriteLine("Available Operations:");
                            foreach (string op in operations)
                            {
                                Console.WriteLine("- "+ op);
                            }
                            Console.Write("Enter the operation you want to perform: ");
                            string selectedOperation = Console.ReadLine().ToLower();

                            switch (selectedOperation)
                            {
                                case "add":
                                    valid = false;
                                    while (!valid)
                                    {
                                        Console.Write("Enter first number: ");
                                        if (double.TryParse(Console.ReadLine(), out num1))
                                            valid = true;
                                        else
                                            Console.WriteLine("Invalid input. Try again.");
                                    }

                                    valid = false;
                                    while (!valid)
                                    {
                                        Console.Write("Enter second number: ");
                                        if (double.TryParse(Console.ReadLine(), out num2))
                                            valid = true;
                                        else
                                            Console.WriteLine("Invalid input. Try again.");
                                    }
                                    Console.WriteLine($"Result: {num1 + num2}");
                                    break;
                                case "subtract":
                                    valid = false;
                                    while (!valid)
                                    {
                                        Console.Write("Enter first number: ");
                                        if (double.TryParse(Console.ReadLine(), out num1))
                                            valid = true;
                                        else
                                            Console.WriteLine("Invalid input. Try again.");
                                    }

                                    valid = false;
                                    while (!valid)
                                    {
                                        Console.Write("Enter second number: ");
                                        if (double.TryParse(Console.ReadLine(), out num2))
                                            valid = true;
                                        else
                                            Console.WriteLine("Invalid input. Try again.");
                                    }
                                    Console.WriteLine($"Result: {num1 - num2}");
                                    break;
                                case "multiply":
                                    valid = false;
                                    while (!valid)
                                    {
                                        Console.Write("Enter first number: ");
                                        if (double.TryParse(Console.ReadLine(), out num1))
                                            valid = true;
                                        else
                                            Console.WriteLine("Invalid input. Try again.");
                                    }

                                    valid = false;
                                    while (!valid)
                                    {
                                        Console.Write("Enter second number: ");
                                        if (double.TryParse(Console.ReadLine(), out num2))
                                            valid = true;
                                        else
                                            Console.WriteLine("Invalid input. Try again.");
                                    }
                                    Console.WriteLine($"Result: {num1 * num2}");
                                    break;
                                case "divide":
                                    valid = false;
                                    while (!valid)
                                    {
                                        Console.Write("Enter first number: ");
                                        if (double.TryParse(Console.ReadLine(), out num1))
                                            valid = true;
                                        else
                                            Console.WriteLine("Invalid input. Try again.");
                                    }

                                    valid = false;
                                    while (!valid)
                                    {
                                        Console.Write("Enter second number: ");
                                        if (double.TryParse(Console.ReadLine(), out num2))
                                            valid = true;
                                        else
                                            Console.WriteLine("Invalid input. Try again.");
                                    }
                                    if (num2 != 0)
                                        Console.WriteLine($"Result: {num1 / num2}");
                                    else
                                        Console.WriteLine("❌ Cannot divide by zero.");
                                    break;
                                case "square":
                                    valid = false;
                                    while (!valid)
                                    {
                                        Console.Write("Enter a number: ");
                                        if (double.TryParse(Console.ReadLine(), out inputNumber))
                                            valid = true;
                                        else
                                            Console.WriteLine("Invalid input. Please enter a valid number.");
                                    }
                                    Console.WriteLine($"Result: {inputNumber}² = {Math.Pow(inputNumber, 2)}");
                                    break;
                                case "cube":
                                    valid = false;
                                    while (!valid)
                                    {
                                        Console.Write("Enter a number: ");
                                        if (double.TryParse(Console.ReadLine(), out inputNumber))
                                            valid = true;
                                        else
                                            Console.WriteLine("Invalid input. Please enter a valid number.");
                                    }
                                    Console.WriteLine($"Result: {inputNumber}^3 = {Math.Pow(inputNumber, 3)}");

                                    break;
                                case "sqrt":
                                    valid = false;
                                    while (!valid)
                                    {
                                        Console.Write("Enter a number: ");
                                        if (double.TryParse(Console.ReadLine(), out inputNumber))
                                            valid = true;
                                        else
                                            Console.WriteLine("Invalid input. Please enter a valid number.");
                                    }
                                    if (inputNumber >= 0)
                                        Console.WriteLine($"Result: √{inputNumber} = {Math.Sqrt(inputNumber)}");
                                    else
                                        Console.WriteLine("❌ Cannot compute square root of a negative number.");
                                    break;
                                default:
                                    Console.WriteLine("❌ Invalid scientific operation.");
                                    break;
                            }



                            Console.Write("Do you want to calculate again? Type 1 for YES, 0 for NO: ");
                            while (!int.TryParse(Console.ReadLine(), out continueUsing) || (continueUsing != 0 && continueUsing != 1))
                            {
                                Console.Write("Invalid input. Please enter 1 or 0: ");
                            }

                        } while (continueUsing == 1);

                        Console.WriteLine("\nThank you for using the Scientific Calculator!\n");
                        useAgain = true;
                        break;

                    case 4:
                        Console.Write("Are you sure you want to exit Advance Calculator? Type 1 for YES and 0 for NO: ");
                        while (!int.TryParse(Console.ReadLine(), out confirmExit) || (confirmExit != 0 && confirmExit != 1))
                        {
                            Console.Write("Invalid input. Please enter 1 or 0: ");
                        }

                        if (confirmExit == 1)
                        {
                            Console.WriteLine("Thank you for using Advance Calculator!");
                            useAgain = false;
                        }
                        else
                        {
                            useAgain = true;
                        }
                        break;

                    default:
                        Console.WriteLine("Please choose a valid option :)");
                        useAgain = true;
                        break;
                }

                Console.WriteLine();
            } while (useAgain);
        }
    }
}
