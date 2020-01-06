using System;
using System.Collections.Generic;
using System.Text;

namespace rpg_simulation
{
    public class Character
    {
        private readonly Race _charRace;
        private readonly GameClass _charClass;

        public int Hp;
        public string GetClass() 
        { 
            return _charClass.GetClass(); 
        }
        public bool Parry() 
        { 
            return _charClass.Parry(); 
        }
        public bool InstaKill() 
        {
            return _charClass.InstaKill();
        }
        public void Rage()
        {
            _charRace.Rage(); 
        }
        public bool DoubleAttack() { return _charRace.DoubleAttack(); }
        public Character(Race race, GameClass gameClass)
        {
            _charRace = race;
            _charClass = gameClass;
            if (_charRace != null) Hp = _charRace.Hp;
        }

        public int Attack()
        {
            Console.WriteLine(_charClass.attackLine);
            return _charRace.Strength;
        }

        public bool GetAttacked(int attack)
        {
            _charRace.Hp = _charRace.Hp - attack;
            if (_charRace.Hp <= 0)
            {
                Console.WriteLine("Their HP is now 0. They lose!");
                return true;
            }
            else Console.WriteLine("Their HP is now {0}.", _charRace.Hp);
            Rage();
            return false;
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
            _charRace.DisplayStat(); 
        }
        public bool Dodge() 
        {
            return _charRace.Dodge(); 
        }
    }
}
