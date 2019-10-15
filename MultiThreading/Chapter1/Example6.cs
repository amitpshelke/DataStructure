using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MultiThreading
{
    public class Example6
    {
        public void MainThread()
        {
            Thread t= new Thread(Go);
            t.Start();
            
            t.Join();  // if this line is commented the "Thread t ended" message will be printed first else will be printed last"

            Thread.Sleep(3000);  // this will put main thread to sleep for 3 seconds
            Console.WriteLine("Thread t ended.");

            Console.ReadLine();
        }

        private void Go()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("Y");
            }
        }
    }
}
