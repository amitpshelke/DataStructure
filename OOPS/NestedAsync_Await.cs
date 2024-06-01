using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.NestedAsync_AwaitExample
{
    public class NestedAsync_Await
    {
        public static async void callingMethod() //Calling method
        {
            Task<int> task = Method1();
            int count = await task;
        }

        public static async Task<int> Method1()
        {
            int count = 0;
            await Task.Run(Method2);
            Console.Write("Method 1 ");
            return count;
        }
        public static async Task<int> Method2()
        {
            int count = 0;
            await Task.Run(Method3);
            Console.Write("Method 2 ");
            return count;
        }

        public static async Task<int> Method3()
        {
            int count = 0;
            await Task.Run(Method4);
            Console.Write("Method 3 ");
            return count;
        }

        public static async Task<int> Method4()
        {
            int count = 0;
            await Task.Run(() =>
            {
                for (int i = 0; i < 10000000; i++)
                {
                    //Console.Write("Method 4 ");
                    count += 1;
                }
                //Console.Write("Method 4 ");
            });
            Console.Write("Method 4 ");
            return count;
        }

        public class Client
        {
            public static void Execute()
            {
                NestedAsync_Await.callingMethod();
            }
        }

    }
}
