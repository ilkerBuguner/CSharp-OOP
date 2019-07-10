﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Border_Control
{
    public class Citizen : IIdentifiable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; }

        public Citizen(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
        }


    }
}
