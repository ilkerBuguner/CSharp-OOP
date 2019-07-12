using Collection_Hierarchy.Collections;
using System;
using System.Linq;

namespace Collection_Hierarchy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var itemsToAdd = Console.ReadLine().Split().ToArray();

            int removeOperations = int.Parse(Console.ReadLine());

            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            foreach (var item in itemsToAdd)
            {
                Console.Write($"{addCollection.Add(item)} ");
            }

            Console.WriteLine();

            foreach (var item in itemsToAdd)
            {
                Console.Write($"{addRemoveCollection.Add(item)} ");
            }

            Console.WriteLine();

            foreach (var item in itemsToAdd)
            {
                Console.Write($"{myList.Add(item)} ");
            }
            Console.WriteLine();

            for (int i = 0; i < removeOperations; i++)
            {
                Console.Write($"{addRemoveCollection.Remove()} ");
            }

            Console.WriteLine();

            for (int i = 0; i < removeOperations; i++)
            {
                Console.Write($"{myList.Remove()} ");
            }
        }
    }
}
