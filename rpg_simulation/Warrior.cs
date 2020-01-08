using System;

namespace rpg_simulation
{
    public class Warrior : GameClass
    {
        public Warrior(Character characterIn, Character enemyIn)
            : base(characterIn, enemyIn)
        {
            attackLine = "They swing a sword randomly an attempt to hit the opponent.";
            character.BeingAttackedStart += Parry;
        }

        public void Parry(bool isPerry = false)
        {
            var rand = new Random();
            if ((rand.Next(1, 11) <= 3) && !isPerry && !HasDodged)
            {
                Console.WriteLine("{0} perries!", character.name);
                enemy.GetAttacked(enemy.Strength, true);
                HasParried = true;
            }
            character.SetHasPerried(HasParried);
        }
    }
}
