using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoExpert.io.Easy
{
    /*
        GENERATE DOCUMENT
        
          You're given a string of available characters and a string representing a document that you need to generate. Write a function that determines if you
          can generate the document using the available characters. If you can generate the document, your function should return true; otherwise, it
          should return false.

          You're only able to generate the document if the frequency of unique characters in the characters string is greater than or equal to the frequency
          of unique characters in the document string. For example, if you're given characters = "abcabc" and document = "aabbccc" you cannot generate the document 
          because you're missing one c.

          The document that you need to create may contain any characters, including special characters, capital letters, numbers, and spaces.

          Note: you can always generate the empty string ("").

          INPUT

          characters = "Bste!hetsi ogEAxpelrt x "
          document = "AlgoExpert is the Best!"
    */
    class A17
    {
        public bool GenerateDocument(string characters, string document)
        {
            for (int idx = 0; idx < document.Length; idx++)
            {
                char character = document[idx];
                int documentFrequency = countcharFrequency(character, document);
                int charactersFrequency = countcharFrequency(character, characters);

                if (documentFrequency > charactersFrequency)
                    return false;
            }

            return true;
        }

        public int countcharFrequency(char character, string target)
        {
            int frequency = 0;
            for (int idx = 0; idx < target.Length; idx++)
            {
                char c = target[idx];
                if (c == character)
                    frequency += 1;
            }
            return frequency;
        }
    }
}
