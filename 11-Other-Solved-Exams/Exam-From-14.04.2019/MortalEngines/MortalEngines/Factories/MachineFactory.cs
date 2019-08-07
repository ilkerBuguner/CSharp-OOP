using MortalEngines.Entities.Contracts;
using MortalEngines.Factories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MortalEngines.Factories
{
    public class MachineFactory : IMachineFactory
    {
        public IMachine CreateMachine(string type, string name, double attackPoints, double defencePoints)
        {
            var machineType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == type);

            if (machineType == null)
            {
                throw new ArgumentException("Invalid machine type");
            }

            var machine = (IMachine)Activator.CreateInstance(machineType, name, attackPoints, defencePoints);

            return machine;
        }
    }
}
