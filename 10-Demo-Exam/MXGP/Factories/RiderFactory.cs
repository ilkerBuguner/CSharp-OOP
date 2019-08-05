using MXGP.Models.Riders.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MXGP.Factories
{
    public class RiderFactory
    {
        public IRider CreateRider(string type, string name)
        {
            var riderType = Assembly.GetCallingAssembly().GetTypes()
                .FirstOrDefault(x => x.Name == type);

            if (riderType == null)
            {
                throw new ArgumentException("Invalid rider type");
            }

            var rider = (IRider)Activator.CreateInstance(riderType, name);

            return rider;
        }
    }
}
