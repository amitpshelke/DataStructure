using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    public class Example20
    {
        static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(3); // capacity of 3

        public void MainThread()
        {
            Thread.Sleep(2000);

            for (int i = 1; i < 6; i++)
            { 
                new Thread(Go).Start(i);
            }
        }


        //Only three thread can stay at one time.
        public void Go(object id)
        {
            Console.WriteLine(id + "Wants to enter");
            semaphoreSlim.Wait();

            Console.WriteLine(id + "is in"); 
            Thread.Sleep(1000 * (int)id);

            Console.WriteLine(id + "is leaving");
            semaphoreSlim.Release();
        }
    }
}
