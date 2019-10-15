using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading
{

    //Thread Pool via TPL 
    //TPL with generic Task<T> class
    public class Example12
    {
        public void MainThread()
        {
            //Start the new Task here
            Task<string> task = Task.Factory.StartNew<string>( ()=> Go("http://www.linqpad.net"));

            //Do some other work
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Doing some other work.");
            }


            // When we need the task's return value, we query its Result property:
            // If it's still executing, the current thread will now block (wait)
            // until the task finishes:
            string result = task.Result;

            Console.ReadLine();

        }

        private string Go(string URI)
        {
            using (var wc = new WebClient())
            {
                string result = wc.DownloadString(URI);
                Console.WriteLine("Result : " + result);
                return result;
            }
        }
    }




    //**************** Thread Pool Without TPL ********************


    //The version before .net Framework 4.0 TPL was not available so the other way to pool thread is using below code
    /*
        ThreadPool.QueueUserWorkItem(Go);
        ThreadPool.QueueUserWorkItem(Go, 123);

        //data will be null with the first call
        private void Go (object data)   
        {
            Console.WriteLine ("Hello from the thread pool! " + data);
        }
    */
}
