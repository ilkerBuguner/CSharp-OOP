using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Pilot : IPilot
    {
        private string name;
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Pilot name cannot be null or empty string.");
                }

                name = value;
            }
        }

        List<IMachine> machines { get; set; }

        public Pilot(string name)
        {
            Name = name;
            machines = new List<IMachine>();
        }

        public void AddMachine(IMachine machine)
        {
            if (machine == null)
            {
                throw new NullReferenceException("Null machine cannot be added to the pilot.");
            }

            machines.Add(machine);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Name} - {machines.Count} machines");

            foreach (var machine in machines)
            {
                sb.AppendLine(machine.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
