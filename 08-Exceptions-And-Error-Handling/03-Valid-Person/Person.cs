using System;
using System.Collections.Generic;
using System.Text;

namespace Valid_Person
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstname, string lastname, int age)
        {
            FirstName = firstName;
            Lastname = lastName;
            Age = age;
        }

        public string FirstName
        {
            get => firstName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Invalid Firstname!");
                }

                firstName = value;
            }
        }

        public string Lastname
        {
            get => lastName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Invalid Lastname!");
                }

                lastName = value;
            }
        }

        public int Age
        {
            get => age;
            set
            {
                if (value < 0 || value > 120)
                {
                    throw new ArgumentNullException("Invalid age!");
                }

                age = value;
            }
        }
    }
}
