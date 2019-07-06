using System;
using System.Collections.Generic;
using System.Text;


public class Person
{
    private string name;
    private double money;
    public List<Product> Bag { get; private set; }

    public string Name
    {
        get => name;
        private set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            name = value;
        }
    }
    public double Money
    {
        get => money;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            money = value;
        }
    }

    public Person(string name, double money)
    {
        Bag = new List<Product>();
        try
        {
            Name = name;
            Money = money;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            Environment.Exit(0);
        }
    }

    public string BuyProduct(Product product)
    {
        if (Money >= product.Cost)
        {
            Bag.Add(product);
            Money -= product.Cost;
            return $"{Name} bought {product.Name}";
        }

        return $"{Name} can't afford {product.Name}";
    }

    public override string ToString()
    {
        if (Bag.Count == 0)
        {
            return $"{Name} - Nothing bought";
        }
        return $"{Name} - {string.Join(", ", Bag)}";
    }
}

