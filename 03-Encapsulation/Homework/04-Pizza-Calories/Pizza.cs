using System;
using System.Collections.Generic;
using System.Linq;


public class Pizza
{
    private string name;
    public string Name
    {
        get => name;
        private set
        {
            if (value.Length < 1 || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            name = value;
        }
    }

    private List<Topping> toppings;

    public Dough Dough { get; private set; }

    public int ToppingCount => toppings.Count;

    public double Calories => CalculateCalories();
    public Pizza(string name, Dough dough)
    {
        Name = name;
        Dough = dough;
        toppings = new List<Topping>();
    }

    public void AddTopping(Topping topping)
    {
        if (ToppingCount >= 10)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }
        toppings.Add(topping);
    }

    private double CalculateCalories()
    {
        if (ToppingCount > 0)
        {
            return Dough.Calories + toppings.Select(x => x.Calories).Sum();
        }
        return Dough.Calories;
    }

    public override string ToString()
    {
        return $"{Name} - {Calories:F2} Calories.";
    }

}

