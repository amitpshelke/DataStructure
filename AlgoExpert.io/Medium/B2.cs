using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoExpert.io.Medium
{
    /*
        SMALLEST DIFFERENCE
        
          Write a function that takes in two non-empty arrays of integers, finds the pair of numbers (one from each array) whose absolute difference is closest to
          zero, and returns an array containing these two numbers, with the number from the first array in the first position.

          Note that the absolute difference of two integers is the distance between them on the real number line. For example, the absolute difference of -5 and 5
          is 10, and the absolute difference of -5 and -4 is 1.

          You can assume that there will only be one pair of numbers with the smallest difference.

          INPUT

          arrayOne = [-1, 5, 10, 20, 28, 3]
          arrayTwo = [26, 134, 135, 15, 17]

          OUTPUT

          [28 , 26]
    */

    class B2
    {
        public static int[] SmallestDifference(int[] arrayOne, int[] arrayTwo)
        {
            Array.Sort(arrayOne);
            Array.Sort(arrayTwo);

            int idxOne = 0;
            int idxTwo = 0;

            int smallest = Int32.MaxValue;
            int current = Int32.MaxValue;

            int[] smallestPair = new int[2]; 

            while (idxOne < arrayOne.Length && idxTwo < arrayTwo.Length)
            {
                int firstNum = arrayOne[idxOne];
                int secondNum = arrayTwo[idxTwo];

                if (firstNum < secondNum)
                {
                    current = secondNum - firstNum;
                    idxOne++;
                }
                else if (secondNum < firstNum)
                {
                    current = firstNum - secondNum;
                    idxTwo++;
                }
                else
                    return new int[] { firstNum, secondNum };


                if (smallest > current)
                {
                    smallest = current;
                    smallestPair = new int[] { firstNum, secondNum };
                }
            }

            return smallestPair;
        }
    }
}
