using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoExpert.io.Medium
{
    /*
        MONOTONC ARRAY
        
          Write a function that takes in an array of integers and returns a boolean representing whether the array is monotonic.
          An array is said to be monotonic if its elements, from left to right, are entirely non-increasing or entirely non-decreasing.
          Non-increasing elements aren't necessarily exclusively decreasing; they simply don't increase. Similarly, non-decreasing elements aren't necessarily
          exclusively increasing; they simply don't decrease.

          Note that empty arrays and arrays of one element are monotonic.


          INPUT
          array = [-1, -5, -10, -1100, -1100, -1101, -1102, -9001]

          OUTPUT
          true
    */
    class B4
    {
        public static bool IsMonotonic(int[] array)
        {
            if (array.Length <= 2)
                return true;

            var direction = array[1] - array[0];

            for (int i = 2; i < array.Length; i++)
            {
                if (direction == 0)
                {
                    direction = array[i] - array[i - 1];
                    continue;
                }

                if (breakDirection(direction, array[i - 1], array[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool breakDirection(int direction, int previous, int current)
        {
            var diff = current - previous;

            if (direction > 0)
                return diff < 0;

            return diff > 0;
        }
    }
}
