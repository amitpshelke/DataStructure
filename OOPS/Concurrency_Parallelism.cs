using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.Concurrency_Parallelism
{
    /*
     
     Concurrency =>

       Concurrency is essentially applicable when we talk about minimum two tasks or more. 
       When an application is capable of executing two tasks virtually at same time, we call it concurrent application. 
       Though here tasks run looks like simultaneously, but essentially they MAY not. 
       They take advantage of CPU time-slicing feature of operating system where each task run part of its task and then go to waiting state. 
       When first task is in waiting state, CPU is assigned to second task to complete it’s part of task.

       Operating system based on priority of tasks, thus, assigns CPU and other computing resources e.g. memory; turn by turn to all tasks 
       and give them chance to complete. To end user, it seems that all tasks are running in parallel. This is called concurrency.

     Parallelism =>

       Parallelism does not require two tasks to exist. 
       It literally physically run parts of tasks OR multiple tasks, at the same time using multi-core infrastructure of CPU, 
       by assigning one core to each task or sub-task.

       Parallelism requires hardware with multiple processing units, essentially. 
       In single core CPU, you may get concurrency but NOT parallelism.

     
    Asynchronous methods ==>

       This is not related to Concurrency and parallelism, asynchrony is used to present the impression of concurrent or parallel tasking 
       but effectively an asynchronous method call is normally used for a process that needs to do work away from the current application 
       and we don't want to wait and block our application awaiting the response.    
         
     */


    public class Concurrency
    {
        public void ReadInput()
        {
            Console.Write("Concurrency : Enter Name: ");
            string str = Console.ReadLine();
            Console.WriteLine("Concurrency : " + str);
        }

        public async void Task1()
        {
            Console.WriteLine("Concurrency: Downloading File 1 ....");
            await Task.Delay(30000);
            Console.WriteLine("Concurrency: Downloaded==>File 1");
        }

        public async void Task2()
        {
            Console.WriteLine("Concurrency: Downloading File 2 ....");
            await Task.Delay(30000);
            Console.WriteLine("Concurrency: Downloaded==>File 2");
        }
    }


    public class Parallelism
    {
        public void ReadInput()
        {
            Task.Factory.StartNew(Task1);
            Task.Factory.StartNew(Task2);

            Console.Write("Parallelism : Enter Name: ");
            string str = Console.ReadLine();
            Console.WriteLine("Parallelism : " + str);
        }

        private void Task1()
        {
            Console.WriteLine("Parallelism: Downloading File 1 ....");
            Task.Delay(50000);
            Console.WriteLine("Parallelism: Downloaded==>File 1");
        }

        private void Task2()
        {
            Console.WriteLine("Parallelism: Downloading File 2 ....");
            Task.Delay(50000);
            Console.WriteLine("Parallelism: Downloaded==>File 2");
        }
    }


    public class Client
    {
        public static void Execute()
        {
            Concurrency c = new Concurrency();
            c.Task1();
            c.Task2();
            c.ReadInput();
            Console.WriteLine("************************************************************************************");

            Parallelism p = new Parallelism();
            p.ReadInput();
            Console.WriteLine("************************************************************************************");


            Console.ReadLine();
        }
    }
}
