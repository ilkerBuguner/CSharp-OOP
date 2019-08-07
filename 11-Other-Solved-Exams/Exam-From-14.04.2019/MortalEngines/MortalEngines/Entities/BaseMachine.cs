using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MortalEngines.Entities
{
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;


        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Machine name cannot be null or empty.");
                }

                name = value;
            }
        }

        public IPilot Pilot
        {
            get => pilot;
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Pilot cannot be null.");
                }
                pilot = value;
            }
        }
        public double HealthPoints { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets { get; protected set; }

        public BaseMachine(string name, double atttackPoints, double defencePoints, double healthPoints)
        {
            Name = name;
            AttackPoints = atttackPoints;
            DefensePoints = defencePoints;
            HealthPoints = healthPoints;
            Targets = new List<string>();
        }

        public void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException("Target cannot be null");
            }

            target.HealthPoints -= this.AttackPoints - target.DefensePoints;

            if (target.HealthPoints <= 0)
            {
                target.HealthPoints = 0;
            }

            Targets.Add(target.Name);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- {Name}");
            sb.AppendLine($" *Type: {GetType().Name}");
            sb.AppendLine($" *Health: {HealthPoints:F2}");
            sb.AppendLine($" *Attack: {AttackPoints:F2}");
            sb.AppendLine($" *Defense: {DefensePoints:F2}");

            if (Targets.Count == 0)
            {
                sb.AppendLine($" *Targets: None");
            }

            if (Targets.Any())
            {
                sb.AppendLine($" *Targets: {string.Join(",", Targets)}");
            }

            return sb.ToString();
        }

    }
}
