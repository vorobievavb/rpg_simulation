using System;
using System.Collections.Generic;
using System.Text;

namespace rpg_simulation
{
    static class Methods
    {
        public static(Character, Character) ReadCharacters()
        {
            Character character1 = new Character(null, null, null);
            Character character2 = new Character(null, null, null);
            Console.Write("Available races: orc, human, elf.\n" +
                             "Type in the race of the first character: ");
            string input = Console.ReadLine();
            Race race1 = Methods.AssignRace(input, character1, character2);
            Console.Write("Type in the race of the second character: ");
            input = Console.ReadLine();
            Race race2 = Methods.AssignRace(input, character2, character1);
            Console.Write("Available classes: mage, warrior, archer.\n" +
                     "Type in the class of the first character: ");
            input = Console.ReadLine();
            GameClass class1 = Methods.AssignClass(input, character1, character2);
            Console.Write("Type in the class of the second character: ");
            input = Console.ReadLine();
            GameClass class2 = Methods.AssignClass(input, character2, character1);
            Character character = new Character(race1, class1, "Character 1");
            character.CharacterCloneTo(character1);
            character = new Character(race2, class2, "Character 2");
            character.CharacterCloneTo(character2);

            return (character1, character2);
        }

        static public void Battle(Character character1, Character character2)
        {
            Console.WriteLine("BATTLE START\n");
            int characterN1 = 0;
            while ((character1.Hp > 0) && (character2.Hp > 0))
            {
                character1.IsSecondAttack = false;
                character1.SetSecondAttack();
                character2.IsSecondAttack = false;
                character2.SetSecondAttack();

                characterN1++;
                if (characterN1 > 2) characterN1 = 1;
                if (characterN1 == 1)
                    character1.Attack(character2);
                else
                    character2.Attack(character1);
                Console.ReadLine();
            }
        }

        static public Race AssignRace(string input, Character character, Character enemy)
        {
            switch (input)
            {
                case "orc":
                case "Orc":
                    return new Orc(character, enemy);
                case "human":
                case "Human":
                    Human human = new Human(character, enemy);
                    character.BeingAttacked += human.Rage;
                    return human;
                case "elf":
                case "Elf":
                    Elf elf = new Elf(character, enemy);
                    character.Attacking += elf.DoubleAttack;
                    return elf;
                default:
                    Console.WriteLine("This race is not available");
                    return null;
            }
        }
        static public GameClass AssignClass(string input, Character character, Character enemy)
        {
            switch (input) 
            {
                case "mage":
                case "Mage":
                    Mage mage = new Mage(character, enemy);
                    character.Attacking += mage.InstaKill;
                    return mage;
                case "warrior":
                case "Warrior":
                    Warrior warrior = new Warrior(character, enemy);
                    character.BeingAttacked += warrior.Parry;
                    return warrior;
                case "archer":
                case "Archer":
                    var archer = new Archer(character, enemy);
                    character.Attacking += archer.FirstAttack;
                    return archer;
                default:
                    Console.WriteLine("This class is not available");
                    return null;
            }
        }
    }
}
