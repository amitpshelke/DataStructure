using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoExpert.io.Easy
{
    /*
    
        VALIDATE SUBSEQUENCE

        Given two non-empty arrays of integers, write a function that determines whether the second array is a subsequence of the first one.
        
        A subsequence of an array is a set of numbers that aren't necessarily adjacent in the array but that are in the same order as they appear in the array. 
        For instance, the numbers [1, 3, 4] form a subsequence of the array [1, 2, 3, 4] and so do the numbers [2, 4].

        Note that a single number in an array and the array itself are both valid subsequences of the array.


        INPUT

        array = [5, 1, 22, 25, 6, -1, 8, 10]
        sequence = [1, 6, -1, 10]

        OUTPUT

        true

  

    */
    class A2
    {
        public static bool IsValidSubSequence(List<int> array, List<int> sequence)
        {
            int arrIdx = 0;
            int seqIdx = 0;

            while (arrIdx < array.Count && seqIdx < sequence.Count)
            {
                if (array[arrIdx] < sequence[seqIdx])
                {
                    seqIdx++;
                }
                arrIdx++;
            }

            return seqIdx == sequence.Count;
        }
    }
}
