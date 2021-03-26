using System;


namespace DataStructures
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string xx = "03-jan-2005";

            DateTime dt = Convert.ToDateTime(xx);


            //*********************************************************************************************//
            int[] unsortedArray = { 8, 24, 0, 38, 2, 3, 14, 10, 40 };
            int[] sortedArray = { 2, 6, 7, 15, 18, 36, 57, 65 };

            LinearSearch.Search(unsortedArray, 10);
            BinarySearch.Search(sortedArray, 36);
            ExponentialSearch.Search(sortedArray,sortedArray.Length, 57);



            //*********************************************************************************************//

            //BubbleSort.Sort(new int[] { 25, 15, 18, 0, 2 });
            //SelectionSort.Sort(new int[] { 25, 15, 18, 0, 2 });
            //InsertionSort.Sort(new int[] { 25, 15, 18, 0, 17 });

            //*********************************************************************************************//

            //LinkedListImplementation.SingleLinkedList.Client.Execute();
            //LinkedListImplementation.DoubleLinkedList.Client.Execute();


            //*********************************************************************************************//

            Console.ReadKey();
        }
    }
}
