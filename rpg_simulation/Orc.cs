using System;
using System.Collections.Generic;
using System.Text;

namespace rpg_simulation
{
    public class Orc : Race
    {
        public Orc(Character characterIn, Character enemyIn,
                   int averageHp = (int)Stat.OrcHp,
                   int averageAgility = (int)Stat.OrcAgility,
                   int averageStrength = (int)Stat.OrcStrength)
            : base(characterIn, enemyIn, averageHp, averageAgility, averageStrength) { }
    }
}
