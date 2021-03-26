using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoExpert.io.Easy
{
    /*
      TWO NUMBER SUM 
     
      Write a function that takes in a non-empty array of distinct integers and an
      integer representing a target sum. If any two numbers in the input array sum
      up to the target sum, the function should return them in an array, in any
      order. If no two numbers sum up to the target sum, the function should return
      an empty array.

      
      Note that the target sum has to be obtained by summing two different integers
      in the array; you can't add a single integer to itself in order to obtain the
      target sum.

      
      You can assume that there will be at most one pair of numbers summing up to
      the target sum.

      INPUT

      array = [3, 5, -4, 8, 11, 1, -1, 6]
      targetSum = 10


      OUTPUT

      [-1, 11] the numbers could be in reverse order

    */


    public class A1
    {
        public static int[] TwoNumberSum(int[] array, int targetSum)
        {
            for (int i = 0; i < array.Length -1 ; i++)
            {
                int firstNum = array[i];
                for (int j = 0; j < array.Length; j++)
                {
                    int secondNum = array[j];
                    if (firstNum + secondNum == targetSum)
                        return new int[] { firstNum, secondNum };
                }
            }

            return new int[0];
        }
    }
}
