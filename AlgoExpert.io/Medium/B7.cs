﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoExpert.io.Medium
{
    /*
        ARRAY OF PRODUCTS
        
          Write a function that takes in a non-empty array of integers and returns an array of the same length, where each element in the output array is equal to
          the product of every other number in the input array.

          In other words, the value at output[i] is equal to the product of every number in the input array other than input[i].

          Note that you're expected to solve this problem without using division.

          INPUT
          array = [5, 1, 4, 2]

          OUTPUT
            [8, 40, 10, 20]
            // 8 is equal to 1 x 4 x 2
            // 40 is equal to 5 x 4 x 2
            // 10 is equal to 5 x 1 x 2
            // 20 is equal to 5 x 1 x 4


    */
    class B7
    {
        public int[] ArrayOfProducts(int[] array)
        {
            int[] products = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                int runningProduct = 1;
                for (int j = 0; j < array.Length; j++)
                {
                    if (i != j)
                        runningProduct *= array[j];

                    products[i] = runningProduct;
                }
            }

            return products;
        }
    }
}
