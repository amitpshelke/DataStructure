using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MultiThreading
{
    /*
    Two-way signaling : 

        Let’s say we want the main thread to signal a worker thread three times in a row. 
        If the main thread simply calls Set on a wait handle several times in rapid succession, the second or third signal may get lost, 
        since the worker may take time to process each signal.

        The solution is for the main thread to wait until the worker’s ready before signaling it. 
        This can be done with another AutoResetEvent, as follows: 
    */


    public class Example23
    {
        EventWaitHandle _ready = new AutoResetEvent(false);
        EventWaitHandle _go = new AutoResetEvent(false);

        static readonly Object _locker = new object();

        static string _message="";


        public void MainThread()
        {
            new Thread(new ThreadStart(Go)).Start();  //Called Go method in another thread

            _ready.WaitOne();
            lock (_locker)
                _message = "uuoooo";
            _go.Set();
            

            _ready.WaitOne();
            lock (_locker)
                _message = "ahhh";
            _go.Set();


            _ready.WaitOne();
            lock (_locker)
                _message = "ouch";
            _go.Set();

        }

        private void Go()  
        {
            while (true)  //this method will execute till the return does not get called out.
            {
                _ready.Set();
                _go.WaitOne();


                lock (_locker)
                {
                    if (_message == "ouch")
                    {
                        Console.WriteLine("Finally :: " + _message);
                        return;
                    }
                    Console.WriteLine(_message);
                }
            }
        }
    }
}
