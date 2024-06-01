using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.Overloading
{
    /*
       even if the return types are different the same parameter method is not allowed  
    */

    public class English
    {
        public int Call(int a, int b)
        {
            return 0;
        }

        /****  Below method is not allowed with just change in return type
                    public int Call(int b, int a)
                    {
                        return 0;
                    }


                    public float Call(int a, int b)
                    {
                        return 0;
                    }
        */


        public int Call(ref int a, int b)
        {
            return 0;
        }

        public int Call(ref int a, out int b)
        {
            b = 0;  // out value must be assigned with some value before return
            return 0;
        }

        //Below method is not allowed if same method is already define with 'ref' parameter [same method with just difference in out and ref is not allowed]
        //public int Call(out int a, int b)
        //{
        //    a = 5;
        //    return 0;
        //}

        public int Call(int a, out int b)
        {
            b = 5;
            return 0;
        }
    }
}
