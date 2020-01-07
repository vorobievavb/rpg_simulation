using System;
using System.Collections.Generic;
using System.Text;

namespace rpg_simulation
{
    public class Archer : GameClass
    {
        public Archer(Character characterIn, Character enemyIn)
            : base(characterIn, enemyIn)
        {
            attackLine = "They shoot an arrow. It penetrates the opponent's knee. " +
                         "They will no longer be an andenturer.";
        }

        public bool IsFirstAttack = true;
        private bool IsSecondAttack = false;
        public void FirstAttack()
        {
            if (IsFirstAttack && !IsSecondAttack)
            {
                IsFirstAttack = false;
                IsSecondAttack = true;
                Console.WriteLine("{0} sneaks into battle and attacks twice!", character.name);
                character.Attack(enemy);
            }
        }

    }
}
