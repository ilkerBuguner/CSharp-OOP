﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern
{
    public interface ICommandInterpreter
    {
        string Read(string args);
    }
}
