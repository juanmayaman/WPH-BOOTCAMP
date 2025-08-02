using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendTest
{
    enum choice
    {
        rock = 1, paper, scissos, potion
    }
     class Program
    {
        static void Main(string[] args)
        {
            bool valid;
            string name;

            //remove the temp player for program simplicity lang po
            
            Console.WriteLine("Welcome to Game");
            do
            {
                Console.Write("Enter your Name: ");
                name = Console.ReadLine();
                valid = name.All(char.IsLetter);

                if (!valid)
                {
                    Console.WriteLine("Please enter alphabetical letters only.");
                }

            } while (!valid);

            Game game = new Game(name);
            game.Play();
        }
    }
}
