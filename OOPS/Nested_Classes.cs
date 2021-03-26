using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.Nested_Classes
{
    /*
        1. It is a way of logically grouping classes that are only used in one place.
        2. It increases encapsulation.
        3. Nested classes can lead to more readable and maintainable code. 
    */
    public class OuterClass
    {
        internal InnerClass InnerClassObject { get; set; }
        
        public OuterClass()
        {
            this.InnerClassObject = new InnerClass(this);
        }

        public OuterClass(InnerClass innerClass)
        {
        }//OuterClass constructor can have InnerClass as parameter

        public void OuterMethod()
        {
            Console.WriteLine("OuterMethod");

            PrivateInnerClass pic = new PrivateInnerClass();
            pic.Do();
        }


       
        public class InnerClass    
        {
            private OuterClass obj;

            public InnerClass(OuterClass outerClass) //InnerClass constructor can have OuterClass as parameter
            {
                this.obj = outerClass;
            }  
            
            public void InnerMethod()
            {
                Console.WriteLine("InnerMethod");
                obj.OuterMethod();

                //This type of use is only available within the Nested classes only, outside the OuterClass this is not allowed
                PrivateInnerClass privateInnerClass = new PrivateInnerClass();
                privateInnerClass.Name = "Amit";
                privateInnerClass.Age = 35;
            }
        }


        //A nested class may be declared as private, meaning that the class can only be seen by its parent class and other nested classes within that parent.
        //A nested class may also be declared as protected, allowing it to also be accessed by classes that derive from its parent type
        private class PrivateInnerClass
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public void Do()
            {
                Console.WriteLine("PrivateInnerClass");
            }
        }

        public sealed class InnerSealedClass
        {
            public void Do()
            {
                Console.WriteLine("PrivateInnerSealedClass");
            }
        }


        internal static class StaticInnerClass
        {
            static StaticInnerClass()
            {
                Console.WriteLine("StaticInnerClass : Constructor");
            }
            public static void Method()
            {
                Console.WriteLine("StaticInnerClass : Method");
            }


            public class InnerNonStatic
            {
                public InnerNonStatic()
                {
                    Console.WriteLine("InnerNonStatic : Constructor");
                }
            }
        }
    }


    public class Client
    {
        public static void Execute()
        {
            OuterClass oc = new OuterClass();
            oc.OuterMethod();
            oc.InnerClassObject.InnerMethod();  //to access Inner class, it should be either 'internal or public'

            OuterClass.StaticInnerClass.Method();  // to access StaticInnerClass class, it should be either 'internal or public'  

            OuterClass.StaticInnerClass.InnerNonStatic innerNonStatic = new OuterClass.StaticInnerClass.InnerNonStatic();  //Static class can have its InnerClass/Nested class as Non-Static Class

            OuterClass.InnerSealedClass innerSealedClass = new OuterClass.InnerSealedClass();  //OuterClass can have Sealed class

        }
    }
}
