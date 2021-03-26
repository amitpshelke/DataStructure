using System;
using System.Collections.Generic;

namespace OOPS.Enumerables
{
    public class Enumerables
    {
        public void InsertListSample1()
        {
            Console.WriteLine("=========================== Sample 1 =================================");

            List<int> oyears = new List<int>();
            oyears.Add(1990);
            oyears.Add(1991);
            oyears.Add(1992);
            oyears.Add(1993);
            oyears.Add(2001);
            oyears.Add(2002);
            oyears.Add(2003);


            //IEnumerable internally uses IEnumerator
            //IEnumerable is made to use it
            IEnumerable<int> ienum = (IEnumerable<int>)oyears;
            foreach (var item in ienum)
            {
                Console.WriteLine(item);
            }


            //IEnumerator remembers the state of which item it is iterating through.
            IEnumerator<int> enumerate = oyears.GetEnumerator();
            while (enumerate.MoveNext())
            {
                Console.WriteLine(enumerate.Current.ToString());
            }

            
        }


        //In this function we are using IEnumerator 
        public void InsertListSample2()
        {
            Console.WriteLine("=========================== Sample 2 =================================");

            List<int> oyears = new List<int>();
            oyears.Add(1990);
            oyears.Add(1991);
            oyears.Add(1992);
            oyears.Add(1993);
            oyears.Add(2001);
            oyears.Add(2002);
            oyears.Add(2003);

            IEnumerator<int> enumerate = oyears.GetEnumerator();
            Iterate1900to2000(enumerate);
           

            Console.ReadKey();
        }

        private void Iterate1900to2000(IEnumerator<int> o)
        {
            while (o.MoveNext())
            {
                Console.WriteLine(o.Current.ToString());
                if (Convert.ToInt16(o.Current) > 2000)
                    Iterate2001to2020(o);
            }
        }

        private void Iterate2001to2020(IEnumerator<int> o)
        {
            while (o.MoveNext())
            {
                Console.WriteLine(o.Current.ToString());
            }
        }



        //In this function we are using IEnumerable 
        public void InsertListSample3()
        {
            Console.WriteLine("=========================== Sample 3 =================================");

            List<int> oyears = new List<int>();
            oyears.Add(1990);
            oyears.Add(1991);
            oyears.Add(1992);
            oyears.Add(1993);
            oyears.Add(2001);
            oyears.Add(2002);
            oyears.Add(2003);

            IEnumerable<int> ienum = (IEnumerable<int>)oyears;
            Iterate1900to2000(ienum);


            Console.ReadKey();
        }

        private void Iterate1900to2000(IEnumerable<int> o)
        {
            foreach (var item in o)
            {
                Console.WriteLine(item);
                if (Convert.ToInt16(item) > 2000)
                    Iterate2001to2020(o);
            }
        }

        private void Iterate2001to2020(IEnumerable<int> o)
        {
            foreach (var item in o)
            {
                Console.WriteLine(item);
            }
        }

    }


    public class Client
    {
        public static void Execute()
        {
            Enumerables e = new Enumerables();
            e.InsertListSample1();
            e.InsertListSample2();
            e.InsertListSample3();
        }
    }
}
