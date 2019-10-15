using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.OverrideConstructor
{
    class BaseClass
    {
        int i;
        public BaseClass(int x)
        {
            i = x;
            Console.WriteLine("Tech :: " + x);
        }
    }

    class DerivedClass : BaseClass
    {
        public DerivedClass(int b) : base(b)
        {
            Console.WriteLine("Beamers :: " + b);
        }
    }

    class ChildClass : DerivedClass
    {
        public ChildClass(int a) : base(a)
        {
            Console.WriteLine("Solution :: " + a);
        }
    }



    public class Client
    {
        public static void Execute()
        {
            BaseClass b = new BaseClass(1);
            Console.WriteLine("--------------------------------------------------------------------------");

            DerivedClass d = new DerivedClass(2);
            Console.WriteLine("--------------------------------------------------------------------------");

            ChildClass c = new ChildClass(3);
            Console.WriteLine("--------------------------------------------------------------------------");


            //Whenever the object of child class is created, it will always call all the constructor of base classes from hierarchy which it is derived

            BaseClass bd = new DerivedClass(4);
            Console.WriteLine("--------------------------------------------------------------------------");

            BaseClass bc = new ChildClass(5);
            Console.WriteLine("--------------------------------------------------------------------------");

            DerivedClass dc = new ChildClass(6);
            Console.WriteLine("--------------------------------------------------------------------------");

        }
    }
}
