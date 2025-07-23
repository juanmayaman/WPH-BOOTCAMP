namespace backendDay1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //data for string interpolation
            string firstName1 = "Deli";
            string lastName1 = "Cruz";
            int age1 = 25;
            double height1 = 5.3;
            bool isEnrolled1 = true;
            char grade1 = 'B';
            int subjects1 = 6;
            int totalScore1 = 522;

            //requirements
            double averageScore1 = (double)totalScore1 / subjects1;
            int ageIn10Years1 = age1 + 10;
            double halfScore1 = totalScore1 / 2.0;

            //outputs
            Console.WriteLine("=== Profile 1: Deli Cruz ===");
            Console.WriteLine($"Name: {firstName1} {lastName1}");
            Console.WriteLine($"Age: {age1}");
            Console.WriteLine($"Height: {height1} ft");
            Console.WriteLine($"Currently Enrolled: {isEnrolled1}");
            Console.WriteLine($"Grade Received: {grade1}");
            Console.WriteLine($"Subjects Taken: {subjects1}");
            Console.WriteLine($"Total Score: {totalScore1}");

            Console.WriteLine($"Average Score: {averageScore1}");
            Console.WriteLine($"Age after 10 years: {ageIn10Years1}");
            Console.WriteLine($"Half of Total Score: {halfScore1}");
            Console.WriteLine();

            //data for string conctenation
            string firstName2 = "Juan";
            string lastName2 = "Salcedo";
            int age2 = 25;
            double height2 = 5.7;
            bool isEnrolled2 = false;
            char grade2 = 'A';
            int subjects2 = 5;
            int totalScore2 = 475;

            double averageScore2 = (double)totalScore2 / subjects2;
            int ageIn10Years2 = age2 + 10;
            double halfScore2 = totalScore2 / 2.0;

            Console.WriteLine("=== Profile 2: Juan Salcedo ===");
            Console.WriteLine("Name: " + firstName2 + " " + lastName2);
            Console.WriteLine("Age: " + age2);
            Console.WriteLine("Height: " + height2 + " ft");
            Console.WriteLine("Currently Enrolled: " + isEnrolled2);
            Console.WriteLine("Grade Received: " + grade2);
            Console.WriteLine("Subjects Taken: " + subjects2);
            Console.WriteLine("Total Score: " + totalScore2);

            Console.WriteLine("Average Score: " + averageScore2);
            Console.WriteLine("Age after 10 years: " + ageIn10Years2);
            Console.WriteLine("Half of Total Score: " + halfScore2);

        }
    }
}
