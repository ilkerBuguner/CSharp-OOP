using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private Random rnd;

        public RandomList()
        {
            rnd = new Random();
        }

        public string RandomString()
        {
            int index = rnd.Next(this.Count);
            string textToRemove = this[index];
            this.RemoveAt(index);
            return textToRemove;
        }


    }
}
