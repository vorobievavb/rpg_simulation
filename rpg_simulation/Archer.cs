using System;
using System.Collections.Generic;
using System.Text;

namespace rpg_simulation
{
    public class Archer : GameClass
    {
        public bool IsSecondAttack;
        public Archer(Character characterIn, Character enemyIn)
            : base(characterIn, enemyIn)
        {
            attackLine = "They shoot an arrow. It penetrates the opponent's knee. " +
                         "They will no longer be an andenturer.";
        }

        public bool IsFirstAttack = true;
        public void FirstAttack()
        {
            if (IsFirstAttack && !IsSecondAttack)
            {
                IsFirstAttack = false;
                Console.WriteLine("{0} sneaks into battle and attacks twice!", character.name);
                character.Attack(enemy);
            }
        }

    }
}
