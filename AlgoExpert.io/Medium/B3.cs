﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoExpert.io.Medium
{
    /*
        MOVE ELEMENT TO END
        
          You're given an array of integers and an integer. Write a function that moves all instances of that integer in the array to the end of the array and returns
          the array.

          The function should perform this in place (i.e., it should mutate the input array) and doesn't need to maintain the order of the other integers.

          INPUT

          array = [2, 1, 2, 2, 2, 3, 4, 2]
          toMove = 2

          OUTPUT

          [1, 3, 4, 2, 2, 2, 2, 2] // the numbers 1, 3, and 4 could be ordered differently
    */

    class B3
    {
        public static List<int> MoveElementToEnd(List<int> array, int toMove)
        {
            int i = 0;
            int j = array.Count - 1;

            while (i < j)
            {
                while (i < j && array[j] == toMove)
                    j--;

                if (array[i] == toMove)
                    Swap(i, j, array);

                i++;
            }

            return array;
        }

        private static void Swap(int i, int j, List<int> array)
        {
            int temp = array[i];
            array[j] = array[i];
            array[i] = temp;
        }
    }
}
