using System;

namespace rpg_simulation
{
    public class Character
    {
        public string name;
        private Race _charRace;
        private GameClass _charClass;

        public int Hp;
        public int baseHp;
        public int Strength;
        public void SetIsSecondAttack(bool value)
        {
            _charRace.isSecondAttack = value;
        }

        public void SetIsFirstEverAttack(bool value)
        {
            _charClass.SetIsFirstEverAttack(value);
        }

        public void SetHasPerried(bool value)
        {
            _charRace.HasPerried = value;
        }
        public void SetHasDodged(bool value)
        {
            _charClass.HasDodged = value;
        }
        public Character(Race race, GameClass gameClass, string nameIn)
        {
            _charRace = race;
            _charClass = gameClass;
            if (_charRace != null)
            {
                Hp = _charRace.Hp;
                baseHp = Hp;
                Strength = _charRace.Strength;
                BeingAttackedStart += _charRace.Dodge;
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
                dest.baseHp = baseHp;
                dest.Strength = _charRace.Strength;
                dest.BeingAttackedStart += _charRace.Dodge;
            }
            dest.name = name;
        }

        public delegate void EventHandlerConsideringPerry(bool isPerry = false);
        public delegate void EventHandler();
        public event EventHandler AttackingStart;
        public event EventHandler AttackingEnd;
        public event EventHandlerConsideringPerry BeingAttackedStart;
        public event EventHandler BeingAttackedEnd;

        public void Attack(Character enemy)
        {
            AttackingStart?.Invoke();
            if (enemy.Hp <= 0)
                return;
            Console.WriteLine("{0} attacks.", name);
            Console.WriteLine(_charClass.attackLine);
            enemy.GetAttacked(_charRace.Strength);
            AttackingEnd?.Invoke();
        }

        public void GetAttacked(int attack, bool isPerry = false)
        {
            _charRace.HasDodged = false;
            _charClass.HasParried = false;
            BeingAttackedStart?.Invoke(isPerry);
            if (_charRace.HasDodged || _charClass.HasParried) 
                return;
            Hp -= attack;
            Console.WriteLine("{0} gets hit.", name);
            if (Hp <= 0)
                Console.WriteLine("Their HP is now 0. They lose!");
            else
                Console.WriteLine("Their HP is now {0}.", Hp);
            BeingAttackedEnd?.Invoke();
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
