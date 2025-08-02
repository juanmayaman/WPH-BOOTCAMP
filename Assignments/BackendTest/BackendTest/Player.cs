using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendTest
{
     class Player
    {
        public string Name { get; set; }
        public int Health { get; private set; }
        public int Potion { get; private set; } = 1;

        //removed/commented this part because I will be using the other method so I could use the playername.
        /*public Player()
        {
 
            Health = 6;
        }*/

        //adjusted the health since up to 3 lang daw
        public Player(string name)
        {
            Name = name;
            Health = 3;
        }

        public void TakeDamage()
        {
            Health -= 1;
            if (Health < 0) Health = 0;
        }

        public void PotionHeal()
        {
            if(Health > 0 && Potion == 1)
            {
                Console.WriteLine($"\n{Name} used a potion and healed 1 health point!");
                Health += 1;
                Potion--;
            }
            else if (Health <= 0 && Potion ==1) //if player is dead and has a potion left
            {   
                Random random = new Random();
                int heal = random.Next(1,3);//random generated 
                if(heal == 1)
                {
                    Health = 1; //revive player with 1 health point
                    Potion--;
                    Console.WriteLine($"\n{Name} has been revived with 1 health point!");
                }
                else
                {
                    Console.WriteLine($"\n{Name} failed to revive.");
                }
            }
            else
            {
                Console.WriteLine($"\n{Name} has no potions left to use.");
            }
        }
    }
}
