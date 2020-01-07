using System;

namespace rpg_simulation
{
    public class Elf : Race
    {
        public Elf(Character characterIn, Character enemyIn,
                   int averageHp = (int)Stat.ElfHp,
                   int averageAgility = (int)Stat.ElfAgility,
                   int averageStrength = (int)Stat.ElfStrength)
            : base(characterIn, enemyIn, averageHp, averageAgility, averageStrength) 
        {
            IsSecondAttack = character.IsSecondAttack;
        }

        public bool IsSecondAttack;
        public void DoubleAttack()
        {
            var rand = new Random();
            if (rand.Next(1, 11) <= 3 && !IsSecondAttack)
            {
                Console.WriteLine("{0} is so fast, they attack twice!", character.name);
                character.Attack(enemy);
                IsSecondAttack = true;
            }
        }

    }
}
