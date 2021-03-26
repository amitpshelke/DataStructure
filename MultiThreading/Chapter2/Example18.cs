using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    //DEADLOCK : A deadlock happens when two threads each wait for a resource held by the other, so neither can proceed. 
    //The easiest way to illustrate this is with two locks:

    /*
    Another deadlocking scenario arises when calling Dispatcher.Invoke (in a WPF application) or 
    Control.Invoke (in a Windows Forms application) while in possession of a lock. 
    If the UI happens to be running another method that’s waiting on the same lock, a deadlock will happen right there. 
    This can often be fixed simply by calling BeginInvoke instead of Invoke.  
    */


    public class Example18
    {
        static readonly object _locker1 = new object();
        static readonly object _locker2 = new object();

        public void MainThread()
        {
            new Thread(() =>
            {
                lock (_locker1)
                {
                    Console.WriteLine("Inside Lock 1 : 1");
                    Thread.Sleep(1000);

                    lock (_locker2)
                    {
                        Console.WriteLine("Inside Lock 2 : 1");
                    };  //DEADLock
                }
            }
            
            ).Start();


            lock (_locker2)
            {
                Console.WriteLine("Inside Lock 2 : 2"); //DEADLock
                Thread.Sleep(1000);
                lock (_locker1)
                {
                    Console.WriteLine("Inside Lock 1 : 2"); //DEADLock
                };  
            }
        }
    }
}
