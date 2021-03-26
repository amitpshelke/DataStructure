using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOPS.ConcurrentCollection
{
    //      https://cc.davelozinski.com/c-sharp/dictionary-vs-concurrentdictionary

    /*
     
    **Thread Safe Concurrent Collection**

    Provides several thread-safe collection classes that should be used in place of the corresponding types in the System.Collections and System.Collections.Generic namespaces 
    whenever multiple threads are accessing the collection concurrently.

    However, access to elements of a collection object through extension methods or through explicit interface implementations are not guaranteed to be thread-safe 
    and may need to be synchronized by the caller.
    
    The .NET framework offers some collection classes specifically used in multithreading. These collections are internally used synchronization 
    hence we can call them thread safe collections. These collections can be accessed by multiple threads at a time hence they are called concurrent collections.


    */

    class ConcurrentCollection
    {
        public void RetrieveData()
        {
            ConcurrentDictionary<string, string> dict = new ConcurrentDictionary<string, string>();
            bool firstItem = dict.TryAdd("1", "First");
            bool secondItem = dict.TryAdd("2", "Second");

            string itemValue1;
            string itemValue2;
            bool isItemExists1 = dict.TryGetValue("1", out itemValue1);  //returns true
            Console.WriteLine(itemValue1); //Print "First"

            bool isItemExists2 = dict.TryGetValue("3", out itemValue2);  //returns false
            Console.WriteLine(itemValue2); //Print blank


            //-----------------------------------------------------------

            ConcurrentDictionary<string, string> dictionary = new ConcurrentDictionary<string, string>();
            dictionary.TryAdd("1", "First");
            dictionary.TryAdd("2", "Second");
            dictionary.TryAdd("3", "Third");
            dictionary.TryAdd("4", "Fourth");

            foreach (var item in dictionary)
            {
                Console.WriteLine(item.Key + "-" + item.Value);
            }

        }

        public void AddRetrieveData()
        {
            ConcurrentDictionary<string, string> dictionary = new ConcurrentDictionary<string, string>();


            Task t1 = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 100; ++i)
                {
                    dictionary.TryAdd(i.ToString(), i.ToString());
                    Thread.Sleep(100);
                }
            });

            Task t2 = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(300);
                foreach (var item in dictionary)
                {
                    Console.WriteLine(item.Key + "-" + item.Value);
                    Thread.Sleep(150);
                }
            });

            try
            {
                Task.WaitAll(t1, t2);
            }
            catch (AggregateException ex) // No exception
            {
                Console.WriteLine(ex.Flatten().Message);
            }
        }

        public void UpdateData()
        {
            ConcurrentDictionary<string, string> dictionary = new ConcurrentDictionary<string, string>();
            dictionary.TryAdd("1", "First");
            dictionary.TryAdd("2", "Second");
            dictionary.TryAdd("3", "Third");
            dictionary.TryAdd("4", "Fourth");

            string newValue;

            bool returnTrue = dictionary.TryUpdate("1", "New Value", "First"); //Returns true
            dictionary.TryGetValue("1", out newValue);
            Console.WriteLine(newValue); //Print "New Value"

            bool returnsFalse = dictionary.TryUpdate("2", "New Value 2", "No Value"); //Returns false
            dictionary.TryGetValue("2", out newValue);  //Returns "Second" Old value
            Console.WriteLine(newValue);    //Print "Second"
        }

        public void DeleteData()
        {
            ConcurrentDictionary<string, string> dictionary1 = new ConcurrentDictionary<string, string>();
            dictionary1.TryAdd("1", "First");
            dictionary1.TryAdd("2", "Second");
            dictionary1.TryAdd("3", "Third");
            dictionary1.TryAdd("4", "Fourth");

            string removedItem;
            bool result = dictionary1.TryRemove("2", out removedItem); //Returns true
            Console.WriteLine(removedItem); //Print "Second"

            //-----------------------------------------------------------

            ConcurrentDictionary<string, string> dictionary2 = new ConcurrentDictionary<string, string>();
            dictionary2.TryAdd("1", "First");
            dictionary2.TryAdd("2", "Second");

            dictionary2.Clear();

            foreach (var item in dictionary2) //enumerate 0 times
            {
                Console.WriteLine(item.Key);
            }
        }

        public void CountData()
        {
            ConcurrentDictionary<string, string> dictionary = new ConcurrentDictionary<string, string>();
            dictionary.TryAdd("1", "First");
            dictionary.TryAdd("2", "Second");
            dictionary.TryAdd("3", "Third");
            dictionary.TryAdd("4", "Fourth");

            int totalItems = dictionary.Count(); // Returns 4

            int filterItems = dictionary.Count(w => w.Value.ToLower().Contains("t")); //Returns 3
        }

        public void IsDataExist()
        {
            ConcurrentDictionary<string, string> dictionary = new ConcurrentDictionary<string, string>();
            dictionary.TryAdd("1", "First");
            dictionary.TryAdd("2", "Second");
            dictionary.TryAdd("3", "Third");
            dictionary.TryAdd("4", "Fourth");

            bool firstItemFound = dictionary.ContainsKey("1"); //Returns true
            bool fifthItemFound = dictionary.ContainsKey("5"); //Returns false
        }

        public void CopyData()
        {
            ConcurrentDictionary<string, string> dictionary = new ConcurrentDictionary<string, string>();
            dictionary.TryAdd("1", "First");
            dictionary.TryAdd("2", "Second");
            dictionary.TryAdd("3", "Third");
            dictionary.TryAdd("4", "Fourth");

            KeyValuePair<string, string>[] keyValues = dictionary.ToArray();

            Dictionary<string, string> dict = dictionary.ToDictionary(w => w.Key, m => m.Value);

            List<KeyValuePair<string, string>> lst = dict.ToList();

            ILookup<string, string> lookup = dict.ToLookup(w => w.Key, m => m.Value);
        }
    }

    public class Client
    {
        public static void Execute()
        {
            ConcurrentCollection cc = new ConcurrentCollection();
            cc.RetrieveData();
            cc.AddRetrieveData();
            cc.UpdateData();
            cc.DeleteData();
            cc.CountData();
            cc.IsDataExist();
            cc.CopyData();
        }
    }
}
