using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MultiThreading
{
    public class Example1
    {
        public void MainThread()
        {

            //Method 1: 
            Thread t = new Thread(Go);
            t.Start();

            //Method 2: the above code can be written as
            Thread tx = new Thread(new ThreadStart(Go));
            tx.Start();

            //Method 3: alternatively Lambda expresion or anonymous method can be use to define same functionality as above 
            Thread tz = new Thread(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    Console.Write("Y");
                }
            });
            tz.Start();



            //main thread code
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("X");
            }

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
