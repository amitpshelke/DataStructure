using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Contexts;
using System.Threading;

namespace MultiThreading
{
    /*
	An alternative to locking manually is to lock declaratively. 
	By deriving from ContextBoundObject and applying the Synchronization attribute, you instruct the CLR to apply locking automatically.
	
    The CLR ensures that only one thread can execute code in safeInstance at a time. 
	It does this by creating a single synchronizing object — and locking it around every call to each of safeInstance's methods or properties. 
	The scope of the lock — in this case, the safeInstance object — is called a synchronization context.

    
	System.Runtime.Remoting.Contexts. A ContextBoundObject can be thought of as a “remote” object, meaning all method calls are intercepted. 
	To make this interception possible, when we instantiate AutoLock, the CLR actually returns a proxy — an object with the same methods and 
	properties of an AutoLock object, which acts as an intermediary. 
	
    It's via this intermediary that the automatic locking takes place. Overall, the interception adds around a microsecond to each method call.	 
     */



    public class Example26
    {
        public void MainThread()
        {
            AutoLock safeInstance = new AutoLock();

            new Thread(safeInstance.Demo).Start();     // Call the Demo

            new Thread(safeInstance.Demo).Start();     // method 3 times

            safeInstance.Demo();                        // concurrently.
        }
    }

    [Synchronization]
    public class AutoLock : ContextBoundObject
    {
        public void Demo()
        {
            Console.Write("Start...");
            Thread.Sleep(1000);           // We can't be preempted here
            Console.WriteLine("end");     // thanks to automatic locking!
        }
    }
}
