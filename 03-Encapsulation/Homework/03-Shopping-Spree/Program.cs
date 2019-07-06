using System;
using System.Collections.Generic;


public class Program
{
    public static void Main(string[] args)
    {
        Dictionary<string, Person> people = new Dictionary<string, Person>();
        Dictionary<string, Product> products = new Dictionary<string, Product>();

        string[] peopleInfo = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < peopleInfo.Length; i++)
        {
            string[] personInfo = peopleInfo[i].Split("=", StringSplitOptions.RemoveEmptyEntries);
            string name = personInfo[0];
            double money = double.Parse(personInfo[1]);
            Person person = new Person(name, money);

            people[name] = person;

        }

        string[] productsInfo = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < productsInfo.Length; i++)
        {
            string[] productArgs = productsInfo[i].Split("=", StringSplitOptions.RemoveEmptyEntries);
            string name = productArgs[0];
            double cost = double.Parse(productArgs[1]);
            Product product = new Product(name, cost);

            products[name] = product;

        }

        while (true)
        {
            string command = Console.ReadLine();
            if (command == "END")
            {
                break;
            }

            var tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Person person = people[tokens[0]];
            Product product = products[tokens[1]];

            Console.WriteLine(person.BuyProduct(product));
        }

        foreach (var kvp in people)
        {
            Console.WriteLine(kvp.Value);
        }
    }
}

