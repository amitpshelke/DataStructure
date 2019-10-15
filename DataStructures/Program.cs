using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            //*********************************************************************************************//

            DelegateSample.Client.Execute();

            Enumerables.Client.Execute();

            GenericsSample.Client.Execute();

            CollectionSample.Client.Execute();

            TimingSample.Client.Execute();

            //*********************************************************************************************//

            BubbleSort.Sort(new int[] { 25, 15, 18, 0, 2 });
            SelectionSort.Sort(new int[] { 25, 15, 18, 0, 2 });
            InsertionSort.Sort(new int[] { 25, 15, 18, 0, 17 });

            //*********************************************************************************************//

            Interface.ExecuteCase.Execute();
            AbstractClass_Interface.Client.Execute();

            //*********************************************************************************************//
        }
    }
}
