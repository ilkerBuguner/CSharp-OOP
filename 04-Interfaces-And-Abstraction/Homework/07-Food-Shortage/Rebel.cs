using System;
using System.Collections.Generic;
using System.Text;

namespace Border_Control
{
    public class Rebel : INameable, IBuyer
    {
        public string Name { get; }
        public int Age { get; private set; }
        public string Group { get; private set; }
        public int Food { get; set; }

        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
            Food = 0;
        }
        public int BuyFood()
        {
            Food += 5;
            return 5;
        }
    }
}
