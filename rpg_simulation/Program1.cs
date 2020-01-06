
using System;

namespace rpg_simulation
{
    class Program
    {
        enum Stat
        {
            OrcHp = 300, OrcAgility = 5, OrcStrenght = 40,
            ElfHp = 150, ElfAgility = 25, ElfStrenght = 20,
            HumanHp = 200, HumanAgility = 10, HumanStrenght = 30
        }
        abstract public class Race
        {
            protected int hp;
            public int GetHp() { return hp; }
            public void SetHp(int value) { hp = value; }
            private int _agility;
            public int GetAgility() { return _agility; }
            public void SetAgility(int value) { _agility = value; }
            private int _strength;
            public int GetStrength() { return _strength; }
            public void SetStrength(int value) { _strength = value; }
            public Race(int averageHp, int averageAgility, int averageStrength)
            {
                var rand = new Random();
                SetHp(rand.Next(50, 151) * averageHp / 100);
                SetAgility(rand.Next(50, 151) * averageAgility / 100);
                SetStrength(rand.Next(50, 151) * averageStrength / 100);
            }
            abstract public void Rage();
            abstract public bool DoubleAttack();
        }

        public class Elf : Race
        {
            public Elf(int averageHp = (int)Stat.ElfHp,
                       int averageAgility = (int)Stat.ElfAgility,
                       int averageStrength = (int)Stat.ElfStrenght)
                : base(averageHp, averageAgility, averageStrength) { }
            public override bool DoubleAttack()
            {
                var rand = new Random();
                if (rand.Next(1, 11) <= 3) return true;
                else return false;
            }
            public override void Rage() { }
        }
        public class Human : Race
        {
            public readonly int baseHp;
            public Human(int averageHp = (int)Stat.HumanHp,
                         int averageAgility = (int)Stat.HumanAgility,
                         int averageStrength = (int)Stat.HumanStrenght)
                : base(averageHp, averageAgility, averageStrength)
            {
                baseHp = hp;
            }
            public override void Rage()
            {
                if (hp < baseHp * 0.25)
                {
                    Console.WriteLine("They are enraged! Attack doubles.");
                    SetStrength(GetStrength() * 2);
                }
            }
            public override bool DoubleAttack() { return false; }
        }

        public class Orc : Race
        {
            public Orc(int averageHp = (int)Stat.OrcHp,
                       int averageAgility = (int)Stat.OrcAgility,
                       int averageStrength = (int)Stat.OrcStrenght)
                : base(averageHp, averageAgility, averageStrength) { }
            public override bool DoubleAttack() { return false; }
            public override void Rage() { }
        }

        abstract public class GameClass
        {
            public string attackLine;
            public GameClass() { }
            abstract public string GetClass();
            abstract public bool Parry();
            abstract public bool InstaKill();
        }

        public class Mage : GameClass
        {
            public Mage() { attackLine = "They throw a fireball. Very original."; }
            public override string GetClass() { return "Mage"; }
            public override bool InstaKill()
            {
                var rand = new Random();
                if (rand.Next(1, 11) <= 1) return true;
                else return false;
            }
            public override bool Parry() { return false; }
        }
        public class Warrior : GameClass
        {
            public Warrior() { attackLine = "They swing a sword randomly and somehow hit the opponent."; }
            public override string GetClass() { return "Warrior"; }
            public override bool Parry()
            {
                var rand = new Random();
                if (rand.Next(1, 11) <= 3) return true;
                else return false;
            }
            public override bool InstaKill() { return false; }
        }
        public class Archer : GameClass
        {
            public Archer()
            {
                attackLine = "They shoot an arrow. It penetrates the opponent's knee. " +
                    "They will no longer be an andenturer.";
            }
            public override string GetClass() { return "Archer"; }
            public override bool Parry() { return false; }
            public override bool InstaKill() { return false; }
        }
        public class Character
        {
            private readonly Race _charRace;
            private readonly GameClass _charClass;
            public int GetHp() { return _charRace.GetHp(); }
            public string GetClass()
            {
                return _charClass.GetClass();
            }

            public bool Parry()
            {
                return _charClass.Parry();
            }
            public bool InstaKill() { return _charClass.InstaKill(); }
            public void Rage() { _charRace.Rage(); }
            public bool DoubleAttack() { return _charRace.DoubleAttack(); }
            public Character(Race race, GameClass gameClass)
            {
                _charRace = race;
                _charClass = gameClass;
            }

            public int Attack()
            {
                Console.WriteLine(_charClass.attackLine);
                return _charRace.GetStrength();
            }

            public bool GetAttacked(int attack)
            {
                _charRace.SetHp(_charRace.GetHp() - attack);
                if (GetHp() <= 0)
                {
                    Console.WriteLine("Their HP is now 0. They lose!", _charRace.GetHp());
                    return true;
                }
                else Console.WriteLine("Their HP is now {0}.", _charRace.GetHp());
                Rage();
                return false;
            }
        }

        static public Race AssignRace(string input)
        {
            switch (input)
            {
                case "orc": goto case "Orc";
                case "Orc":
                    return new Orc();
                case "human": goto case "Human";
                case "Human":
                    return new Human();
                case "elf": goto case "Elf";
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
                case "mage": goto case "Mage";
                case "Mage":
                    return new Mage();
                case "warrior": goto case "Warrior";
                case "Warrior":
                    return new Warrior();
                case "archer": goto case "Archer";
                case "Archer":
                    return new Archer();
                default:
                    Console.WriteLine("This class is not available");
                    return null;
            }
        }
        static public bool Round(Character character1, Character character2, bool turn1, bool is2Attack)
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
            if (character2.Parry())
            {
                Console.Write("Character {0} too perries! Character {1} gets hit. ", characterN2, characterN1);
                if (character1.GetAttacked(attack)) return true; ;
            }
            else
            {
                Console.Write("Character {0} gets hit. ", characterN2);
                if (character2.GetAttacked(attack)) return true; ;
            }
            if (character1.DoubleAttack() & !is2Attack)
            {
                Console.WriteLine("Character {0} is so fast, they attack twice!", characterN1);
                return Round(character1, character2, turn1, true);
            }
            return false;
        }
        static void Main(string[] args)
        {
            Console.Write("Available races: orc, human, elf.\n" +
                "Type in the race of the first character: ");
            string input = Console.ReadLine();
            Race race1 = AssignRace(input);
            if (race1 == null) return;
            Console.Write("Type in the race of the second character: ");
            input = Console.ReadLine();
            Race race2 = AssignRace(input);
            if (race2 == null) return;

            Console.Write("Available classes: mage, warrior, archer.\n" +
                      "Type in the class of the first character: ");
            input = Console.ReadLine();
            GameClass class1 = AssignClass(input);
            if (class1 == null) return;
            Console.Write("Type in the class of the second character: ");
            input = Console.ReadLine();
            GameClass class2 = AssignClass(input);
            if (class2 == null) return;
            Character character1 = new Character(race1, class1);
            Character character2 = new Character(race2, class2);

            int attack;
            if (character1.GetClass() == "Archer")
            {
                Console.WriteLine("Character 1 sneaks into battle and attacks twice!");
                attack = character1.Attack();
                if (character2.Parry())
                {
                    Console.WriteLine("Character 2 too perries! Character 1 gets hit");
                    character1.GetAttacked(attack);
                }
                else character2.GetAttacked(attack);
            }
            int characterN1 = 0;

            while ((character1.GetHp() > 0) && (character2.GetHp() > 0))
            {
                characterN1++;
                if (characterN1 > 2) characterN1 = 1;
                if (characterN1 == 1) { if (Round(character1, character2, true, false)) break; ; }
                else if (Round(character2, character1, false, false)) break; ;
                Console.ReadLine();
            }

        }
    }
}
