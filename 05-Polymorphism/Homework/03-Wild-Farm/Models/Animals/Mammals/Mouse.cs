using System;
using System.Collections.Generic;
using System.Text;


public class Mouse : Mammal
{
    public override double WeightPerPiece { get; set; }
    public override List<string> FoodTypes { get; set; }

    public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
    {
        WeightPerPiece = 0.10;
        FoodTypes = new List<string>() { "Vegetable", "Fruit" };

    }
    public override void ProduceSound()
    {
        Console.WriteLine("Squeak");
    }
}

