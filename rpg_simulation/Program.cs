﻿
using System;

namespace rpg_simulation
{
    class Program
    {
        static void Main(string[] args)
        {
            (Character, Character) characters = Methods.ReadCharacters();
            Character character1 = characters.Item1;
            Character character2 = characters.Item2;
            if (!character1.IsValid() || !character2.IsValid())
            {
                Console.WriteLine("Incorrect input!");
                return;
            }

            character1.DisplayStat();
            character2.DisplayStat();

            Methods.Battle(character1, character2);
        }
    }
}
