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

                }else if (result == 0)
                {
                    Console.WriteLine("\nIt's a tie! No damage taken.");
                }
                else if (result == 4) 
                {

                    Console.WriteLine($"\n{player.Name} used a potion and healed 1 health point!");
                }

                Console.WriteLine($"Remaining Health - {player.Name}: {player.Health}, Computer: {computer.Health}");

                

            }

            if(player.Health <= 0 && player.Potion == 1)
            {
                player.PotionHeal();
            }
            else if (computer.Health <= 0)
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
            //1 rock
            //2 paper
            //3 scissors
            int p = playerChoice;
            int c = cominput;

            //added a condition for potion
            if (p == 4)
            {
                player.PotionHeal();
                ShowPicked(p, player.Name);
                return 4; //return 4 if player used potion
            }
            else
            {
                ShowPicked(p, player.Name);
                ShowPicked(c, computer.Name);
            }

            //player wins
            if((p == 1 && c == 3) || (p == 2 && c == 1) || (p == 3 && c == 2))
            {
                computer.TakeDamage();
                return 1;
            }else if((c == 1 && p == 3) || (c == 2 && c == 3) || (c == 3 && p == 2)) //computer wins
            {
                player.TakeDamage();
                return -1;
            }else if((p == 1 && c == 1) || (p == 2 && c == 2) || (p == 3 && c == 3)) //player tie
            {
                return 0; 
            }
                return -1;
        }

        //added a method to show the chocie
        public static void ShowPicked(int choice, string name)
        {
            if(choice == 1)
            {
                Console.WriteLine($"\n{name} picked ROCK!");
            } else if(choice == 2)
            {
                Console.WriteLine($"\n{name} picked PAPER!");
            }else if(choice == 3)
            {
                Console.WriteLine($"\n{name} picked SCISSORS!");
            }else if(choice == 4){
                Console.WriteLine($"\n{name} picked POTION!");
            }
        }
    }
}
