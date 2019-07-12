using Collection_Hierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Collection_Hierarchy.Collections
{
    class AddRemoveCollection : List<string>, IAddable, IRemoveable
    {
        public string Remove()
        {
            string item = base[Count - 1];
            base.RemoveAt(base.Count - 1);
            return item;
        }

        public int Add(string item)
        {
            base.Insert(0, item);

            return 0;
        }
    }
}
