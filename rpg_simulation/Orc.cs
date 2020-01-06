using System;
using System.Collections.Generic;
using System.Text;

namespace rpg_simulation
{
    public class Orc : Race
    {
        public Orc(int averageHp = (int)Stat.OrcHp,
                   int averageAgility = (int)Stat.OrcAgility,
                   int averageStrength = (int)Stat.OrcStrength)
            : base(averageHp, averageAgility, averageStrength) { }
        public override bool DoubleAttack() { return false; }
        public override void Rage() { }
    }
}
