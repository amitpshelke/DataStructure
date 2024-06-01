using System;
using System.Collections.Generic;
using System.Threading.Tasks;


//https://medium.com/@t.masonbarneydev/iterating-asynchronously-how-to-use-async-await-with-foreach-in-c-d7e6d21f89fa
namespace OOPS.Iterate_Async
{
    public class InformationReader1
    {
        private Task ReadAsync(string item)
        {
            Task.Delay(1000);  //1 second
            Console.WriteLine("Value : " + item);
            return new Task(new Action(() => Console.WriteLine("Information Reader1")));
        }

        public async Task LoopData(IEnumerable<string> list)
        {
            foreach (var item in list)
            {
                await ReadAsync(item);
            }
        }
    }


    public class InformationReader2
    {
        private Task ReadAsync(string item)
        {
            Task.Delay(1000);  //1 second
            Console.WriteLine("Value : " + item);
            return new Task(new Action(() => Console.WriteLine("Information Reader2")));
        }

        public async Task LoopData(IEnumerable<string> list)
        {
            List<Task> listTask = new List<Task>();

            foreach (var item in list)
            {
                listTask.Add(ReadAsync(item));
            }

            await Task.WhenAll(listTask); //This method is used when you have a bunch of tasks that you want to await all at once.
        }
    }



    //The difference in this example is the return types and the Task type. 
    //Rather than using Task which is the asynchronous version of void we are returning Task<T> which is the Tasks generic implementation. 
    //Task<T> allows you to specify the type that will be returned once the Task has completed, in our example, this is a string.S
    public class InformationReader3<T>
    {
        private Task<T> ReadAsync(T item)
        {
            Task.Delay(1000);  //1 second
            Console.WriteLine("Value : " + item);
            return Task.FromResult(item);
        }

        public async Task<IEnumerable<T>> LoopData(IEnumerable<T> list)
        {
            List<Task<T>> listTask = new List<Task<T>>();

            foreach (var item in list)
            {
                listTask.Add(ReadAsync(item));
            }

            //This method is used when you have a bunch of tasks that you want to await all at once.
            //the same thing but return a collection of values when our Task finishes.
            return await Task.WhenAll<T>(listTask);
        }
    }


    public class Client
    {
        public static async void Execute()
        {
            List<string> lst = new List<string>();
            lst.Add("Task 1");
            lst.Add("Task 2");
            lst.Add("Task 3");
            lst.Add("Task 4");
            lst.Add("Task 5");


            //It will be slow as we are sitting inside the synchronous loop waiting for each task to complete one by one. 
            InformationReader1 ir1 = new InformationReader1();
            await ir1.LoopData(lst);


            // the first thing we need to do is create a collection of tasks, 
            // once we have this we can start looping over our thingsToLoop
            InformationReader2 ir2 = new InformationReader2();
            await ir2.LoopData(lst);


            InformationReader3<string> ir3 = new InformationReader3<string>();
            await ir2.LoopData(lst);

        }
    }
}