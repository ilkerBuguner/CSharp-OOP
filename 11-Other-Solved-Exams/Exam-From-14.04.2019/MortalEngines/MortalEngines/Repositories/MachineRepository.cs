using MortalEngines.Entities.Contracts;
using MortalEngines.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MortalEngines.Repositories
{
    public class MachineRepository : IMachineRepository
    {
        private readonly List<IMachine> machines;
        public IReadOnlyList<IMachine> Machines => machines.AsReadOnly();


        public MachineRepository()
        {
            machines = new List<IMachine>();
        }

        public void AddMachine(IMachine machine)
        {
            machines.Add(machine);
        }

        public void RemoveMachine(IMachine machine)
        {
            if (machines.Contains(machine))
            {
                machines.Remove(machine);
            }
        }

        public bool ContainsMachine(string name)
        {
            IMachine machine = machines.FirstOrDefault(x => x.Name == name);

            if (machine == null)
            {
                return false;
            }

            return true;
        }
    }
}
