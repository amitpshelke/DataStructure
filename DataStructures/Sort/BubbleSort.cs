using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class BubbleSort
    {
        public static string Sort(int[] arr)
        {
            int n = arr.Length;

            int iloop = (n - 1);
            for (int i = 0; i < iloop; i++)
            {
                int jloop = (n - i - 1);
                for (int j = 0; j < jloop; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        // swap temp and arr[i] 
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }


            //print output
            string output = string.Empty;

            for (int i = 0; i < n; ++i)
                output += (arr[i] + " ");

            return output;
        }
    }
}
