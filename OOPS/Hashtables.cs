using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace OOPS.Hashtables
{
    /*
    HASHTABLE :-
    
    - When it comes to reading data, arrays are great (and fast) because getting to the next element is just 
      a matter of math (i.e. the offset is the size of the type of thing in the array).
    - But when it comes to writing, or more specifically inserting data, linked lists are great because we only need adjust some pointers.
    - A hash table takes the best of these two worlds and smashes them together … sometimes
    
    */

    public class Product
    {
        public int SerialNo { get; set; }
        public string ProductName { get; set; }
    }

    public struct ProductInfo
    {
        public int ProdId;
        public string ProdName;
        public ProductInfo(int _ProdId, string _ProdName)
        {
            this.ProdId = _ProdId;
            this.ProdName = _ProdName;
        }
    }

    public class Client
    {
        public static void Execute()
        {

            Hashtable ht = new Hashtable();  

            List<ProductInfo> lstProdInfo = new List<ProductInfo>();

            Dictionary<int, string> keyValuePairs = new Dictionary<int, string>();

            //Adding item 
            for (int i = 0; i < 4000000; i++)
            {
                ht.Add(i, new Product() { SerialNo = i, ProductName = "Item" + i });

                keyValuePairs.Add(i, "Prod" + i);

                lstProdInfo.Add(new ProductInfo() { ProdId = i, ProdName = "Prod" + i });
            }


            //removing
            if (ht.Contains(2))
                ht.Remove(2);

            if (keyValuePairs.ContainsKey(2))
                keyValuePairs.Remove(2);

            lstProdInfo.Remove(new ProductInfo { ProdId = 2, ProdName = "Prod2" });

            //looping [Below code is commented to avoid unnecessary waiting.]
            //foreach (DictionaryEntry item in ht)
            //Console.WriteLine("Product::Serial No = " + item.Key + "  " + "Product::Price = " + item.Value);


            //--------------------------------------------------------------------------------------------
            //Demonstrate how Hashtable are faster than any other collection
            float startTime = 0;
            float endTime = 0;
            float TotalTime = 0;

            Stopwatch sw = new Stopwatch();
            sw.Start();
            startTime = sw.ElapsedMilliseconds;

            object found = ht[1234567]; //SEARCH

            endTime = sw.ElapsedMilliseconds;
            sw.Stop();

            TotalTime = endTime - startTime;
            Console.WriteLine("Hastable search Time :" + string.Format("{0:0.##}", TotalTime) + "ms");



            sw.Start();
            startTime = sw.ElapsedMilliseconds;

            string prod = keyValuePairs[1234567]; //SEARCH

            endTime = sw.ElapsedMilliseconds;
            sw.Stop();

            TotalTime = endTime - startTime;
            Console.WriteLine("Dictonary search Time :" + string.Format("{0:0.##}", TotalTime) + "ms");




            sw.Start();
            startTime = sw.ElapsedMilliseconds;

            ProductInfo pi = lstProdInfo.Find(x => x.ProdId == 1234567); //SEARCH

            endTime = sw.ElapsedMilliseconds;
            sw.Stop();

            TotalTime = endTime - startTime;
            Console.WriteLine("List search Time :" + string.Format("{0:0.##}", TotalTime) + "ms");




        }
    }
}
