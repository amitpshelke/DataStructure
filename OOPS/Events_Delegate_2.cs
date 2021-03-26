using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.Events_Delegate_2
{
    /*
      Difference between Delegates and Events   [https://techdifferences.com/difference-between-delegates-and-events-in-c-sharp.html]
        
         ********  Delegates  ********                    ******** Events  ********
        A delegate is declared outside any class.  ||  An event is declared inside a class.     
        Delegates are independent of events.       ||  The event can not be created without delegates.



        Why do you need Event in a language like C# when one can achieve the same thing with Delegate? 

        1. Event is very helpful to create Notification systems. The same is not possible with Delegate because Delegate cannot be exposed as public.
        2. Delegate is very helpful to create call back functions, i.e pass delegate as function argument, which is not possible with Event.
    */



    /*
        When to Use Delegates Instead of Interfaces ?

        #Use a delegate in the following circumstances:

            - An eventing design pattern is used.

            - It is desirable to encapsulate a static method.

            - The caller has no need to access other properties, methods, or interfaces on the object implementing the method.

            - Easy composition is desired.

            - A class may need more than one implementation of the method.

        #Use an interface in the following circumstances:

            - There is a group of related methods that may be called.

            - A class only needs one implementation of the method.

            - The class using the interface will want to cast that interface to other interface or class types.

            - The method being implemented is linked to the type or identity of the class: for example, comparison methods. ex : IComparable
    */


    public delegate void Print(string s);
    public class DelegateTest
    {
        
        public DelegateTest()
        {
            Print p = new Print(ColorPrint);
            p += new Print(BWPrint);
            p.Invoke("Sample Text");
        }

        public void ColorPrint(string text)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Color Print : " + text);
        }

        public void BWPrint(string text)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Black&White Print : " + text);
        }
    }




    public class EventTest
    {
        public delegate void Print(string s);
        public event Print PrintEvent;

        public EventTest()
        {
            this.PrintEvent += ColorPrint;
            this.PrintEvent += BWPrint;

            //Above line can be written as also
            //this.PrintEvent += new Print(ColorPrint);
            //this.PrintEvent += new Print(BWPrint);
        }

        public void ColorPrint(string text)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Color Print : " + text);
        }

        public void BWPrint(string text)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Black&White Print : " + text);
        }


        //This method checks that the Event is holding an 'Event handler function' or not, 
        //if there are any Event handler(s) it calls all Event handler functions.
        public virtual void OnPrintEvent()
        {
            if (PrintEvent != null)
                PrintEvent("Called from OnPrintEvent");
        }
    }




    public class Client
    {
        public static void Execute()
        {
            DelegateTest dt = new DelegateTest();  // even if the delegate is public, we cannot use it outside the class.
            //dt.Print  -- > this line gives error as Print is not available

            Print p = new Print(dt.ColorPrint);
            p += new Print(dt.BWPrint);
            p.Invoke("Sample Data");


            //So the Event type resolves the problem of exposing Delegates outside of a class by defining wrappers around Delegate.
            EventTest et = new EventTest();
            //et.PrintEvent -- > this line will not give error as PrintEvent is available outside the class
            et.OnPrintEvent();


        }

       

        private static void Et_PrintEvent(string s)
        {
            Console.WriteLine("Hello");
        }
    }
}
