using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{

    /*
    Exponential search involves two steps:
        - Find range where element is present
        - Do Binary Search in above found range

    The idea is to start with subarray size 1, compare its last element with x, then try size 2, then 4 and so on until last element of a subarray is not greater.
    Once we find an index i (after repeated doubling of i), we know that the element must be present between i/2 and i (Why i/2? because we could not find a 
    greater value in previous iteration)

    Applications of Exponential Search:

    Exponential Binary Search is particularly useful for unbounded searches, where size of array is infinite. Please refer Unbounded Binary Search for an example.
    It works better than Binary Search for bounded arrays, and also when the element to be searched is closer to the first element.

        Time Complexity : O(Log n)
    */


    public class ExponentialSearch
    {
        // Returns position of first occurrence of x in array 
        public static int Search(int[] arr, int n, int x)
        {

            // If x is present at first location itself 
            if (arr[0] == x)
                return 0;

            // Find range for binary search by repeated doubling 
            int i = 1;
            while (i < n && arr[i] <= x)
                i = i * 2;

            // Call binary search for the found range
            return BinarySearch(arr, i / 2,  Math.Min(i, n), x);
        }


        private static int BinarySearch(int[] arr, int lowerBound, int r, int x)
        {
            if (r >= lowerBound)
            {
                int mid = lowerBound + (r - lowerBound) / 2;

                // If the element is present at the middle itself 
                if (arr[mid] == x)
                    return mid;

                // If element is smaller than mid, then it can only be present n left subarray 
                if (arr[mid] > x)
                    return BinarySearch(arr, lowerBound, mid - 1, x);

                // Else the element can only be present in right subarray 
                return BinarySearch(arr, mid + 1, r, x);
            }

            // We reach here when element is not present in array 
            return -1;
        }

    }
}
