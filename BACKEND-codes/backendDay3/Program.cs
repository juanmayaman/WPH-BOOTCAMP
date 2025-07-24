using System;

namespace backendDay3
{
    class Student
    {
        public string name;
        public int age;
        public string academicGrade;

        public void displayDetails()
        {
            Console.WriteLine("Name\tAge\tAcademic Grade");
            Console.WriteLine(name + "\t" + age + "\t" + academicGrade); 
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            bool valid;
            Student student1 = new Student();
            Student student2 = new Student();

            Student[] students = { student1, student2 };

            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine($"\nEnter the details of Student #{i + 1}");

                Console.Write("Name: ");
                students[i].name = Console.ReadLine();

                valid = false;
                while (!valid)
                {
                    Console.Write("Age: ");
                    if (int.TryParse(Console.ReadLine(), out students[i].age))
                        valid = true;
                    else
                        Console.WriteLine("Please insert a valid input. Try again");
                }

                Console.Write("Academic Grade/Level: ");
                students[i].academicGrade =Console.ReadLine();
            }

            Console.WriteLine("\n--- Student Information ---");
            foreach (Student s in students)
            {
                s.displayDetails();
                Console.WriteLine();
            }
        }
    }
}
