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

        /* Deleted/commented this part because I will be using the other method so I could use the playername.
        public Game()
        {
            player = new Player();
            computer = new Player("Computer");
            random = new Random();
        }*/
        public Game(string playerName)
        {
            player = new Player(playerName);
            computer = new Player("Computer");
            random = new Random();
        }
        public void Play()
        {
            //added variables for input validation
            bool valid;
            int value;

            while (player.Health>0 && computer.Health > 0) 
            {
                Console.WriteLine("\nChoose your move:");
                Console.WriteLine("1. Rock (Press '1')");
                Console.WriteLine("2. Paper (Press '2')");
                Console.WriteLine("3. Scissors (Press '3')");
                Console.WriteLine("4. Use Potion (Press '4')");

                //fixed the datatypes & added input validation
                do
                {
                    ConsoleKeyInfo playerinput = Console.ReadKey();
                    valid = (int.TryParse(playerinput.KeyChar.ToString(), out value) && value > 0 && value < 5);

                    if (!valid)
                    {
                        Console.WriteLine("\nInvalid choice. Please press 1, 2, 3, or 4.");
                    }
                   
                } while (!valid);


                int computerinput = random.Next(1,4);//random generated 
       
                    
                int result = checkwinner(value, computerinput);

                if(result == 1) 
                {
             
                    Console.WriteLine($"\n{player.Name} won this turn!");
                    
                }
                else if (result == -1)
                {
     
                    Console.WriteLine($"\ncomputer won this turn!");

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
        private int checkwinner(int playerChoice, int cominput) 
        {
            int p = playerChoice;
            int c = cominput;
          //1 rock
          //2 paper
          //3 scissors
            if((p == 1 && c == 3) || (p == 2 && c == 3) || (p == 3 && c == 2))
            {
                return -1;
            }

            return -1;
        }

    }
}
