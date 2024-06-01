using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.CollectionSample
{
    /*
    C# allows you to define generic classes, interfaces, abstract classes, fields, methods, static methods, properties, events, delegates, and operators 
    using the type parameter and without the specific data type. A type parameter is a placeholder for a particular type specified when creating an 
    instance of the generic type.

    A generic type is declared by specifying a type parameter in an angle brackets after a type name, 
    e.g. TypeName<T> where T is a type parameter.
    C# allows you to define generic classes, interfaces, abstract classes, fields, methods, static methods, properties, events, delegates, 
    and operators using the type parameter and without the specific data type. 
    A type parameter is a placeholder for a particular type specified when creating an instance of the generic type.

    A generic type is declared by specifying a type parameter in an angle brackets after a type name, e.g. TypeName<T> where T is a type parameter. 
         
    */


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
