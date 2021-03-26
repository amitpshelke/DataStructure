using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.Test3
{
    public class Factorial
    {
        public int Get(int value)
        {
            int Fact = 1;

            for (int i = value; i >= 1; i--)
            {
                Fact *= i;
            }

            return Fact;
        }
    }

    public class Client
    {
        public static void Execute()
        {
            Factorial f = new Factorial();
            int result = f.Get(6);
        }
    }
}
