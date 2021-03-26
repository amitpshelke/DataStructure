using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.StaticConstructor
{
    class TestConstructor
    {
        /*
        Static constructor is used to initialize static data members as soon as the class is referenced the first time,
        whereas an instance constructor is used to create an instance of that class with the <new> keyword. 
        A static constructor does not take access modifiers or have parameters and can't access any non-static data member of a class. 


            1. The static constructor for a class executes before any instance of the class is created.
            2. The static constructor for a class executes before any of the static members for the class are referenced.
            3. The static constructor for a class executes after the static field initializers (if any) for the class.
            4. The static constructor for a class executes at most one time during a single program instantiation
            5. A static constructor does not take access modifiers or have parameters.
            6. A static constructor is called automatically to initialize the class before the first instance is created or any static members are referenced.
            7. A static constructor cannot be called directly.
            8. The user has no control on when the static constructor is executed in the program.
            9. A typical use of static constructors is when the class is using a log file and the constructor is used to write entries to this fil


        */
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
