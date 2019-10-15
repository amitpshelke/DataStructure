using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.InterfaceConflict
{
    interface ITest1
    {
        void Show();
    }
    interface ITest2
    {
        void Show();
    }

    public class TestInterface : ITest1, ITest2
    {
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

            ITest2 t2 = new TestInterface();
            t2.Show();
        }
    }
}
