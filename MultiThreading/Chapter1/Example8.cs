using System;
using System.Threading;

namespace MultiThreading
{
    public class Example8
    {
        public void MainThread()
        {
            Thread.CurrentThread.Name = "main";

            //Method 1: 
            Thread t = new Thread(Go);
            t.Name = "worker";
            t.Start(t.Name);

            //main thread code
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("X");
            }
            Console.WriteLine("I am " + Thread.CurrentThread.Name);

            Console.ReadLine();
        }

        private void Go(object text)
        {
            Console.WriteLine("I am " + text);
        }
    }
}
