namespace backendDay8___Collections_non___generic_
{
    internal class Program
    {
        public class InputHelper
        {
            public static int CheckMenu(string prompt) //method pang check if tama ba yung operation na pinili
            {
                int value = 0;
                bool valid = false;
                do
                {
                    try
                    {
                        Console.WriteLine(prompt);
                        string input = Console.ReadLine();

                        if (!int.TryParse(input, out value) || value < 1 || value > 6)
                        {
                            throw new ArgumentException("Invalid operation. Must be between 1 and 6");
                        }

                        valid = true;
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                } while (!valid);

                return value;
            }

            public static int CheckAge(string prompt)//eto naman sa age
            {
                int value = 0;
                bool valid = false;
                do
                {
                    try
                    {
                        Console.WriteLine(prompt);
                        string input = Console.ReadLine();

                        if (!int.TryParse(input, out value) || value < 18 || value > 40)
                        {
                            throw new ArgumentException("Invalid age. Must be between 18 and 40.");
                        }

                        valid = true;
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                } while (!valid);

                return value;
            }

            public static string CheckStringInput(string prompt)//eto sa string kung empty ba
            {
                bool valid = false;
                string value = "";

                do
                {
                    try
                    {
                        Console.WriteLine(prompt);
                        value = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(value))
                        {
                            throw new ArgumentException("Name cannot be empty.");
                        }
                        valid = true;
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                } while (!valid);

                return value;
            }

            public static string ConfirmationInput(string prompt)
            {
                Console.WriteLine(prompt);
                string value = Console.ReadLine().Trim().ToLower();
                while(value == "yes" || value == "no")
                {
                    Console.WriteLine($"Invalid input.{prompt}");
                    value = Console.ReadLine().Trim().ToLower();
                }

                return value;
            }
        }
        public class Student
        {
            private string name;
            private int studID;
            private int age;
            private string program;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public int StudID
            {
                get { return studID; }
                set { studID = value; } 
            }

            public int Age
            {
                get { return age; }
                set { age = value; }
            }

            public string Program
            {
                get { return program; }
                set { program = value; }
            }
        }

        static void Main(string[] args)
        {
            string useAgain;
            int operation;

            do
            {
                Console.WriteLine("--------\t Student Management System\t--------");
                Console.WriteLine("1. Add Student Information\n2. Display All Student Records\n3. Edit Student\n4. Display a Student\n5. Remove Student\n6. Exit");
                operation = InputHelper.CheckMenu("Please select an operation (1 - 6): ");

                switch (operation)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        useAgain = InputHelper.ConfirmationInput("Are you sure you want to exit? ('yes' / 'no'): ");
                        break;
                    default:
                        Console.WriteLine("Invalid operation selected. Please try again.");
                        break;
                }

                useAgain = InputHelper.ConfirmationInput("Do you want to perform another operation?('yes' / 'no'): ");

            } while (useAgain == "yes");
        }
    }
}
