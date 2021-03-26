using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.CollectionSample
{
    public class Collection<T> : CollectionBase 
    {
        public void Add(Object item)
        {
            InnerList.Add(item);
        }

        public void Remove(Object item)
        {
            InnerList.Remove(item);
        }

        public new int Count()
        {
            return InnerList.Count;
        }

        public new void Clear()
        {
            InnerList.Clear();
        }
    }


    public class Client
    {
        public static void Execute()
        {
            Collection<string> cs = new Collection<string>();
            cs.Add("Nichole");
            cs.Add("Bob");
            cs.Add("John");
            cs.Add("Travis");

            cs.Remove("Bob");

            cs.Count();
            cs.Clear();
        }
    }

}
