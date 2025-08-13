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

        public Player()
        {
 
            Health = 6;
        }

        public Player(string name)
        {
            Name = name;
            Health = 5;
        }


    }
}
