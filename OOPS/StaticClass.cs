using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.Static_Class
{
    /*
        static class can only have static Constructor, static Property, static Member, static Method  

        static class cannot inherit interface

        all the information belonging to static class like members, methods are stored on HIGH FREQUENCY HEAP

        You Cannot Inherit Static Class

        public static Parent
        {
        }

        public class Child : Parent  -----> this line will give error
        { 
        }
    */

    public static class StaticClass
    {
        public static string StaticMember; // = "I am a static Member";

        static StaticClass()
        {
            Console.WriteLine("I am a static Constructor");
        }

        public static string StaticProperty
        {
            get
            {
                Console.WriteLine("I am a static Property");
                return "Nothing";
            }
            set { StaticProperty = value; }
        }

        public static void StaticMethod()
        {
            Console.WriteLine("I am a static Method");
        }
    }

   

    public class Client
    {
        public static void Execute()
        {
            string a = StaticClass.StaticMember;
            string b = StaticClass.StaticProperty;
            StaticClass.StaticMethod();


            //Below line will create an exception on runtime "stack overflow exception : as static are stored on STACK" and set is not allowed in static

            //StaticClass.StaticProperty = "Static Property value can be changed";   
        }
    }
}
