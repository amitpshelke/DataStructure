using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MultiThreading
{
    public class Example2
    {
        public void MainThread()
        {
            new Thread(Go).Start();

            Go();

            Console.ReadLine();

            //output will be 10 question marks
        }

        private void Go()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write("?");
            }
        }
    }
}
