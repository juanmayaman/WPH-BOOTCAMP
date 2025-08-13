using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendTest
{
    class Game
    {
        private Player player;
        private Player computer;
        private Random  random;

        public Game()
        {
            player = new Player();
            computer = new Player("Computer");
            random = new Random();
        }
        public Game(string playerName)
        {
            player = new Player(playerName);
            computer = new Player("Computer");
            random = new Random();
        }
        public void Play()
        {
            while (player.Health>0 && computer.Health > 0) 
            {
                Console.WriteLine("\nChoose your move:");
                Console.WriteLine("1. Rock (Press '1')");
                Console.WriteLine("2. Paper (Press '2')");
                Console.WriteLine("3. Scissors (Press '3')");
                Console.WriteLine("4. Use Potion (Press '4')");

                string playerinput = Console.ReadKey();
                string computerinput = random.Next(8);//random generated
       
       
                int result = checkwinner(playerinput, computerinput);

                if(result == 1) 
                {
             
                    Console.WriteLine($"{player.Name} won this turn!");
                    
                }
                else if (result == -1)
                {
     
                    Console.WriteLine($"computer won this turn!");

                }
         
                Console.WriteLine($"Remaining Health - {player.Name}: {player.Health}, Computer: {computer.Health}");

                

            }
            if (player.Health < 0)
            {
                Console.WriteLine($"\n{player.Name} Wins! Congratulations!");
            }
            else
            {
                Console.WriteLine("\nComputer Wins! Game over");
            }
        }
        private int checkwinner(char playinput, char cominput) 
        {
            return -1;
        }

    }
}
