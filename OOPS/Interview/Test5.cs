using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.Test5
{
    //Easiest way to sort binary array

    public class Veritas
    {
        public int[] Sort(int[] a, int n)
        {
            int begin = 0;
            int end = n - 1;


            while (begin < end)
            {
                if (a[begin] == 0)
                    begin++;
                else if (a[end] == 1)
                    end--;
                else
                {
                    a[begin] = 0;
                    a[end] = 1;
                }
            }

            return a;
        }
    }
    //b:0 
    //e:

    public class Client
    {
         
        public static void Execute()
        {
            int[] arr = new int[12] { 1, 1, 1, 1, 0, 0, 0, 1, 0, 1, 1, 0 };
            Veritas vs = new Veritas();
            int[] result = vs.Sort(arr, arr.Length);
        }
    }
}
