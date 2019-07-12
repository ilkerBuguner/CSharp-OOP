using Collection_Hierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Collection_Hierarchy.Collections
{
    public class MyList : List<string>, IAddable, IRemoveable
    {
        public int Used => Count;
        public int Add(string item)
        {
            base.Insert(0, item);

            return 0;
        }

        public string Remove()
        {
            string item = base[0];
            base.RemoveAt(0);
            return item;
        }
    }
}
