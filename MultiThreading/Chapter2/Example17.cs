using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    public class Example17
    {
        static readonly Object _locker1 = new object();
        static readonly Object _locker2 = new object();


        public void MainThread()
        {
            new Thread(new ThreadStart(Go)).Start();

            //Main Thread ... do Some work here
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("MM_");
            }
        }


        //Nested locking is useful when one method calls another within a lock:
        //A thread can block on only the first (outermost) lock.

        public void Go()
        {
            lock (_locker1)  //<<----
            {
                for (int i = 0; i < 1000; i++)
                    Console.Write("ABC_");

                lock (_locker2)   //<<----
                {
                    for (int i = 0; i < 1000; i++)
                        Console.Write("Y_");
                }
            }
        }
    }
}
