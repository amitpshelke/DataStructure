using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.Events_Delegates_4
{
    //I know Events are always associated with Delegates. But, I am missing some core use of Events, and trying to understand that.

    public delegate void BookingDelegate();
    public class Agent
    {
        public event BookingDelegate bookingEvent;  /// here

        public void ExecuteEvent()
        {
            if (bookingEvent != null)
                bookingEvent();
        }
    }

    public class TicketCounter
    {
        public static void Counter_EventHandler1()
        {
            Console.WriteLine("Event handler 1 called..");
        }

        public static void Counter_EventHandler2()
        {
            Console.WriteLine("Event handler 2 called..");
        }
        public static void Counter_EventHandler3()
        {
            Console.WriteLine("Event handler 3 called..");
        }
    }

    /* 
     replace the event declaration with delegates i.e. replaced the line 
     
        public event BookingDelegate bookingEvent 
     
        with 
     
        public BookingDelegate bookingEvent; 
     
     on the above program, and I still get the same result. 

     Now, I was confused why we need to use Events, if it can be achieved by Delegates only. 

     What is the real use of Events?
     The modified program without events is as below -
   */

    public delegate void BookingDelegate_Extn();

    public class Agent_Extn
    {
        public BookingDelegate bookingEvent;   // here I removed event keyword
        public void ExecuteEvent()
        {
            if (bookingEvent != null)
                bookingEvent();
        }
    }

    public class TicketCounter_Extn
    {
        public static void Counter_EventHandler1()
        {
            Console.WriteLine("Event handler 1 called..");
        }

        public static void Counter_EventHandler2()
        {
            Console.WriteLine("Event handler 2 called..");
        }
        public static void Counter_EventHandler3()
        {
            Console.WriteLine("Event handler 3 called..");
        }
    }



    public class Client
    {
        public static void Execute()
        {
            Agent agent = new Agent();
            agent.bookingEvent += TicketCounter.Counter_EventHandler1;
            agent.bookingEvent += TicketCounter.Counter_EventHandler2;
            agent.bookingEvent += TicketCounter.Counter_EventHandler3;
            agent.ExecuteEvent();


            Agent_Extn agentExtn = new Agent_Extn();
            agentExtn.bookingEvent += TicketCounter_Extn.Counter_EventHandler1;
            agentExtn.bookingEvent += TicketCounter_Extn.Counter_EventHandler2;
            agentExtn.bookingEvent += TicketCounter_Extn.Counter_EventHandler3;
            agentExtn.ExecuteEvent();
            Console.ReadKey();


        }
    }

    //In short, exposing public delegate breaks encapsulation


    /*  we can use delegates because behind the scenes an event is a construct that wraps a delegate.

        But the rationale of using events instead of delegates is the the same as for using properties instead of fields - data encapsulation. 
        It's bad practice to expose fields (whatever they are - primitive fields or delegates) directly.

        Another "by the way" with the second snippet: for delegates you should use Delegate.Combine instead of "+=".
     */

}
