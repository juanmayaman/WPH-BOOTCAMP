namespace backendDay6
{
    internal class Program
    {
        public class Shape
        {
            public virtual void CalculateArea()
            {
                Console.WriteLine("Calculating the area of a shape...");
            }
        }

        public static class InputHelper
        {
            public static double ReadInput(string prompt)
            {
                double value;
                bool valid;
                do
                {
                    Console.Write(prompt);
                    valid = double.TryParse(Console.ReadLine(), out value) && value > 0;
                    if (!valid)
                    {
                        Console.WriteLine("Value must be a number greater than 0.");
                    }
                } while (!valid);

                return value;
            }
        }

        public class Circle : Shape
        {
            public override void CalculateArea()
            {
                Console.WriteLine("Calculating the area of a circle");
                double radius = InputHelper.ReadInput("Please enter the radius: ");
                double area = Math.Pow(radius, 2) * Math.PI;

                Console.WriteLine($"The area of a circle with a radius of {radius} is {area:F2}");
            }
        }

        public class Rectangle : Shape
        {
            public override void CalculateArea()
            {
                Console.WriteLine("Calculating the area of a rectangle");
                double length = InputHelper.ReadInput("Enter length: ");
                double width = InputHelper.ReadInput("Enter width: ");

                double area = length * width;
                Console.WriteLine($"The area of a rectangle with a lenght of {length} and width of {width} = {area:F2}");

            }
        }

        public class Square : Shape
        {
            public override void CalculateArea()
            {
                Console.WriteLine("Calculating the area of a square");
                double sides = InputHelper.ReadInput("Enter side: ");

                double area = sides * sides;
                Console.WriteLine($"The area of a square with a side of {sides} = {area:F2}");
            }
        }

        public class Triangle : Shape
        {
            public override void CalculateArea()
            {
                Console.WriteLine("Calculating the area of a triangle");
                double triangleBase = InputHelper.ReadInput("Enter base: ");
                double height = InputHelper.ReadInput("Enter height: ");

                double area = (triangleBase * height)/2;
                Console.WriteLine($"The area of a triangle with a base of {triangleBase} and height of {height} = {area:F2}");
            }
        }

        static void Main(string[] args)
        {
            int operation;
            bool valid;
            string useAgain;

            do
            {
                do
                {
                    Console.WriteLine("===========\t SHAPE AREA CALCULATOR! \t===========");
                    Console.WriteLine("Please Select a Shape!");
                    Console.WriteLine("1. Circle\n2. Rectangle\n3. Square\n4. Triangle\n5. Exit");
                    Console.Write("Type your option: ");
                    valid = int.TryParse(Console.ReadLine(), out operation) && operation > 0 && operation < 6;
                    if (!valid)
                    {
                        Console.WriteLine("Please select from the choices only.");
                    }
                } while (!valid);

                Shape shape = null;

                switch (operation)
                {
                    case 1:
                        shape = new Circle();
                        break;
                    case 2:
                        shape = new Rectangle();
                        break;
                    case 3:
                        shape = new Square();
                        break;
                    case 4:
                        shape = new Triangle();
                        break;
                    case 5:
                        Console.WriteLine("Exiting the program. Goodbye!");
                        return;
                }

                shape?.CalculateArea(); // checks if null pag hindi di priprint

                Console.Write("Do you want to calculate another shape area? (yes or no): ");
                useAgain = Console.ReadLine().ToLower();

            } while (useAgain == "yes");
        }
    }    
}
