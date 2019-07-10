using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Border_Control
{
    public class Pet : IBirthable, INameable
    {

        public string Birthdate { get; }

        public int BirthYear => int.Parse(Birthdate.Split('/').Skip(2).ToArray()[0]);

        public string Name { get; }

        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }
    }
}
