using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MultiThreading
{

    //Thread Pool Without TPL 
    public class Example13
    {
        public void MainThread()
        {
            //here first parameter is input, second is return value of the function Work()
            Func<string, int> method = Work;

            IAsyncResult asyncResult = method.BeginInvoke("Worker Test", null, null);

            //main thread
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("executing main thread");
            }

            /*
            EndInvoke() does three things. 
            1 .It waits for the asynchronous delegate to finish executing, if it hasn’t already. 
            2. It receives the return value (as well as any ref or out parameters). 
            3. It throws any unhandled worker exception back to the calling thread.
            */

            int result = method.EndInvoke(asyncResult);

            Console.WriteLine("String Length :" + result);

            Console.ReadLine();
        }


        private int Work(string s)
        {
            return s.Length;
        }
    }
}
