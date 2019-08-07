using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Factories.Contracts
{
    public interface IPilotFactory
    {
        IPilot CreatePilot(string type, string name);
    }
}
