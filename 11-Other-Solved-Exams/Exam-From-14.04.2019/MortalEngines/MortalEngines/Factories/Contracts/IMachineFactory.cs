using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Factories.Contracts
{
    public interface IMachineFactory
    {
        IMachine CreateMachine(string type, string name, double attackPoints, double defencePoints);
    }
}
