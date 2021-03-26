using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.InterfaceConflict
{
    interface ITest1
    {
        void Area();
        void Show();
    }
    interface ITest2
    {
        void Circumference();
        void Show();
    }

    public class TestInterface : ITest1, ITest2
    {
        public void Area()
        {
            throw new NotImplementedException();
        }

        public void Circumference()
        {
            throw new NotImplementedException();
        }

        void ITest1.Show()
        {
            Console.WriteLine("ITest1");
        }

        void ITest2.Show()
        {
            Console.WriteLine("ITest2");
        }
    }

    public class Client
    {
        public static void Execute()
        {
            ITest1 t1 = new TestInterface();
            t1.Show();
            t1.Area();


            ITest2 t2 = new TestInterface();
            t2.Show();
            t2.Circumference();

            TestInterface ti = new TestInterface();
            ((ITest1)ti).Show(); //from interface 1
            ((ITest2)ti).Show(); //from interface 2

        }
    }
}
