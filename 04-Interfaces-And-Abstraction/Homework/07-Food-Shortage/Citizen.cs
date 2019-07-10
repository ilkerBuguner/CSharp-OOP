using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Border_Control
{
    public class Citizen : IIdentifiable, IBirthable, INameable, IBuyer
    {
        public string Name { get; }
        public int Age { get; set; }
        public string Id { get; }

        public string Birthdate { get; }

        public int BirthYear => int.Parse(Birthdate.Split('/').Skip(2).ToArray()[0]);

        public int Food { get; set; }

        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
            Food = 0;
        }

        public int BuyFood()
        {
            Food += 10;
            return 10;
        }
    }
}
