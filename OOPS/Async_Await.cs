using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


 

namespace OOPS.Async_AwaitExample
{
    /*
        async and await keyword must be used in pair, cannot be use alone. 

        Await method will wait untill it is completed then the main thread will get executed.

        Async and await are the code markers, which marks code positions from where the control should resume after a task completes.

        1. Method1 will start its execution, since its a long running it will take time 
        2. Method2 will also start its execution, since its a less time consuming task it will get completed early
        3. Method4 will also start its execution, since its a less time consuming task it will get completed early
        4. Now the cursor will go to await till the Method1 task get completed at line of code [int count = await task;]
        5. Once the Method1 execution is complete, the output of the Method1 will be input to the Method3

    
    **** TPL vs async/await ?  (when it comes to thread creation)
    
    
         TPL (TaskFactory.StartNew) works similar to ThreadPool.QueueUserWorkItem in that it queues up work on a thread in the thread pool. 
         That's of course unless you use TaskCreationOptions.LongRunning which creates a new thread.

         TaskCreationOptions.LongRunning does not guarantee a "new thread"
    
         Factory.StartNew( () => DoSomeAsyncWork() )
                .ContinueWith( (antecedent) => {
                                                 DoSomeWorkAfter(); 
                                                },TaskScheduler.FromCurrentSynchronizationContext());

         Actually, async/await never does. 
         If you want multithreading, you have to implement it yourself. 
         There's a new Task.Run method that is just shorthand for Task.Factory.StartNew, and it's probably the most common way of starting a task on the thread pool.

         The cool thing about async/await is that you can 
         - queue some work to the thread pool (e.g., Task.Run), 
         - do some I/O-bound operation (e.g., Stream.ReadAsync), 
         - do some other operation (e.g., Task.Delay)
         
         ... and they're all tasks! 
         
        They can be awaited or used in combinations like Task.WhenAll.
         
        Any method that returns Task can be awaited - it doesn't have to be an async method. 

        Regarding "concurrency" vs "multithreading", async enables concurrency, which may or may not be multithreaded. 

        It's easy to use await Task.WhenAll or await Task.WhenAny to do concurrent processing, 
        and unless you explicitly use the thread pool (e.g., Task.Run or ConfigureAwait(false)), 
        then you can have multiple concurrent operations in progress at the same time (e.g., multiple I/O or other types like Delay) - and there is no thread needed for them. 
        
        I use the term "single-threaded concurrency" for this kind of scenario>


        [Short description : Await is like a unary operator: it takes a single argument, an awaitable (an “awaitable” is an asynchronous operation).]
        
        - Await examines that awaitable to see if it has already completed; if the awaitable has already completed, 
          then the method just continues running (synchronously, just like a regular method).
        - If “await” sees that the awaitable has not completed, then it acts asynchronously. 
          It tells the awaitable to run the remainder of the method when it completes, and then returns from the async method.
        - Later on, when the awaitable completes, it will execute the remainder of the async method. If you’re awaiting a built-in 
          awaitable (such as a task), then the remainder of the async method will execute on a “context” that was captured before the “await” returned.
        - The async method pauses until the awaitable is complete (so it waits), but the actual thread is not blocked (so it’s asynchronous).

        
          
         ** Async methods can return Task<T>, Task, or void. 

   
        https://blog.stephencleary.com/2012/02/async-and-await.html

        https://docs.microsoft.com/en-us/archive/msdn-magazine/2011/february/msdn-magazine-parallel-computing-it-s-all-about-the-synchronizationcontext

        https://blog.stephencleary.com/2010/08/various-implementations-of-asynchronous.html

        https://channel9.msdn.com/Events/TechEd/Europe/2013/DEV-B318
    */


    public class Async_Await
    {
        public static async void callingMethod()
        {
            Task<int> task = Method1();
            Method2();
            int count = await task;
            Method3(count);
            count = await task;
            Method4(count);
        }

        public static async Task<int> Method1()
        {
            int count = 0;
            await Task.Run(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    Console.Write("Method 1 ");
                    count += 1;
                }
            });
            return count;
        }

        public static void Method2()
        {
            for (int i = 0; i < 25; i++)
            {
                Console.WriteLine("Method 2");
            }
        }

        public static void Method3(int count)
        {
            Console.WriteLine("Method3 : Total count is " + count);
        }

        public static void Method4(int count)
        {
            Console.WriteLine("************************************** Method 4 called **********************************************************");
            Console.WriteLine("Total Count: " + count);
        }
    }




    public class Client
    {
        public static void Execute()
        {
            Async_Await.callingMethod();
            //Async_Await.Method4();      //if this line is uncommented then Method3 will not be called. As the cursor comes out of the callingMethod.
        }
    }
}
