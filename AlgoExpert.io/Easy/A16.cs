using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoExpert.io.Easy
{
    /*
        RUN-LENGTH ENCODING 

        Write a function that takes in a non-empty string and returns its run-length encoding. From Wikipedia, "run-length encoding is a form of lossless data compression in
        which runs of data are stored as a single data value and count, rather than as the original run." For this problem, a run of data is any sequence of
        consecutive, identical characters. So the run "AAA" would be run-length-encoded as "3A".

          To make things more complicated, however, the input string can contain all sorts of special characters, including numbers. And since encoded data must be
          decodable, this means that we can't naively run-length-encode long runs. For example, the run "AAAAAAAAAAAA" (12 As), can't
          naively be encoded as "12A", since this string can be decoded as either "AAAAAAAAAAAA" or "1AA". Thus, long runs (runs of 10 or more characters) should be encoded in a split fashion; the
          aforementioned run should be encoded as "9A3A".

        INPUT

        string = "AAAAAAAAAAAAABBCCCCDD"

        OUTPUT

        "9A4A2B4C2D"
    */

    class A16
    {
        public string RunLengthEncoding(string str)
        {
            StringBuilder encodedStringChars = new StringBuilder();
            int currentRunLength = 1;

            for (int i = 1; i < str.Length; i++)
            {
                char currentChar = str[i];
                char previousChar = str[i - 1];

                if ((currentChar != previousChar) || (currentChar == 9))
                {
                    encodedStringChars.Append(currentRunLength.ToString());
                    encodedStringChars.Append(previousChar);
                    currentRunLength = 0;
                }

                currentRunLength += 1;
            }
            //handle the last run
            encodedStringChars.Append(currentRunLength.ToString());
            encodedStringChars.Append(str[str.Length - 1]);

            return encodedStringChars.ToString();
        }
    }
}
