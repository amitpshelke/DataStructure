using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MultiThreading
{
    /*
    A producer/consumer queue is a common requirement in threading. Here’s how it works:

          - A queue is set up to describe work items — or data upon which work is performed.
          - When a task needs executing, it’s enqueued, allowing the caller to get on with other things.
          - One or more worker threads plug away in the background, picking off and executing queued items. 

        The advantage of this model is that you have precise control over how many worker threads execute at once. 
        This can allow you to limit consumption of not only CPU time, but other resources as well. 
         

        Framework 4.0 provides a new class called BlockingCollection<T> that implements the functionality of a producer/consumer queue.
    */


    public class ProducerConsumerQueue : IDisposable
    {
        EventWaitHandle ewh = new AutoResetEvent(false);
        Thread worker;

        readonly object locker = new object();
        Queue<string> queue = new Queue<string>();

        public ProducerConsumerQueue()
        {
            worker = new Thread(new ThreadStart(Work));
            worker.Start();
        }


        public void Work()
        {
            while (true)
            {
                string Task = null;
                lock (locker)
                {
                    if (queue.Count > 0)
                    {
                        Task = queue.Dequeue();

                        if (Task == null)
                            return;
                    }

                    if (Task != null)
                    {
                        Console.WriteLine("Performing task : " + Task);
                        Thread.Sleep(2000); //this is to simulate some work is being done and taking sometime
                    }
                    else
                        ewh.WaitOne();
                }
            }
        }

        public void EnqueueTask(string TaskName)
        {
            lock (locker)
            {
                queue.Enqueue(TaskName);
                ewh.Set();
            }
        }

        public void Dispose()
        {
            EnqueueTask(null);
            worker.Join();
            ewh.Close();
        }
    }


    public class Example24
    {
        public void MainThread()
        {
            using (ProducerConsumerQueue pcq = new ProducerConsumerQueue())
            {
                pcq.EnqueueTask("Hello Task");

                for (int i = 0; i < 10; i++)
                    pcq.EnqueueTask(" Loop Task : " + i);

                pcq.EnqueueTask("bye Task");
            }
        }
    }
}
