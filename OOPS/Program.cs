using DataProcessorService;
using System;
using System.Collections.Generic;
using System.IO;

namespace OOPS
{
    internal class Program
    {



        private static void Main(string[] args)
        {

            Console.WriteLine(Console.Read());
            Console.ReadKey();
            Console.WriteLine(Console.ReadLine());



            //int possibleCombinationCnt = 0;
            //long num = 15;
            //long sum = 0;


            //for (int j = 1; j < num; j++)
            //{
            //    for (int i = j; i < num; i++)
            //    {
            //        sum += i;
            //        if (sum == num)
            //        {
            //            possibleCombinationCnt++;
            //            sum = 0;
            //            break;
            //        }
            //        else if (sum > num)
            //        {
            //            sum = 0;
            //            break;
            //        }
            //    }
            //}


            //List<int> LstACValues = new List<int> { 1, 7, 2, 5, 10, 16, 17, 18, 20, 21, 22};

            //var result = (from m in LstACValues
            //              where m % 2 == 0
            //              select m).Take(5).ToList();

            //NestedAsync_AwaitExample.NestedAsync_Await.Client.Execute();
            //Async_AwaitExample.Client.Execute();

            //Indexers.Client.Execute();
            //Async_AwaitExample.Client.Execute();
            //IQuerableVsIEnumerable.Client.Execute();
            //RegularExpression.Client.Execute();

            //DelegateSample.Client.Execute();

            //Enumerables.Client.Execute();

            //GenericsSample.Client.Execute();

            //CollectionSample.Client.Execute();

            //TimingSample.Client.Execute();
            //Concurrency_Parallelism.Client.Execute();
            //ConcurrentCollection.Client.Execute();
            //BlockingCollectionEx.Client.Execute();

            //OverrideExamples.Client.Execute();
            //OverrideConstructor.Client.Execute(); 
            //StaticConstructor.Client.Execute();
            //Polymorphism.Client.Execute();
            //InterfaceConflict.Client.Execute();
            //Async_AwaitExample.Client.Execute();
            //Concurrency_Parallelism.Client.Execute();

            //Covariance_ContraVariance.Client.Execute();
            //Multicast_Delegate.Client.Execute();

            //LambdaExp_Delegate_AnomyousFunc.Client.Execute();
            //Inheritance.Client.Execute();
            //Static_Class.Client.Execute();
            //Ref_Out.Client.Execute();
            //Events_Delegate_2.Client.Execute();

            //AbstractClass_Interface.Client.Execute();

            //Inheritance2.Client.Execute();

            //StringBuilder_String.Client.Execute();
            //Nested_Classes.Client.Execute();

            OOPS.Stack_Queue.Client.Execute();

            //Test6.Client.Execute();

            Console.ReadKey();
        }

        private static void OnStart()
        {
            DebugLog.Write(LogType.Debug, "FileReader", "OnStart", "Service Started");
            IEnumerable<string> dirs = Directory.EnumerateDirectories(@"D:\Photos");

            foreach (var dir in dirs)
            {
                IEnumerable<string> files = Directory.EnumerateFiles(dir);
                foreach (var file in files)
                {
                    DebugLog.Write(LogType.Debug, "FileReader", "OnStart", file);
                }
            }

        }
    }


    public class NTPA
    {
        public int AccountId { get; set; }

        public string AccountName { get; set; }

        public int ParentAccountId { get; set; }

        public bool IsParent { get; set; }
    }
}

