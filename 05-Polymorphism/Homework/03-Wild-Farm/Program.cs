using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        List<Animal> animals = new List<Animal>();

        Animal currentAnimal = null;
        int currentLine = 0;

        while (true)
        {
            string command = Console.ReadLine();

            if (command == "End")
            {
                break;
            }

            string[] tokens = command.Split();

            if (currentLine == 0 || currentLine % 2 == 0)
            {
                Animal animal = null;

                string name = tokens[1];
                double weight = double.Parse(tokens[2]);

                if (tokens[0] == "Cat")
                {
                    string livingRegion = tokens[3];
                    string breed = tokens[4];

                    animal = new Cat(name, weight, livingRegion, breed);
                    animals.Add(animal);
                }
                else if (tokens[0] == "Tiger")
                {
                    string livingRegion = tokens[3];
                    string breed = tokens[4];

                    animal = new Tiger(name, weight, livingRegion, breed);
                    animals.Add(animal);
                }
                else if (tokens[0] == "Dog")
                {
                    string livingRegion = tokens[3];

                    animal = new Dog(name, weight, livingRegion);
                    animals.Add(animal);
                }
                else if (tokens[0] == "Mouse")
                {
                    string livingRegion = tokens[3];

                    animal = new Mouse(name, weight, livingRegion);
                    animals.Add(animal);
                }
                else if (tokens[0] == "Hen")
                {
                    double wingSize = double.Parse(tokens[3]);
                    animal = new Hen(name, weight, wingSize);
                    animals.Add(animal);
                }
                else if (tokens[0] == "Owl")
                {
                    double wingSize = double.Parse(tokens[3]);
                    animal = new Owl(name, weight, wingSize);
                    animals.Add(animal);
                }

                currentAnimal = animal;
                animal.ProduceSound();
            }
            else
            {
                int quantity = int.Parse(tokens[1]);
                try
                {
                    if (tokens[0] == "Fruit")
                    {
                        Fruit fruit = new Fruit(quantity);
                        currentAnimal.Eat(fruit);
                    }
                    else if (tokens[0] == "Meat")
                    {
                        Meat meat = new Meat(quantity);
                        currentAnimal.Eat(meat);
                    }
                    else if (tokens[0] == "Seeds")
                    {
                        Seeds seeds = new Seeds(quantity);
                        currentAnimal.Eat(seeds);
                    }
                    else if (tokens[0] == "Vegetable")
                    {
                        Vegetable vegetable = new Vegetable(quantity);
                        currentAnimal.Eat(vegetable);
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }

            currentLine++;
        }

        foreach (var animal in animals)
        {
            Console.WriteLine(animal);
        }
    }
}

