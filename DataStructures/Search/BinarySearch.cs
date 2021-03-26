using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    /*
        The idea of binary search is to use the information that the array is SORTED and reduce the time complexity to O(Log n). 

        We basically ignore half of the elements just after one comparison.
            - Compare x with the middle element.
            - If x matches with middle element, we return the mid index.
            - Else If x is greater than the mid element, then x can only lie in right half subarray after the mid element. So we recur for right half.
            - Else (x is smaller) recur for the left half.

        Time Complexity :O(Log n)
    */

    public class BinarySearch
    {
        public static int Search(int[] arr, int x)
        {
            int lowerBound = 0, upperBound = arr.Length - 1;

            while (lowerBound <= upperBound)
            {
                int mid = lowerBound + (upperBound - lowerBound) / 2;

                // Check if x is present at mid 
                if (arr[mid] == x)
                    return mid;   //returns the INDEX of the found element

                // If x greater, ignore left half 
                if (arr[mid] < x)
                    lowerBound = mid + 1;

                // If x is smaller, ignore right half 
                else
                    upperBound = mid - 1;
            }

            // if we reach here, then element was not present 
            return -1;
        }
    }
}
