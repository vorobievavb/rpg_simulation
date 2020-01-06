using System;
using System.Collections.Generic;
using System.Text;

namespace rpg_simulation
{
    public class Archer : GameClass
    {
        public Archer()
        {
            attackLine = "They shoot an arrow. It penetrates the opponent's knee. " +
                         "They will no longer be an andenturer.";
        }
        public override string GetClass() { return "Archer"; }
        public override bool Parry() { return false; }
        public override bool InstaKill() { return false; }
    }
}
