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

            Player player = new Player();
            Console.WriteLine("Welcome to Game");
            do
            {
                Console.Write("Enter your Name: ");
                name = Console.ReadLine();
                valid = name.All(char.IsLetter);

                if (valid)
                {
                    player.Name = name;
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Please enter alphabetical letters only.");
                    valid = false;
                }

            } while (!valid);
    
            Game game = new Game(player.Name);//passed the name so magagamit siya sa game
            game.Play();
        }
    }
}
