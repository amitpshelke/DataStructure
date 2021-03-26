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
            ExecuteAny(25);
            Console.ReadKey();
        }


        //Using Reflection to create any class object and call method of that class
        public static void ExecuteAny(int i)
        {
            // Get the constructor and create an instance of MagicClass
            try
            {
                Assembly assembly = Assembly.LoadFile(@"D:\Study\DataStructure\Data\MultiThreading\bin\Debug\MultiThreading.exe");
                Type magicType = assembly.GetType("MultiThreading.Example" + i);
                ConstructorInfo magicConstructor = magicType.GetConstructor(Type.EmptyTypes);
                object magicClassObject = magicConstructor.Invoke(new object[] { });

                // Get the ItsMagic method and invoke without parameter
                MethodInfo magicMethod = magicType.GetMethod("MainThread");
                object magicValue = magicMethod.Invoke(magicClassObject, null);
            }
            catch (Exception ex)
            { string error = ex.Message; }
        }

    }
}
