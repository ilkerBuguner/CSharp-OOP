using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Tank : BaseMachine, ITank
    {
        private const double initialHealthPoints = 100;
        public Tank(string name, double atttackPoints, double defencePoints) : base(name, atttackPoints, defencePoints, initialHealthPoints)
        {
            ToggleDefenseMode();
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (DefenseMode == false)
            {
                AttackPoints -= 40;
                DefensePoints += 30;
                DefenseMode = true;
            }
            else
            {
                AttackPoints += 40;
                DefensePoints -= 30;
                DefenseMode = false;
            }
        }

        public override string ToString()
        {

            string res = base.ToString();
            StringBuilder sb = new StringBuilder(res);
            if (DefenseMode == true)
            {
                sb.AppendLine($" *Defense: ON");
            }
            else
            {
                sb.AppendLine($" *Defense: OFF");
            }

            return sb.ToString().Trim();
        }
    }
}
