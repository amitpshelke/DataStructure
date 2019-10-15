using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.StaticConstructor
{
    class TestConstructor
    {

        //Static Constructor is always without paramater. It  will be called once the class is instantiated
        static TestConstructor()
        {
            int num = 8;
            Console.WriteLine("Static Constructor : " + num);
        }
        public TestConstructor(int a)
        {
            int val = 10;
            Console.WriteLine("Parameterized Constructor : " + val);
        }
    }


    public class Client
    {
        public static void Execute()
        {
            TestConstructor tc = new TestConstructor(50);
        }
    }

}
