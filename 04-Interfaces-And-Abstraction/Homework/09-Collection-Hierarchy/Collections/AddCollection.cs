using Collection_Hierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Collection_Hierarchy.Collections
{
    public class AddCollection : List<string>, IAddable
    {
        public int Add(string item)
        {
            int index = Count;

            base.Add(item);

            return index;
        }
    }
}
