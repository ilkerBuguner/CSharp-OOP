namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Common;
    using MortalEngines.Entities.Contracts;
    using MortalEngines.Factories;
    using MortalEngines.Factories.Contracts;
    using MortalEngines.Repositories;
    using MortalEngines.Repositories.Contracts;
    using System.Linq;

    public class MachinesManager : IMachinesManager
    {
        private IPilotRepository pilotRepository;
        private IMachineRepository machineRepository;

        private IPilotFactory pilotFactory;
        private IMachineFactory machineFactory;

        public MachinesManager()
        {
            pilotRepository = new PilotRepository();
            machineRepository = new MachineRepository();

            pilotFactory = new PilotFactory();
            machineFactory = new MachineFactory();
        }

        public string HirePilot(string name)
        {
            if (pilotRepository.ContainsPilot(name))
            {
                return string.Format(OutputMessages.PilotExists, name);
            }

            var pilot = pilotFactory.CreatePilot("Pilot", name);
            pilotRepository.AddPilot(pilot);

            return string.Format(OutputMessages.PilotHired, name);

        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (machineRepository.ContainsMachine(name))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }

            var tank = machineFactory.CreateMachine("Tank", name, attackPoints, defensePoints);
            machineRepository.AddMachine(tank);
            return string.Format(OutputMessages.TankManufactured, tank.Name, tank.AttackPoints, tank.DefensePoints);
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (machineRepository.ContainsMachine(name))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }

            var fighter = machineFactory.CreateMachine("Fighter", name, attackPoints, defensePoints);
            machineRepository.AddMachine(fighter);

            var isAggressive = ((IFighter)fighter).AggressiveMode;

            if (isAggressive)
            {
                return string.Format(OutputMessages.FighterManufactured, fighter.Name, fighter.AttackPoints, fighter.DefensePoints, "ON");
            }

            return string.Format(OutputMessages.FighterManufactured, fighter.Name, fighter.AttackPoints, fighter.DefensePoints, "OFF");
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            var pilot = pilotRepository.Pilots.FirstOrDefault(x => x.Name == selectedPilotName);
            var machine = machineRepository.Machines.FirstOrDefault(x => x.Name == selectedMachineName);

            if (pilot == null)
            {
                return string.Format(OutputMessages.PilotNotFound, selectedPilotName);
            }

            if (machine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, selectedMachineName);
            }

            if (machine.Pilot != null)
            {
                return string.Format(OutputMessages.MachineHasPilotAlready, selectedMachineName);
            }

            pilot.AddMachine(machine);
            machine.Pilot = pilot;

            return string.Format(OutputMessages.MachineEngaged, selectedPilotName, selectedMachineName);
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            var attackingMachine = machineRepository.Machines.FirstOrDefault(x => x.Name == attackingMachineName);
            var defendingMachine = machineRepository.Machines.FirstOrDefault(x => x.Name == defendingMachineName);

            if (attackingMachine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, attackingMachineName);
            }

            if (defendingMachine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, defendingMachineName);
            }

            if (attackingMachine.HealthPoints <= 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, attackingMachine.Name);
            }

            if (defendingMachine.HealthPoints <= 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, defendingMachine.Name);
            }

            attackingMachine.Attack(defendingMachine);

            return string.Format(OutputMessages.AttackSuccessful
                , defendingMachine.Name, attackingMachine.Name, defendingMachine.HealthPoints);
        }

        public string PilotReport(string pilotReporting)
        {
            var pilot = pilotRepository.Pilots.FirstOrDefault(x => x.Name == pilotReporting);

            if (pilot == null)
            {
                return string.Format(OutputMessages.PilotNotFound, pilotReporting);
            }

            return pilot.Report();
        }

        public string MachineReport(string machineName)
        {
            var machine = machineRepository.Machines.FirstOrDefault(x => x.Name == machineName);

            if (machine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, machineName);
            }

            return machine.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            var fighter = machineRepository.Machines.FirstOrDefault(x => x.Name == fighterName);

            if (fighter == null)
            {
                return string.Format(OutputMessages.MachineNotFound, fighterName);
            }

            ((IFighter)fighter).ToggleAggressiveMode();

            return string.Format(OutputMessages.FighterOperationSuccessful, fighterName);
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            var tank = machineRepository.Machines.FirstOrDefault(x => x.Name == tankName);

            if (tank == null)
            {
                return string.Format(OutputMessages.MachineNotFound, tankName);
            }

            ((ITank)tank).ToggleDefenseMode();

            return string.Format(OutputMessages.TankOperationSuccessful, tankName);
        }
    }
}