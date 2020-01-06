using System;
using System.Collections.Generic;
using System.Text;

namespace rpg_simulation
{
    static class Methods
    {
        public static(Character, Character) ReadCharacters()
        {
            Console.Write("Available races: orc, human, elf.\n" +
                             "Type in the race of the first character: ");
            string input = Console.ReadLine();
            Race race1 = Methods.AssignRace(input);
            Console.Write("Type in the race of the second character: ");
            input = Console.ReadLine();
            Race race2 = Methods.AssignRace(input);
            Console.Write("Available classes: mage, warrior, archer.\n" +
                     "Type in the class of the first character: ");
            input = Console.ReadLine();
            GameClass class1 = Methods.AssignClass(input);
            Console.Write("Type in the class of the second character: ");
            input = Console.ReadLine();
            GameClass class2 = Methods.AssignClass(input);
            Character character1 = new Character(race1, class1);
            Character character2 = new Character(race2, class2);
            return (character1, character2);
        }

        static public void Battle(Character character1, Character character2)
        {
            Console.WriteLine("BATTLE START\n");
            int attack;
            if (character1.GetClass() == "Archer")
            {

                Console.WriteLine("Character 1 sneaks into battle and attacks twice!");
                attack = character1.Attack();
                if (character2.Dodge()) Console.WriteLine("Character 2 dodges!");
                else if (character2.Parry())
                {
                    Console.WriteLine("Character 2 perries! Character 1 gets hit");
                    character1.GetAttacked(attack);
                }
                else character2.GetAttacked(attack);
            }
            int characterN1 = 0;

            while ((character1.Hp > 0) && (character2.Hp > 0))
            {
                characterN1++;
                if (characterN1 > 2) characterN1 = 1;
                if (characterN1 == 1) { if (Methods.Round(character1, character2, true, false)) break; ; }
                else if (Methods.Round(character2, character1, false, false)) break; ;
                Console.ReadLine();
            }
        }

        static public Race AssignRace(string input)
        {
            switch (input)
            {
                case "orc":
                case "Orc":
                    return new Orc();
                case "human":
                case "Human":
                    return new Human();
                case "elf":
                case "Elf":
                    return new Elf();
                default:
                    Console.WriteLine("This race is not available");
                    return null;
            }
        }
        static public GameClass AssignClass(string input)
        {
            switch (input)
            {
                case "mage":
                case "Mage":
                    return new Mage();
                case "warrior":
                case "Warrior":
                    return new Warrior();
                case "archer":
                case "Archer":
                    return new Archer();
                default:
                    Console.WriteLine("This class is not available");
                    return null;
            }
        }
        static public bool Round(Character character1, Character character2, bool turn1, bool isSecondAttack)
        {
            int characterN1, characterN2;
            if (turn1)
            {
                characterN1 = 1;
                characterN2 = 2;
            }
            else
            {
                characterN1 = 2;
                characterN2 = 1;
            }
            int attack;
            Console.WriteLine("Character {0} attacks.", characterN1);
            if (character1.InstaKill())
            {
                Console.WriteLine("INSTAKILL! Character {0} explodes the universe and wins.", characterN1);
                return true;
            }
            attack = character1.Attack();
            if (character2.Dodge()) Console.WriteLine("Character {0} dodges!", characterN2);
            else if (character2.Parry())
            {
                Console.Write("Character {0} perries! Character {1} gets hit. ", characterN2, characterN1);
                if (character1.GetAttacked(attack)) return true; ;
                return Round(character1, character2, turn1, false);
            }
            else
            {
                Console.Write("Character {0} gets hit. ", characterN2);
                if (character2.GetAttacked(attack)) return true; ;
            }
            if (character1.DoubleAttack() & !isSecondAttack)
            {
                Console.WriteLine("Character {0} is so fast, they attack twice!", characterN1);
                return Round(character1, character2, turn1, true);
            }
            return false;
        }
    }
}
