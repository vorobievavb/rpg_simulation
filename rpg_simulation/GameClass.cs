using System;
using System.Collections.Generic;
using System.Text;

namespace rpg_simulation
{
    public abstract class GameClass
    {
        public string attackLine;
        protected GameClass() { }
        public abstract string GetClass();
        public abstract bool Parry();
        public abstract bool InstaKill();
    }
}
