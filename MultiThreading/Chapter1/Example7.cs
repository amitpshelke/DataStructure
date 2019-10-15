using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MultiThreading
{
    public class Example7
    {
        public void MainThread()
        {
            //Method 1: 
            Thread t = new Thread(Go);
            t.Start("seperate Thread");


            //Method 2: 
            Thread tx = new Thread(() => 
            {
                Go("the other way to write above code");
            });
            tx.Start();

            //main thread code
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("X");
            }

            Console.ReadLine();

        }

        private void Go(object text)
        {
            Console.WriteLine("I am " + text);
        }
    }
}
