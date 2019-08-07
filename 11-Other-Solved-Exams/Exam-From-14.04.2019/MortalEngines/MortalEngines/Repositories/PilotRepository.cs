﻿using MortalEngines.Entities;
using MortalEngines.Entities.Contracts;
using MortalEngines.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MortalEngines.Repositories
{
    public class PilotRepository : IPilotRepository
    {
        private readonly List<IPilot> pilots;
        public IReadOnlyList<IPilot> Pilots => pilots.AsReadOnly();

        public PilotRepository()
        {
            pilots = new List<IPilot>();
        }

        public void AddPilot(IPilot pilot)
        {
            pilots.Add(pilot);
        }

        public void RemovePilot(IPilot pilot)
        {
            if (pilots.Contains(pilot))
            {
                pilots.Remove(pilot);
            }
        }

        public bool ContainsPilot(string name)
        {
            IPilot pilot = pilots.FirstOrDefault(x => x.Name == name);

            if (pilot == null)
            {
                return false;
            }
            return true;
        }
    }
}
