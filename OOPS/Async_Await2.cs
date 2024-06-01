using System;
using System.Threading.Tasks;

namespace OOPS.Async_AwaitExample2
{
    public class Async_Await2
    {
        public static async Task DoOperationsConcurrentlyAsync()
        {
            Task[] tasks = new Task[3];
            tasks[0] = DoOperation0Async("A");
            tasks[1] = DoOperation0Async("B");
            tasks[2] = DoOperation0Async("C");

            // At this point, all three tasks are running at the same time.

            // Now, we await them all.
            await Task.WhenAll(tasks);
            Console.WriteLine("All Task Completed.");
        }

        public static async Task DoOperation0Async(string call)
        {
            int count = 0;
            await Task.Run(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    Console.WriteLine($"{call}:{count}");
                    count += 1;
                }

                Console.WriteLine($"Completed Task : {call}");
            });
        }
    }
    public class Async_Await3
    {
        public static async Task GetFirstToRespondAsync()
        {
            // Call two web services; take the first response.
            Task<string>[] tasks = new[] {
                                    WebServiceAsync("WebService1"),
                                    WebServiceAsync("WebService2"),
                                    WebServiceAsync("WebService3")
                                 };

            // Await for the first one to respond.
            Task<string> firstTask = await Task<string>.WhenAny(tasks);

            Console.WriteLine(firstTask.Result);
        }

        public static async Task<string> WebServiceAsync(string call)
        {
            int count = 0;
            string message = "";
            await Task.Run(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    Console.WriteLine($"{call}:{count}");
                    count += 1;
                }

                if (count == 1000)
                    message = $"Task completed {call}";
            });

           
            return message;
        }
    }

    public class Client
    {
        public static void Execute()
        {
            Async_Await2.DoOperationsConcurrentlyAsync();   // will call task returning VOID


            //Async_Await3.GetFirstToRespondAsync();        // will call task returning NON-VOID
        }
    }
}
