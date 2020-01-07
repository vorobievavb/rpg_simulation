using System;

namespace rpg_simulation
{
    public class Human : Race
    {
        public Human(Character characterIn, Character enemyIn,
                     int averageHp = (int)Stat.HumanHp,
                     int averageAgility = (int)Stat.HumanAgility,
                     int averageStrength = (int)Stat.HumanStrength)
            : base(characterIn, enemyIn, averageHp, averageAgility, averageStrength)
        {
            character.BeingAttackedEnd += Rage;
        }

        private bool isStrengthDouble;
        public void Rage()
        {
            if ((character.Hp < (character.baseHp * 0.25)) && !isStrengthDouble)
            {
                Console.WriteLine("They are enraged! Attack doubles.");
                Strength *= 2;
                isStrengthDouble = true;
            }
        }
    }
}
