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
            Player player = new Player();
            Console.WriteLine("Welcome to Game");
            Console.Write("Enter your Name: ");
            player.Name = Console.ReadLine();


            Game game = new Game(player.Name);//passed the name so magagamit siya sa game
            game.Play();
        }
    }
}
