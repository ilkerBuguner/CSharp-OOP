using System;
using System.Collections.Generic;
using System.Text;


public class Product
{
    private string name;
    private double cost;

    public string Name
    {
        get => name;
        private set
        {
            if (value == string.Empty)
            {
                throw new ArgumentException("Name cannot be empty");
            }
            name = value;
        }
    }
    public double Cost
    {
        get => cost;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            cost = value;
        }
    }

    public Product(string name, double cost)
    {
        try
        {
            Name = name;
            Cost = cost;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            Environment.Exit(0);
        }
    }

    public override string ToString()
    {
        return Name;
    }
}

