using System;
using System.Collections.Generic;
using System.Text;

namespace rpg_simulation
{
    public class Human : Race
    {
        public readonly int baseHp;
        public Human(int averageHp = (int)Stat.HumanHp,
                     int averageAgility = (int)Stat.HumanAgility,
                     int averageStrength = (int)Stat.HumanStrength)
            : base(averageHp, averageAgility, averageStrength)
        {
            baseHp = Hp;
        }

        private bool isStrengthDouble;
        public override void Rage()
        {
            if (Hp < baseHp * 0.25 && !isStrengthDouble)
            {
                Console.WriteLine("They are enraged! Attack doubles.");
                Strength *= 2;
                isStrengthDouble = true;
            }
        }
        public override bool DoubleAttack() 
        {
            return false;
        }
    }
}
