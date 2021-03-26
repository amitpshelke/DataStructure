using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    public class Example21
    {
        // .NET Framework: static members are thread-safe; instance members are not.


        //In this case, we’re locking on the _list object itself. If we had two interrelated lists, we would have to choose a common object upon which to lock

        //Enumerating .NET collections is also thread-unsafe in the sense that an exception is thrown if the list is modified during enumeration. 
        //Rather than locking for the duration of enumeration, in this example we first copy the items to an array. 
        //This avoids holding the lock excessively if what we’re doing during enumeration is potentially time-consuming.

        static List<string> _List = new List<string>();

        public void MainThread()
        {
            new Thread(new ThreadStart(Go)).Start();
            new Thread(new ThreadStart(Go)).Start();
        }

        public void Go()
        {
            string[] items;

            lock (_List)
                _List.Add("Item : " + _List.Count);

            lock (_List)
                items = _List.ToArray();

            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
