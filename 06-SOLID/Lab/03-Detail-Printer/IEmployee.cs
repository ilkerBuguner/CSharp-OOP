﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Detail_Printer
{
    public interface IEmployee
    {
        string Name { get; set; }

        void PrintMyself();
    }
}
