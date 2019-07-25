﻿using System;
using System.Collections.Generic;
using System.Text;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Entities
{
    public class Person
    {
        private const int minAge = 12;
        private const int maxAge = 90;

        [MyRequired]
        public string FullName { get; private set; }

        [MyRange(minAge, maxAge)]
        public int Age { get; private set; }

        public Person(string fullname, int age)
        {
            FullName = fullname;
            Age = age;
        }
    }
}
