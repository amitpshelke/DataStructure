using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.Test4
{
    public class StringOperation
    {
        public string Reverse(string input)
        {
            char[] arr = input.ToArray();
            char[] temp = new char[arr.Length];

            int k = 0;
            for (int i = arr.Length-1; i >= 0; i--)
            {
                temp[k] = arr[i];
                    k++;
            }

            return new string(temp);
        }
    }

    public class Client
    {
        public static void Execute()
        {
            StringOperation so = new StringOperation();
            string result = so.Reverse("amit");
        }
    }
}
