using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoExpert.io.Easy
{
    /*
        FIRST NON REPEATING CHARACTER
       
        Write a function that takes in a string of lowercase English-alphabet letters and returns the index of the string's first non-repeating character.
        The first non-repeating character is the first character in a string that occurs only once.
        If the input string doesn't have any non-repeating characters, your function should return -1.
        
        INPUT

        string = "abcdcaf"

        OUTPUT

        1 // The first non-repeating character is "b" and is found at index 1.

    */

    class A18
    {
        public int FirstNonRepeatingCharacter(string str)
        {
            for (int idx = 0; idx < str.Length; idx++)
            {
                bool foundDuplicate = false;
                for (int idx2 = 0; idx2 < str.Length; idx2++)
                {
                    if (str[idx] == str[idx2] && idx != idx2)
                        foundDuplicate = true;
                }

                if (!foundDuplicate)
                    return idx;
            }

            return -1;
        }
    }
}
