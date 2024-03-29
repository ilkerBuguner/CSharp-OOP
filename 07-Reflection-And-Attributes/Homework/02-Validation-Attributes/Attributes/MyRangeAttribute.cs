﻿using System;

namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute : MyValiditionAttribute
    {
        private readonly int minValue;
        private readonly int maxValue;
        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            int value = Convert.ToInt32(obj);
            if (value < minValue || value > maxValue)
            {
                return false;
            }

            return true;
        }
    }
}
