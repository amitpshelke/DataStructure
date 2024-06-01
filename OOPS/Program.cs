using DataProcessorService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OOPS
{
    internal class Program
    {
        private static void Main(string[] args)
        {



            //AbstractClass_Version.Client.Execute();

            //NestedAsync_AwaitExample.NestedAsync_Await.Client.Execute();

            //Indexers.Client.Execute();
            Async_AwaitExample.Client.Execute();
           // Async_AwaitExample2.Client.Execute();
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

            //OOPS.Stack_Queue.Client.Execute();

            //Test6.Client.Execute();

            Console.ReadKey();
        }

        public static int findAccuracy(int n, int[] TransId, double[] accuracy)
        {
            //this is default OUTPUT. You can change it
            int result = -404;

            //WRITE YOUR LOGIC HERE:
            double minAcc = 0.5;
            int lastMinAccId = 0;
            bool firstAssign = false;
            for (int trans = 1; trans <= n; trans++)
            {
                if (accuracy[trans] >= 0.5)
                {
                    if (firstAssign == false)
                    {
                        lastMinAccId = TransId[trans];
                        firstAssign = true;
                    }
                    if (accuracy[lastMinAccId] < accuracy[trans])
                        lastMinAccId = TransId[trans];
                }
            }

            result = lastMinAccId;
            return result;
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


   
}

