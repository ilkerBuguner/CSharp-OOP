using MXGP.Models.Races.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MXGP.Factories
{
    public class RaceFactory
    {
        public IRace CreateRace(string type, string name, int laps)
        {
            var raceType = Assembly.GetCallingAssembly().GetTypes()
                .FirstOrDefault(x => x.Name == type);

            if (raceType == null)
            {
                throw new ArgumentException("Invalid race type");
            }

            var race = (IRace)Activator.CreateInstance(raceType, name, laps);

            return race;
        }
    }
}
