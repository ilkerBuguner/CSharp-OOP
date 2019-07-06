using System;
using System.Collections.Generic;
using System.Text;

public class Box
{
    private double length;
    private double width;
    private double height;

    private double Length
    {
        get => length;
        set
        {
            if (value < 1)
            {
                throw new ArgumentException("Length cannot be zero or negative.");
            }
            length = value;
        }
    }
    private double Width
    {
        get => width;
        set
        {
            if (value < 1)
            {
                throw new ArgumentException("Width cannot be zero or negative.");
            }
            width = value;
        }
    }
    private double Height
    {
        get => height;
        set
        {
            if (value < 1)
            {
                throw new ArgumentException("Height cannot be zero or negative.");
            }
            height = value;
        }
    }

    public Box(double length, double width, double height)
    {
        try
        {
            Length = length;
            Width = width;
            Height = height;
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
            Environment.Exit(0);
        }
    }
    public double CalculateSurfaceArea()
    {
        double surfaceArea = (2 * length * width) + (2 * length * height) + (2 * width * height);
        return surfaceArea;
    }

    public double CalculateLateralSurfaceArea()
    {
        double lateralSurfaceArea = (2 * length * height) + (2 * width * height);
        return lateralSurfaceArea;
    }

    public double CalculateVolume()
    {
        double volume = length * width * height;
        return volume;
    }
}

