using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;


public class Spy
{
    public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
    {
        Type classInfo = Type.GetType(investigatedClass);

        FieldInfo[] classFields = classInfo.GetFields(BindingFlags.Static | BindingFlags.NonPublic
            | BindingFlags.Public | BindingFlags.Instance);

        Object classInstance = Activator.CreateInstance(classInfo, new Object[] { });

        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Class under investigation: {investigatedClass}");

        foreach (var field in classFields.Where(x => requestedFields.Contains(x.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return sb.ToString().Trim();
    }
}

