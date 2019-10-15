using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MultiThreading
{
    public class Example5
    {
        private static bool done = false;
        static readonly object locker = new object();

        public void MainThread()
        {
            Example5 ex = new Example5();

            new Thread(ex.Go).Start();

            ex.Go();

            Console.ReadLine();
        }

        private void Go()
        {
            lock (locker)
            {
                if (!done)
                {
                    done = true;   // in both case done will be printed once due to locker object
                    Console.Write("DONE");
                    //done = true;
                }
            }
        }
    }
}
