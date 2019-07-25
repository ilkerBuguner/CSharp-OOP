using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Utilities
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] propertyInfos = obj.GetType().GetProperties();

            foreach (var property in propertyInfos)
            {
                MyValiditionAttribute[] attributes = property
                    .GetCustomAttributes()
                    .Where(a => a is MyValiditionAttribute)
                    .Cast<MyValiditionAttribute>()
                    .ToArray();

                foreach (MyValiditionAttribute attribute in attributes)
                {
                    if (!attribute.IsValid(property.GetValue(obj)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
