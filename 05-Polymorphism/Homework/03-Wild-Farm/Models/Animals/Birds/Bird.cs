using System;
using System.Collections.Generic;
using System.Text;


public abstract class Bird : Animal
{
    public double WingSize { get; set; }

    public Bird(string name, double weight, double wingSize) : base(name, weight)
    {
        WingSize = wingSize;
    }

    public override string ToString()
    {
        return $"{GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
    }
}

