using System;
using System.Collections.Generic;
using System.Text;
using Wild_Farm.Interfaces;


public abstract class Animal : ISoundProducible
{
    public string Name { get; set; }
    public double Weight { get; set; }
    public int FoodEaten { get; set; }

    public abstract double WeightPerPiece { get; set; }
    public abstract List<string> FoodTypes { get; set; }

    public Animal(string name, double weight)
    {
        Name = name;
        Weight = weight;
        FoodEaten = 0;
    }

    public abstract void ProduceSound();

    public virtual void Eat(Food food)
    {
        if (!FoodTypes.Contains(food.GetType().Name))
        {
            throw new ArgumentException($"{GetType()} does not eat {food.GetType().Name}!");
        }

        Weight += WeightPerPiece * food.Quantity;
        FoodEaten += food.Quantity;
    }
}

