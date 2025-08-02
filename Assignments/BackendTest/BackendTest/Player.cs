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
        public int Potion { get; private set; }

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
            /*int potion = 1;
            if(Health > 0 && po)
            {
            }*/
        }
    }
}
