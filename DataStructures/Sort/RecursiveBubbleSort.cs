using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class RecursiveBubbleSort
    {
        // A function to implement bubble sort 
        public static string Sort(int[] arr, int n)
        {
            // Base case 
            if (n == 1)
                return "";

            // One pass of bubble sort. After this pass, the largest element is moved (or bubbled) to end. 
            for (int i = 0; i < n - 1; i++)
                if (arr[i] > arr[i + 1])
                {
                    // swap arr[i], arr[i+1] 
                    int temp = arr[i];
                    arr[i] = arr[i + 1];
                    arr[i + 1] = temp;
                }

            // Largest element is fixed, recur for remaining array 
            Sort(arr, n - 1);

            string output = string.Empty;

            for (int i = 0; i < arr.Length; i++)
                output += (arr[i] + " ");


            return output;
        }
    }
}
