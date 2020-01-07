using System;

namespace rpg_simulation
{
    public abstract class Race
    {
        public int Hp { get; set; }
        public int Agility { get; set; }
        public int Strength { get; set; }

        protected Character character, enemy;
        protected Race(Character characterIn, Character enemyIn, int averageHp, int averageAgility, int averageStrength)
        {
            var rand = new Random();
            Hp = rand.Next(50, 151) * averageHp / 100;
            Agility = rand.Next(50, 151) * averageAgility / 100;
            Strength = rand.Next(50, 151) * averageStrength / 100;
            character = characterIn;
            enemy = enemyIn;
            character.BeingAttacked += Dodge;
        }

        public void DisplayStat()
        {
            Console.WriteLine("health: {0}, agility: {1}, strength: {2}.", Hp, Agility, Strength);
        }

        public bool HasDodged;
        public bool IsSecondAttack;

        public void Dodge()
        {
            var rand = new Random();
            if (rand.Next(1, 101) <= Agility)
            {
                Console.WriteLine("The opponent dodges!");
                HasDodged = true;
            }
        }
    }
}
