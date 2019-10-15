using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MultiThreading
{
    public class Example10
    {
        public void MainThread()
        {
            try
            {
                Thread t = new Thread(Go);
                t.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Caught"); // this line will never executed as every thread has an independent excution path
            }
        }

        private void Go()
        {
            throw null; // this throws a NullReferenceException
        }

        private void Go_Extn()
        {
            try
            {
                throw null;    //The NullReferenceException will get caught below
            }
            catch (Exception e)
            {
                // Typically log the exception, and/or signal another thread that we've come unstuck
            }
        }
    }


    //Note : So the remedy to above code, is to move try catch to Go()
    
    
    /* There are, however, some cases where you don’t need to handle exceptions on a worker thread, 
       because the.NET Framework does it for you.These are covered in upcoming sections, and are:
        • Asynchronous delegates 
        • BackgroundWorker
        •The Task Parallel Library (conditions apply)
   */
}
