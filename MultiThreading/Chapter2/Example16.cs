using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    public class Example16
    {
        static readonly object _locker = new object();
        static int _val1, _val2;


        public void MainThread()
        {
            _val1 = 10;
            _val2 = 5;

            Thread t1 = new Thread(Go);
            t1.Start();
            Go();

            Thread t2 = new Thread(new ThreadStart(Go_Extn));
            t2.Start();


            //Main Thread ... do some work
            //_val2 = 0;

            for (int i = 0; i < 10000; i++)
            {
                if (i % 1000 == 0) Console.WriteLine("-------------------------------------------------------------");

                Console.Write(i + "__");
            }
        }

        public void Go()
        {
            Monitor.Enter(_locker);
            try
            {
                if (_val2 != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("I am in Go : " + _val1 / _val2);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                _val2 = 0;
            }
            catch (Exception ex) { Console.WriteLine("Error : " + ex.Message); }
            finally
            {
                Monitor.Exit(_locker);
            }
        }


        // The issue in the above method is if value of val2 = 0 is assigned first by another thread then, some thread may read it as divide by zero exception.
        // Below is solution for above issue [this is same way the 'lock' is used]

        public void Go_Extn()
        {
            bool lockTaken = false;
            
            try
            {
                Monitor.Enter(_locker, ref lockTaken);

                if (_val2 != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("I am in Go_Extn : " + _val1 / _val2);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                _val2 = 0;
            }
            finally
            {
                if (lockTaken)
                    Monitor.Exit(_locker);
            }
        }
    }
}
