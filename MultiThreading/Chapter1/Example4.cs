using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MultiThreading
{
    public class Example4
    {
        private static bool done = false;
        public void MainThread()
        {
            Example4 ex = new Example4();

            new Thread(ex.Go).Start();

            ex.Go();

            Console.ReadLine();
        }

        private void Go()
        {

            //instance variable of class Example3 is shared between main thread and the new thread,
            if (!done)
            {
                done = true;  // done will printed once
                Console.Write("DONE");
                //done = true;  //done will be printed twice
            }
        }
    }
}
