using System;
using System.Collections.Generic;
using System.Text;

namespace Border_Control
{
    public interface IBuyer
    {
        int Food { get; set; }
        int BuyFood();
    }
}
