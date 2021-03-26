using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.BeforeFieldInit
{
    /* 
      The static constructor for a class executes at most once in a given application domain. 
      The execution of a static constructor is triggered by the first of the following events to occur within an application domain:
          •An instance of the class is created.
          •Any of the static members of the class are referenced.
    */

    //The C# specification implies that no types with static constructors should be marked with the "beforefieldinit" flag. 

    /*
     Basically, beforefieldinit means "the type can be initialized at any point before any static fields are referenced." 
     In theory that means it can be very lazily initialized - if you call a static method which doesn't touch any fields, 
     the JIT doesn't need to initialize the type.
    */


    public class Test1
    {
        static object o = new object();
    }

    public class Test2
    {
        static object o;

        static Test2()
        {
            o = new object();
        }
    }


    /*
     The two classes are not, in fact, the same. They both have type initializers - and the two type initializers are the same.
     This means that the first class can be marked as beforefieldinit and have its type initializer invoked at any time before 
     the first reference to a static field in it.
    */


    public class Test3
    {
        static object o = new object();

        static Test3()
        {
        }
    }

    /*
    The beforefieldinit flag has a strange effect, in that it can not only mean that a type initializer is invoked 
    earlier than that of an equivalent type without the flag - it could even be invoked later, or not at all.  
    */

    public class Test4
    {
        public static string x = EchoAndReturn("In type initializer");

        public static string EchoAndReturn(string s)
        {
            Console.WriteLine(s);
            return s;
        }
    }

    public class Client
    {
        public static void Execute()
        {
            Console.WriteLine("Starting Main");


            // Invoke a static method on Test
            Test4.EchoAndReturn("Echo!");
            Console.WriteLine("After echo");


            // Reference a static field in Test
            string y = Test4.x;


            // Use the value just to avoid compiler cleverness
            if (y != null)
            {
                Console.WriteLine("After field access");
            }
        }
    }



    /*
      Note : the type’s initializer method is executed at, or sometime before, first access to any static field defined for that type

    So basically it means that the static variable in class is executed before the static constructor. This is due to the "beforefieldinit" 
    additional attribute.
      
        .class private auto ansi beforefieldinit ConsoleApplication1.MessageHolder1
                        extends [mscorlib]System.Object
        {
        } 

        .class private auto ansi ConsoleApplication1.MessageHolder2
                        extends [mscorlib]System.Object
        {
        } 

    */
}