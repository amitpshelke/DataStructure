using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MultiThreading
{
    public class Example9
    {
        public void MainThread(string[] args)
        {
            //args = new string[] { "amit" };  //<== uncommenting this will close worker thread before main thread.


            //this line of code will wait for user input even if the application has exited. 
            //if user press ENTER then the worker thread will exit.

            //Here we learn that before exiting main thread all the thread should be closed.
            Thread worker = new Thread(() => Console.ReadLine());


            //if args length is zero then worker thread will wait for user input as said above
            //else it will close exit before main thread.
            if (args.Length > 0)
                worker.IsBackground = true;  

            worker.Start();
        }
    }
}
