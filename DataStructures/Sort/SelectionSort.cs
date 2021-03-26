using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class SelectionSort
    {
        public static string Sort(int[] arr)
        {
            int n = arr.Length;

            int iLoop = n - 1;
            // One by one move boundary of unsorted subarray 
            for (int i = 0; i < iLoop; i++)
            {
                // Find the minimum element in unsorted array 
                int min_idx = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[min_idx])
                    {
                        min_idx = j;
                    }
                }


                // Swap the found minimum element with the first element 
                int temp = arr[min_idx];
                arr[min_idx] = arr[i];
                arr[i] = temp;
            }

            string output = string.Empty;

            for (int i = 0; i < n; ++i)
                output += (arr[i] + " ");


            return output;

        }

    }
}
