using System;

namespace rpg_simulation
{
    public class Archer : GameClass
    {
        public Archer(Character characterIn, Character enemyIn)
            : base(characterIn, enemyIn)
        {
            attackLine = "They shoot an arrow. It aim for the opponent's knee. " +
                         "They will no longer be an andenturer.";
            character.AttackingEnd += FirstAttack;
        }

        private bool isSecondAttack = false;
        public void FirstAttack()
        {
            if (isFirstEverAttack && !isSecondAttack)
            {
                isFirstEverAttack = false;
                isSecondAttack = true;
                Console.WriteLine("{0} sneaks into battle and attacks twice!", character.name);
                character.Attack(enemy);
            }
        }

    }
}
