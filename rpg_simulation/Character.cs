using System;

namespace rpg_simulation
{
    public class Character
    {
        public string name;
        private Race _charRace;
        private GameClass _charClass;

        public int Hp;
        public int Strength;
        public bool IsSecondAttack;
        public void SetSecondAttack()
        {
            _charRace.IsSecondAttack = IsSecondAttack;
        }
        public Character(Race race, GameClass gameClass, string nameIn)
        {
            _charRace = race;
            _charClass = gameClass;
            if (_charRace != null)
            {
                Hp = _charRace.Hp;
                Strength = _charRace.Strength;
                BeingAttacked += _charRace.Dodge;
            }
            name = nameIn;
        }

        public void CharacterCloneTo(Character dest)
        {
            dest._charRace = _charRace;
            dest._charClass = _charClass;
            if (_charRace != null)
            {
                dest.Hp = _charRace.Hp;
                dest.Strength = _charRace.Strength;
                dest.BeingAttacked += _charRace.Dodge;
            }
            dest.name = name;
        }

        public delegate void EventHandler();
        public event EventHandler Attacking;
        public event EventHandler BeingAttacked;

        public void Attack(Character enemy)
        {
            Console.WriteLine("{0} attacks.", name);
            Console.WriteLine(_charClass.attackLine);
            enemy.GetAttacked(_charRace.Strength);
            Attacking?.Invoke();
        }

        public void GetAttacked(int attack)
        {
            _charRace.HasDodged = false;
            BeingAttacked?.Invoke();
            Hp -= attack;
            if (_charRace.HasDodged) 
                return;
            Console.WriteLine("{0} gets hit.", name);
            if (Hp <= 0)
                Console.WriteLine("Their HP is now 0. They lose!");
            else
                Console.WriteLine("Their HP is now {0}.", Hp);
        }

        public bool IsValid()
        {
            if (_charRace == null || _charClass == null)
                return false;
            else
                return true;
        }

        public void DisplayStat()
        {
            Console.Write("{0}: ", name);
            _charRace.DisplayStat(); 
        }

    }
}
