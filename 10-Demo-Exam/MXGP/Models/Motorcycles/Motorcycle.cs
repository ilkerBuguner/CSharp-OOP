using MXGP.Models.Motorcycles.Contracts;
using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public abstract class Motorcycle : IMotorcycle
    {
        protected int minHP;
        protected int maxHP;

        private string model;
        private int horsePower;

        public Motorcycle(string model, int horsePower, double cubicCentimeters)
        {
            Model = model;
            HorsePower = horsePower;
            CubicCentimeters = cubicCentimeters;
        }

        public string Model
        {
            get => model;
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException(String
                        .Format(ExceptionMessages.InvalidModel, value, 4));
                }

                model = value;
            }
        }

        public int HorsePower
        {
            get => horsePower;
            private set
            {
                if (this.GetType().Name == "PowerMotorcycle")
                {
                    if (value < 70 || value > 100)
                    {
                        throw new ArgumentException(String.Format(ExceptionMessages.InvalidHorsePower, value));
                    }
                }

                if (this.GetType().Name == "SpeedMotorcycle")
                {
                    if (value < 50 || value > 69)
                    {
                        throw new ArgumentException(String.Format(ExceptionMessages.InvalidHorsePower, value));
                    }
                }
                horsePower = value;
            }
        }

        public double CubicCentimeters { get; private set; }

        public double CalculateRacePoints(int laps)
        {
            return CubicCentimeters / HorsePower * laps;
        }
    }
}
