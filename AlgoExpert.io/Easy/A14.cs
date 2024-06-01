using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoExpert.io.Easy
{
    /*
    PAINDROME CHECK
    
        Write a function that takes in a non-empty string and that returns a boolean representing whether the string is a palindrome.
        A palindrome is defined as a string that's written the same forward and backward. Note that single-character strings are palindromes.

        INPUT
        string = abcdcba

        OUTPUT
        true

    */
    class A14
    {
        public static bool IsPalindrome(string str)
        {
            string reverseString = "";

            for (int i = str.Length; i >= 0 ; i --)
            {
                reverseString += str[i];
            }

            return str.Equals(reverseString);
        }
    }
}
