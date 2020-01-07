using System;

namespace rpg_simulation
{
    public class Warrior : GameClass
    {
        public Warrior(Character characterIn, Character enemyIn)
            : base(characterIn, enemyIn)
        {
            attackLine = "They swing a sword randomly and somehow hit the opponent.";
        }
        public void Parry()
        {
            var rand = new Random();
            if (rand.Next(1, 11) <= 3)
            {
                Console.WriteLine("Character 2 perries! Character 1 gets hit");
                enemy.GetAttacked(enemy.Strength);
            }
        }
    }
}
