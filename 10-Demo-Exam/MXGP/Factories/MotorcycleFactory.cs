using MXGP.Models.Motorcycles.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MXGP.Factories
{
    public class MotorcycleFactory
    {
        private const string Suffix = "Motorcycle";
        public IMotorcycle CreateMotorcycle(string type, string model, int horsePower)
        {
            var motorcycleType = Assembly.GetCallingAssembly().GetTypes()
                .FirstOrDefault(x => x.Name == type + Suffix);

            if (motorcycleType == null)
            {
                throw new ArgumentException("Invalid motorcycle type");
            }

            var motorcycle = (IMotorcycle)Activator.CreateInstance(motorcycleType, model, horsePower);

            return motorcycle;
        }
    }
}
