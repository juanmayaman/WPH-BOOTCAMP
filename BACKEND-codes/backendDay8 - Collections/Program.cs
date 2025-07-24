using System.Collections.Generic;
using System.Net.Mail;
using static backendDay8___Collections_student_management.Program;

namespace backendDay8___Collections_student_management
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
            public static string CheckString(string prompt) //check kung empty space ba
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
                            throw new ArgumentException("Invalid input. It cannot be empty.");
                        }
                        //dapat walang number sa name or sa string like sa program
                        if (value.Any(char.IsDigit))
                        {
                            throw new ArgumentException("Invalid input. Name cannot contain numbers.");
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
            public static string CheckStudID(string prompt)
            {
                string value = "";
                bool valid = false;

                do
                {
                    try
                    {
                        Console.WriteLine(prompt);
                        value = Console.ReadLine();

                        //limited to 5 digits lang and dapat numbers lnag siya.
                        if (string.IsNullOrWhiteSpace(value) || value.Length != 5 || !value.All(char.IsDigit))
                        {
                            throw new ArgumentException("Invalid Student ID. It must be exactly 5 digits (e.g., 01234).");
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

            public static string ConfirmationInput(string prompt)
            {
                Console.WriteLine(prompt);
                string value = Console.ReadLine().Trim().ToLower();
                while(value != "yes" || value != "no")
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
            private string studID;
            private int age;
            private string program;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public string StudID
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

        public class ManageStudent
        {
            public static void AddStudent(List<Student> students)
            {
                string useAgain = "no";
                do
                {
                    Student student = new Student();
                    student.Name = InputHelper.CheckString("Enter student name: ");
                    student.StudID = InputHelper.CheckStudID("Enter student ID (ex: 00102): ");
                    student.Age = InputHelper.CheckAge("Enter age (18 - 40): ");
                    student.Program = InputHelper.CheckString("Enter course/program (ex: BSCS): ").ToUpper();

                    students.Add(student);

                    Console.Write("Add another student? (yes/no): ");
                    useAgain = Console.ReadLine()?.Trim().ToLower();
                } while (useAgain == "yes");
            }

            public static void DisplayAllStudents(List<Student> students)
            {
                if (students.Count == 0)
                {
                    Console.WriteLine("No student records found.");
                    return;
                }

                Console.WriteLine("\n--- All Student Records ---");
                foreach (Student student in students)
                {
                    Console.WriteLine($"Name: {student.Name}");
                    Console.WriteLine($"Student ID: {student.StudID}");
                    Console.WriteLine($"Age: {student.Age}");
                    Console.WriteLine($"Program: {student.Program}");
                    Console.WriteLine("---------------------------");
                }
            }

            public static void EditStudent(List<Student> students)
            {
                string tempID = InputHelper.CheckStudID("Please insert student ID to edit: ");
                bool found = false;

                foreach (Student student in students)
                {
                    if (string.Equals(student.StudID, tempID, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("\n--- Current Student Information ---");
                        Console.WriteLine($"Name: {student.Name}");
                        Console.WriteLine($"Student ID: {student.StudID}");
                        Console.WriteLine($"Age: {student.Age}");
                        Console.WriteLine($"Program: {student.Program}");

                        Console.WriteLine("\n--- Enter New Information ---");

                        student.Name = InputHelper.CheckString("Enter new name: ");
                        student.Age = InputHelper.CheckAge("Enter new age (18-40): ");
                        student.Program = InputHelper.CheckString("Enter new program: ").ToUpper();

                        Console.WriteLine("Student information updated successfully.");
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("Student with the given ID was not found.");
                }
            }

            public static void DisplayStudent(List<Student> students)
            {
                string tempID = InputHelper.CheckStudID("Please insert student ID to display: ");
                bool found = false;

                foreach (Student student in students)
                {
                    if (string.Equals(student.StudID, tempID, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("\n--- Current Student Information ---");
                        Console.WriteLine($"Name: {student.Name}");
                        Console.WriteLine($"Student ID: {student.StudID}");
                        Console.WriteLine($"Age: {student.Age}");
                        Console.WriteLine($"Program: {student.Program}");

                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("Student with the given ID was not found.");
                }
            }

            public static void DeleteStudent(List<Student> students)
            {
                string tempID = InputHelper.CheckStudID("Please insert student ID to edit: ");
                bool found = false;
                string confirm = "";

                for (int i = 0; i < students.Count; i++)
                {
                    if (string.Equals(students[i].StudID, tempID, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("\n--- Current Student Information ---");
                        Console.WriteLine($"Name: {students[i].Name}");
                        Console.WriteLine($"Student ID: {students[i].StudID}");
                        Console.WriteLine($"Age: {students[i].Age}");
                        Console.WriteLine($"Program: {students[i].Program}");

                        confirm = InputHelper.ConfirmationInput("\nDo you want to delete this student?(yes/no): ");

                        if(confirm == "yes")
                        {
                            students.RemoveAt(i);
                            Console.WriteLine("Student removed successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Operation canceled.");
                        }
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("Student with the given ID was not found.");
                }
            }

        }

        static void Main(string[] args)
        {
            string useAgain = "no";
            int operation;

            List<Student> students = new List<Student>(); //gumamit ng list since di pwedeng array kase fixed sized siya and mas madali mag or delete here

            do
            {
                Console.WriteLine("--------\t Student Management System\t--------");
                Console.WriteLine("1. Add Student Information\n2. Display All Student Records\n3. Edit Student\n4. Display a Student\n5. Remove Student\n6. Exit");
                operation = InputHelper.CheckMenu("Please select an operation (1 - 6): ");

                switch (operation)
                {
                    case 1:
                        ManageStudent.AddStudent(students);
                        break;
                    case 2:
                        ManageStudent.DisplayAllStudents(students);
                        break;
                    case 3:
                        ManageStudent.EditStudent(students);
                        break;
                    case 4:
                        ManageStudent.DisplayStudent(students);
                        break;
                    case 5:
                        ManageStudent.DeleteStudent(students);
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
