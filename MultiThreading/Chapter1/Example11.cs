using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading
{
    //Task Parallel Library
    public class Example11
    {
        public void MainThread()
        {
            Task.Factory.StartNew(Go);
        }

        private void Go()
        {
            Console.WriteLine("I am here");
        }

        /*
         the nongeneric Task class a replacement for "ThreadPool.QueueUserWorkItem"
         and the generic Task<TResult> a replacement for "asynchronous delegates"
        */
    }
}
