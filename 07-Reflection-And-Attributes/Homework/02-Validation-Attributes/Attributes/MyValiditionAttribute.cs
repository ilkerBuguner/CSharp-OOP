using System;

namespace ValidationAttributes.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class MyValiditionAttribute : Attribute
    {
        public abstract bool IsValid(object obj);
    }
}
