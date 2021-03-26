using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    /*
     A simple approach is to do linear search, i.e
        - Start from the leftmost element of arr[] and one by one compare x with each element of arr[]
        - If x matches with an element, return the index.
        - If x doesn’t match with any of elements, return -1.


        The time complexity of above algorithm is O(n).
    */

    public class LinearSearch
    {
        public static int Search(int[] arr, int x)
        {
            int n = arr.Length;

            for (int i = 0; i < n; i++)
            {
                if (arr[i] == x)
                    return i;  //returns the INDEX of the found element
            }
            return -1; // return -1 if match not found
        }
    }
}
