using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.Concurrency_Parallelism
{
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
            //Concurrency c = new Concurrency();
            //c.Task1();
            //c.Task2();
            //c.ReadInput();

            Console.WriteLine("************************************************************************************");

            Parallelism p = new Parallelism();
            p.ReadInput();

            Console.WriteLine("************************************************************************************");

            Console.ReadLine();
        }
    }
}
