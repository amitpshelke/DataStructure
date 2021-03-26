using System;
using System.Threading;

namespace MultiThreading
{
    public class Example3
    {
        private bool done = false;
        public void MainThread()
        {
            Example3 ex = new Example3();

            new Thread(ex.Go).Start();

            ex.Go();

            Console.ReadLine();
        }

        private void Go()
        {

            //instance variable of class Example3 is shared between main thread and the new thread,
            if (!done)
            {
                //done = true;
                Console.WriteLine("DONE");
                done = false;
            }
            else
            {
                Console.WriteLine("GO called again.");
            }
        }
    }
}
