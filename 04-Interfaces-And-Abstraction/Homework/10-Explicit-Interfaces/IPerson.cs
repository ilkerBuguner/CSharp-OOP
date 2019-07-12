using System;
using System.Collections.Generic;
using System.Text;

namespace Explicit_Interfaces
{
    public interface IPerson
    {
        string Name { get; set; }
        string Age { get; set; }
        string GetName();
    }
}
