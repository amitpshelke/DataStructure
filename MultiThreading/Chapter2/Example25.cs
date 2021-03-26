using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    /*
        CountdownEvent lets you wait on more than one thread.
        Like ManualResetEventSlim, CountdownEvent exposes a WaitHandle property for scenarios where some other class or method expects an object based on WaitHandle.

    */

    public class Example25
    {
        //To use CountdownEvent, instantiate the class with the number of threads or “counts” that you want to wait on:
        static CountdownEvent _countdown = new CountdownEvent(4);

        public void MainThread()
        {
            new Thread(Print).Start("I am thread 1");
            new Thread(Print_Extn).Start("I am thread 2");
            new Thread(Print_Extn).Start("I am thread 3");
            new Thread(Print_Extn).Start("I am thread 4");

            _countdown.Wait();   // Blocks until Signal has been called 4 times, so this class Print is calling once and Print_Extn is calling 3 times
            Console.WriteLine("All threads have finished speaking!");
        }



        public void Print(object message)
        {
            Thread.Sleep(5000); //3 thread will wait for this timer

            Console.WriteLine(message);

            if (_countdown.IsSet == false) 
                _countdown.Signal(); //once this line is executed, all the waiting thread will start executing.
        }


        public void Print_Extn(object message)
        {
            Console.WriteLine("Extn : " + message);
            _countdown.Signal();    

        }
    }
}
