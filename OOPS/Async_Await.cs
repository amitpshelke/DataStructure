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

    */


    public class Async_Await
    {
        public static async void callingMethod()
        {
            Task<int> task = Method1();
            Method2();
            int count = await task;
            Method3(count);
            Method4();
        }

       

        public static async Task<int> Method1()
        {
            int count = 0;
            await Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
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

        public static void Method4()
        {
            Console.WriteLine("************************************** Method 4 called **********************************************************");
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
