using System;
using System.Collections.Generic;
using System.Text;

namespace rpg_simulation
{
    public class Mage : GameClass
    {
        public Mage(Character characterIn, Character enemyIn)
            : base(characterIn, enemyIn)
        {
            attackLine = "They throw a fireball. Very original.";
        }
        public void InstaKill()
        {
            var rand = new Random();
            if (rand.Next(1, 11) <= 1)
            {
                Console.WriteLine("INSTAKILL! {0} explodes the universe and wins.", character.name);
                enemy.Hp = 0;
            }
        }
    }
}
