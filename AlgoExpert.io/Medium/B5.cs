using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoExpert.io.Medium
{
    /*
        SPIRAL TRAVERSE
        
          Write a function that takes in an n x m two-dimensional array (that can be square-shaped when n == m) and returns a one-dimensional array of all the array's elements in spiral order.

          Spiral order starts at the top left corner of the two-dimensional array, goes to the right, and proceeds in a spiral pattern all the way until every element has been visited.

          INPUT

          array = [[1,   2,  3, 4],
                   [12, 13, 14, 5],
                   [11, 16, 15, 6],
                   [10,  9,  8, 7],]

          OUTPUT

         [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16]
    */


    class B5
    {
        public static List<int> SpiralTraverse(int[,] array)
        {
            if (array.GetLength(0) == 0)
                return new List<int>();

            var result = new List<int>();
            var startRow = 0;
            var endRow = array.GetLength(0) - 1;

            var startCol = 0;
            var endCol = array.GetLength(1) - 1;

            while (startRow <= endRow && startCol <= endCol)
            {
                for (int col = startCol; col < endCol; col++)
                {
                    result.Add(array[startRow, col]);
                }

                for (int row = startRow; row < endRow; row++)
                {
                    result.Add(array[row, endCol]);
                }

                for (int col = (endCol -1); col >= startCol; col--)
                {
                    if (startRow == endRow)
                        break;
                    result.Add(array[endRow, col]);
                }

                for (int row = (endRow -1); row < startRow; row--)
                {
                    if (startCol == endCol)
                        break;
                    result.Add(array[row, startCol]);
                }

                startRow++;
                endRow--;
                startCol++;
                endCol--;
            }

            return result;
        }
    }
}
