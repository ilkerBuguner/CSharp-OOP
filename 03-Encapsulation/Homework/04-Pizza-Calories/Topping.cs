using System;
using System.Collections.Generic;


    public class Topping
    {
        private const double baseCalories = 2;

        private Dictionary<string, double> validTypes;

        private string type;

        public string Type
        {
            get => type;
            private set
            {
                if (!validTypes.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                type = value;
            }
        }

        private double weight;
        public double Weight
        {
            get => weight;
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{Type} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }

        public double Calories => CalculateCalories();

        public Topping(string type, double weight)
        {
            validTypes = new Dictionary<string, double>();
            AddValidTypes();

            Type = type;
            Weight = weight;
        }
        private void AddValidTypes()
        {
            validTypes.Add("meat", 1.2);
            validTypes.Add("veggies", 0.8);
            validTypes.Add("cheese", 1.1);
            validTypes.Add("sauce", 0.9);
        }

        private double CalculateCalories()
        {
            return baseCalories * weight * validTypes[Type.ToLower()];
        }
    }

