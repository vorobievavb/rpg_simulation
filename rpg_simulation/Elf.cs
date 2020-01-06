using System;
using System.Collections.Generic;
using System.Text;

namespace rpg_simulation
{
    public class Elf : Race
    {
        public Elf(int averageHp = (int)Stat.ElfHp,
                   int averageAgility = (int)Stat.ElfAgility,
                   int averageStrength = (int)Stat.ElfStrength)
            : base(averageHp, averageAgility, averageStrength) { }
        public override bool DoubleAttack()
        {
            var rand = new Random();
            if (rand.Next(1, 11) <= 3) return true;
            else return false;
        }
        public override void Rage() { }
    }
}
