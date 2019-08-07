using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Fighter : BaseMachine, IFighter
    {
        private const double initialHealthPoints = 200;


        public Fighter(string name, double atttackPoints, double defencePoints) 
            : base(name, atttackPoints, defencePoints, initialHealthPoints)
        {
            ToggleAggressiveMode();
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if (AggressiveMode == false)
            {
                AttackPoints += 50;
                DefensePoints -= 25;
                AggressiveMode = true;
            }
            else
            {
                AttackPoints -= 50;
                DefensePoints += 25;
                AggressiveMode = false;
            }

        }

        public override string ToString()
        {

            string res = base.ToString();
            StringBuilder sb = new StringBuilder(res);
            if (AggressiveMode == true)
            {
                sb.AppendLine($" *Aggressive: ON");
            }
            else
            {
                sb.AppendLine($" *Aggressive: OFF");
            }

            return sb.ToString().Trim();
        }
    }
}
