using System;
using System.Collections.Generic;
using System.Text;

namespace rpg_simulation
{
    public class Warrior : GameClass
    {
        public Warrior() 
        {
            attackLine = "They swing a sword randomly and somehow hit the opponent."; 
        }
        public override string GetClass() 
        {
            return "Warrior"; 
        }
        public override bool Parry()
        {
            var rand = new Random();
            if (rand.Next(1, 11) <= 3) return true;
            else return false;
        }
        public override bool InstaKill() 
        {
            return false; 
        }
    }
}
