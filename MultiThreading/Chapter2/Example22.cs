using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MultiThreading
{
    //Event wait handles are used for signaling. Signaling is when one thread waits until it receives notification from another.

    public class Example22
    {
        //base b = new derived();
        static EventWaitHandle ewh = new AutoResetEvent(false);

        public void MainThread()
        {
            new Thread(Go).Start();

            Thread.Sleep(5000);

            Console.WriteLine("1");
            ewh.Set();
            Console.WriteLine("2");

            /*
             Once you’ve finished with a wait handle, you can call its Close method to release the operating system resource. 
             Alternatively, you can simply drop all references to the wait handle and allow the garbage collector to do the job for you sometime 
             later (wait handles implement the disposal pattern whereby the finalizer calls Close).
            
             Wait handles are released automatically when an application domain unloads.
            */

            ewh.Close();
        }

        private void Go()
        {
            Console.WriteLine("Waiting...");

            ewh.WaitOne(); //it will wait till the Set method is not called, thus it waits for a signal from ewh object

            Console.WriteLine("Notified");
        }
    }
}
