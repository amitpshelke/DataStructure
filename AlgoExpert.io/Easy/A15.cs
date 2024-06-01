using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoExpert.io.Easy
{
    /*
       CAESAR CIPHER ENCRYPTOR 
  
        Given a non-empty string of lowercase letters and a non-negative integer representing a key, write a function that returns a new string obtained by
        shifting every letter in the input string by k positions in the alphabet, where k is the key.

        Note that letters should "wrap" around the alphabet; in other words, the letter z shifted by one returns the letter a.

        INPUT

        string = 'xyz'
        key = 2

        OUTPUT

        zab

    */
    class A15
    {
        public static string CaesarCipherEncryptor(string str, int key)
        {
            char[] newLetters = new char[str.Length];

            int newKey = key % 26;
            for (int i = 0; i < str.Length; i++)
            {
                newLetters[i] = getNewLetter(str[i], newKey);
            }
            return new string(newLetters);
        }

        private static char getNewLetter(char letter, int key)
        {
            int newLetterCode = letter + key;
            return newLetterCode <= 122 ? (char)newLetterCode : (char)(96 + newLetterCode % 122);
        }
    }
}
