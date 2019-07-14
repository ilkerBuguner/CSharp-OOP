using System;
using System.Collections.Generic;
using System.Text;


public class Cat : Feline
{
    public override double WeightPerPiece { get; set; }
    public override List<string> FoodTypes { get; set; }

    public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
    {
        WeightPerPiece = 0.30;
        FoodTypes = new List<string>() { "Vegetable", "Meat" };
    }
    public override void ProduceSound()
    {
        Console.WriteLine("Meow");
    }
}

