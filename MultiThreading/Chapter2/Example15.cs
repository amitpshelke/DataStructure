using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MultiThreading
{
    public class Example15
    {
        static int _val1 = 1, _val2 = 1;

        public void MainThread()
        {
            Thread t1 = new Thread(Go);
            t1.Start("1.");

            Thread t2 = new Thread(Go);
            t2.Start("2.");

            Console.ReadLine();
        }

        private void Go(object call)
        {
            if (_val2 != 0)
                Console.WriteLine(call +  " GO Called : " + _val1 / _val2);

            _val2 = 0;

            Thread.Sleep(5000);
        }

    }
}
