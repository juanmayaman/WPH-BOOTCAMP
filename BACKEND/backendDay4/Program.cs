using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace backendDay4
{
    public class Employee
    {
        private string empName;
        private int empAge;
        private string empDepartment;
        private double empSalary;
        private int empYearHired;
        
        public string EmpName
        {
            get { return empName; }
            set {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    empName = value;
                }else
                {
                    throw new ArgumentException("Invalid name. It cannot be empty");
                }
            }
        }

        public int EmpAge
        {
            get { return empAge; }
            set
            {
                if (value < 18 || value > 70)
                {
                    throw new ArgumentException("We do not have employees under 18 or over 70");
                }
                else
                {
                    empAge = value;
                }
            }
        }

        public string EmpDepartment
        {
            get { return empDepartment; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    empDepartment = value;
                }
                else
                {
                    throw new ArgumentException("Invalid department. It cannot be empty");
                }
            }
        }

        public double EmpSalary
        {
            get { return empSalary; }
            set
            {
                if(value >= 15000)
                {
                    empSalary = value;
                }
                else
                {
                    throw new ArgumentException("Salary cannot be less than 15,000");
                }
            }
        }

        public int EmpYearHired
        {
            get { return empYearHired; }
            set {
                int currentYear = DateTime.Now.Year;
                if (value >= 1990 && value <= currentYear)
                {
                    empYearHired = value;
                }
                else
                {
                    throw new ArgumentException("Invalid hire year.");
                }
                    
            }
        }

        public int EmpTotalYears
        {
            get { return DateTime.Now.Year - empYearHired; }
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Name\tAge\tDepartment\tSalary\tYear Hired\tTotal Years Working");
            Console.WriteLine($"{empName}\t{empAge}\t{empDepartment}\t\t{empSalary}\t{empYearHired}\t\t{EmpTotalYears}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emp1 = new Employee();
            Employee emp2 = new Employee();

            Employee[] employees = { emp1, emp2 };

            for(int i = 0; i < 2; i++)
            {
                string inputName;
                do
                {
                    Console.Write("Please enter the employee #" + (i + 1) + " name: ");
                    inputName = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(inputName));
                employees[i].EmpName = inputName;

                int age;
                do
                {
                    Console.Write("Please enter the employee #" + (i + 1) + " age (18 to 70): ");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out age) && age >= 18 && age <= 70)
                    {
                        employees[i].EmpAge = age;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid age. Please enter a number between 18 and 70.");
                    }
                } while (true);

                string dept;
                do
                {
                    Console.Write("Please enter the employee #" + (i + 1) + " depertment: ");
                    dept = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(dept));
                employees[i].EmpDepartment = dept;

                double salary;
                do
                {
                    Console.Write("Please enter the employee #" + (i + 1) + " salary: ");
                    string input = Console.ReadLine();

                    if (double.TryParse(input, out salary) && salary >= 15000)
                    {
                        employees[i].EmpSalary = salary;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid amout!");
                    }
                } while (true);

                int years;
                do
                {
                    Console.Write("Please enter the employee #" + (i + 1) + " hire year: ");
                    string input = Console.ReadLine();
                    int currentYear = DateTime.Now.Year;
                   
                    if (int.TryParse(input, out years) && years >= 1990 && years <= currentYear)
                    {
                        employees[i].EmpYearHired = years;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid year. Please enter a year hired between 1990 and current year");
                    }
                } while (true);
            }

            Console.WriteLine("----------\t Employee Information System \t---------- ");
            foreach(Employee emp in employees) {

                emp.DisplayInfo();
                Console.WriteLine();
            }
            //code pang update salary ni employee 1 
            Console.WriteLine("\nUpdating salary for Employee #1");
            double newSalary;
            do
            {
                Console.Write("Enter new salary: ");
                string input = Console.ReadLine();
                if (double.TryParse(input, out newSalary) && newSalary >= 15000)
                {
                    emp1.EmpSalary = newSalary;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid amount. Must be at least 15,000.");
                }
            } while (true);

            Console.WriteLine("\nUpdated Employee #1 Info:");
            emp1.DisplayInfo();
        }
    }
}
