using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Players
{
    public class MainPlayer : Player
    {
        private const int InitialLifePoints = 100;
        private const string nameOfMainCaracter = "Tommy Vercetti";
        public MainPlayer() : base(nameOfMainCaracter, InitialLifePoints)
        {
        }
    }
}
