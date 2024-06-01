using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoExpert.io.Easy
{
    /*
        PRODUCT SUM

          Write a function that takes in a "special" array and returns its product sum. 
          A "special" array is a non-empty array that contains either integers or other
          "special" arrays. The product sum of a "special" array is the sum of its
          elements, where "special" arrays inside it are summed themselves and then
          multiplied by their level of depth.

          The depth of a "special" array is how far nested it is. For instance, the
          depth of [] is 1; the depth of the inner array in
          [[]] is 2; the depth of the innermost array in [[[]]] is 3

          Therefore, the product sum of [x, y] is x + y; the
          product sum of [x, [y, z]] is x + 2 * (y + z); the
          product sum of [x, [y, [z]]] is x + 2 * (y + 3z).


          INPUT 
          array= [5, 2, [7, -1], 3, [6, [-13, 8], 4]]
          
          OUTPUT
          12 // calculated as: 5 + 2 + 2 * (7 - 1) + 3 + 2 * (6 + 3 * (-13 + 8) + 4)
    */

    class A13
    {
        public static int ProductSum(List<object> array)
        {
            return ProductSumHelper(array, 1);
        }

        private static int ProductSumHelper(List<object> array, int multiplier)
        {
            int sum = 0;

            foreach (object el in array)
            {
                if (el is IList<object>)
                    sum += ProductSumHelper((List<object>)el, multiplier + 1);
                else
                    sum += (int)el;
            }

            return sum * multiplier;
        }
    }
}
