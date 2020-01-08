using System;

namespace rpg_simulation
{
    public class Mage : GameClass
    {
        public Mage(Character characterIn, Character enemyIn)
            : base(characterIn, enemyIn)
        {
            attackLine = "They throw a fireball. Very original.";
            character.AttackingStart += InstaKill;
        }
        public void InstaKill()
        {
            var rand = new Random();
            if (rand.Next(1, 11) <= 1)
            {
                Console.WriteLine("INSTAKILL! The fireball explodes. {0} wins.", character.name);
                enemy.Hp = 0;
            }
        }
    }
}
