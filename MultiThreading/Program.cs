using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace MultiThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            //Example1 e1 = new Example1();
            //e1.MainThread();

            //Example2 e2 = new Example2();
            //e2.MainThread();

            //Example3 e3 = new Example3();
            //e3.MainThread();

            //Example4 e4 = new Example4();
            //e4.MainThread();

            //Example5 e5 = new Example5();
            //e5.MainThread();

            //Example6 e6 = new Example6();
            //e6.MainThread();

            //Example7 e7 = new Example7();
            //e7.MainThread();

            //Example8 e8 = new Example8();
            //e8.MainThread();

            //Example9 e9 = new Example9();
            //e9.MainThread(args);

            //Example10 e10 = new Example10();
            //e10.MainThread();

            //Example11 e11 = new Example11();
            //e11.MainThread();

            //Example12 e12 = new Example12();
            //e12.MainThread();

            //Example13 e13 = new Example13();
            //e13.MainThread();

            //Example14 e14 = new Example14();
            //e14.MainThread();

            Example15 e15 = new Example15();
            e15.MainThread();
        }

        public void Execute(int i)
        {
            // Get the constructor and create an instance of MagicClass

            Type magicType = Type.GetType("Example" + i);
            ConstructorInfo magicConstructor = magicType.GetConstructor(Type.EmptyTypes);
            object magicClassObject = magicConstructor.Invoke(new object[] { });

            // Get the ItsMagic method and invoke with a parameter value of 100

            MethodInfo magicMethod = magicType.GetMethod("MainThread");
            object magicValue = magicMethod.Invoke(magicClassObject, new object[] { 100 });
        }

    }
}
