using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Repositories.Contracts
{
    public interface IPilotRepository
    {
        IReadOnlyList<IPilot> Pilots { get; }

        void AddPilot(IPilot pilot);
        void RemovePilot(IPilot pilot);
        bool ContainsPilot(string name);
    }
}
