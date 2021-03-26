using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    /*
    A Mutex is like a C# lock, but it can work across multiple processes. 
    In other words, Mutex can be computer-wide as well as application-wide. 
    
    A common use for a cross-process Mutex is to ensure that only one instance of a program can run at a time.   
    */

    class Example19
    {
        static void Main_new() // Rename this method to Main and the Mutex 
        {
            using (var mutex = new Mutex(false, "Mutex Started..."))
            {
                if (!mutex.WaitOne(TimeSpan.FromSeconds(3), false))
                {
                    Console.WriteLine("Another Instance of this program is already running.");
                    return;
                }

                RunProgram();
            }
        }

        private static void RunProgram()
        {
            Console.WriteLine("Running. Press Enter to exit");
            Console.ReadLine();
        }
    }
}
