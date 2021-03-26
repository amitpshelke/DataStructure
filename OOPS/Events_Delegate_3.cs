using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.Events_Delegate_3
{
    //You might have wondered, if an event is a type of delegate, why do we need an event if a delegate can fulfil the purpose?



    public class PhotoPrinter
    {
        public delegate void SelectPrinter(string PrinterName);
        public event SelectPrinter PrinterSelectedEvent;

        public PhotoPrinter()
        {
        }

        public void PrintColor()
        {
            if (PrinterSelectedEvent != null)
                PrinterSelectedEvent.Invoke("HP Inkjet 410 ");

            Console.WriteLine("Color Print");
        }

        public void PrintBW()
        {
            if (PrinterSelectedEvent != null)
                PrinterSelectedEvent.Invoke("Brother Laserjet 1100 ");

            Console.WriteLine("Black & White Print");
        }

        public void PrintSepia()
        {
            if (PrinterSelectedEvent != null)
                PrinterSelectedEvent.Invoke("Canon Deskjet 1575 ");

            Console.WriteLine("Sepia Print");
        }
    }



    /*
      Now you can assign handler methods to the delegate using the "+=" operator as we do with a multicast delegate. But some subscriber classes can, by mistake, 
      assign methods to the delegate using the "=" operator and make it a single delegate handler; now all the other methods assigned to the delegate will get overridden.

        photoPrinter.PrinterSelectedEvent = PhotoPrinter_PrinterSelectedEvent;

        We can overcome this problem by using events. The AddEventHandler() and RemoveEventHandler() methods are used to assign or remove methods to the delegate. 
        The "+=" operator overloads for the AddEventHandler method and the "-=" operator overloads for the RemoveEventHandler method. 
        The event doesn't allow the "=" operator to assign methods to the event delegate.


        Event internal implementation:



        readonly object eventLock = new object();

        event BeforePrint BeforePrintEvent
        {
            add
            {
                lock (eventLock)
                {
                    BeforePrintEvent += value;
                }
            }
            remove
            {
                lock (eventLock)
                {
                    BeforePrintEvent -= value;
                }
            }
        }

        In short, the event internally maintains the delegate methods chain subscribed by consumers by using AddEventHandler and RemoveEventHandler,
        sand also by overloading the += and -+ operators.
         
    */


    public class Client
    {
        public static void Execute()
        {
            PhotoPrinter photoPrinter = new PhotoPrinter();
            photoPrinter.PrinterSelectedEvent += PhotoPrinter_PrinterSelectedEvent;
        }

        private static void PhotoPrinter_PrinterSelectedEvent(string PrinterName)
        {
            Console.WriteLine("PhotoPrinter_PrinterSelectedEvent : " + PrinterName);
        }
    }
}
