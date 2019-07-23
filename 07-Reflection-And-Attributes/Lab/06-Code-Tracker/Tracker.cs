using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;


public class Tracker
{
    public static void PrintMethodsByAuthor()
    {
        Type classType = typeof(StartUp);

        MethodInfo[] classMethods = classType.GetMethods(BindingFlags.Instance 
            | BindingFlags.Public | BindingFlags.Static);

        foreach (var method in classMethods)
        {
            if (method.CustomAttributes.Any(n => n.AttributeType == typeof(AuthorAttribute)))
            {
                var attributes = method.GetCustomAttributes(false);
                foreach (AuthorAttribute attribute in attributes)
                {
                    Console.WriteLine($"{method.Name} is written by {attribute.Name}");
                }
            }
        }
    }
}

