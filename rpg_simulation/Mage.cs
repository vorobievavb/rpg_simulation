using System;
using System.Collections.Generic;
using System.Text;

namespace rpg_simulation
{
    public class Mage : GameClass
    {
        public Mage() 
        {
            attackLine = "They throw a fireball. Very original.";
        }
        public override string GetClass() 
        {
            return "Mage";
        }
        public override bool InstaKill()
        {
            var rand = new Random();
            if (rand.Next(1, 11) <= 1) return true;
            else return false;
        }
        public override bool Parry() 
        { 
            return false; 
        }
    }
}
