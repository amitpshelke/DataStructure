using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.Generics
{
    /*
     Delegates are 'Type Safe' function pointers

     Encapsulate method's call from caller

     Effective use can improve performance

     Use to call method Asynchronosly
    */


    public class DelegateSample2
    {
        public delegate void CallBack(int i);     

        public void LongRunning(CallBack obj)
        {
            for (int i = 0; i < 10000; i++)
            {
                //Do something
                obj(i);
            }
        }
    }

    public class Client
    {
        public static void Execute()
        {
            DelegateSample2 dgs2 = new DelegateSample2();
            dgs2.LongRunning(CallBackHere);
        }

        static void CallBackHere(int i)
        {
            Console.WriteLine(i);
        }
    }
}
