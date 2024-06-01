using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Behavioural.Mediator
{
    /*
      Mediator Design Pattern allows multiple objects to communicate with each other without knowing each other’s structure. 
     This pattern defines an object which encapsulates how the objects will interact with each other’s and support easy maintainability of the code by loose coupling.

        # When to use it?

        - Communication between multiple objects is well defined but potentially complex.

        - When too many relationships exist and a common point of control or communication is required.

        - Some object can be grouped and customized based on behaviors.
    */

    public interface IBroker
    {
        void SendMessage(Customer caller, string msg);
    }

    public abstract class Customer
    {
        protected IBroker _broker;

        public Customer(IBroker broker)
        {
            _broker = broker;
        }
    }


    public class Buyer : Customer
    {
        public Buyer(IBroker broker) : base(broker)
        {
        }

        public void Send(string msg)
        {
            Console.WriteLine("Buyer sends message:" + msg);
            _broker.SendMessage(this, msg);
        }

        public void Receive(string msg)
        {
            Console.WriteLine("Buyer receives message:" + msg);
        }
    }


    public class Seller : Customer
    {
        public Seller(IBroker broker) : base(broker)
        {
        }

        public void Send(string msg)
        {
            Console.WriteLine("Seller sends message:" + msg);
            _broker.SendMessage(this, msg);
        }

        public void Receive(string msg)
        {
            Console.WriteLine("Seller receives message:" + msg);
        }
    }


    public class Broker : IBroker
    {
        public Buyer buyer { get; set; }

        public Seller seller { get; set; }

        public void SendMessage(Customer customerType, string msg)
        {
            if (customerType == buyer)
                seller.Receive(msg);
            else
                buyer.Receive(msg);
        }
    }



    public class Client
    {
        public static void Execute()
        {
            Broker br = new Broker();

            Seller se = new Seller(br);
            Buyer bu = new Buyer(br);

            br.seller = se;
            br.buyer = bu;
            

            se.Send("Do you want to buy something?");
            bu.Send("Yes, your house.");

        }
    }

}
