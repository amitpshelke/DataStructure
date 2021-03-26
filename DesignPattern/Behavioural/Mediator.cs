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

    public interface IMediator
    {
        void SendMessage(Colleague caller, string msg);
    }

    public abstract class Colleague
    {
        protected IMediator _mediator;

        public Colleague(IMediator mediator)
        {
            _mediator = mediator;
        }
    }


    public class ConcreteColleagueA : Colleague
    {
        public ConcreteColleagueA(IMediator mediator) : base(mediator)
        {
        }

        public void Send(string msg)
        {
            Console.WriteLine("A send message:" + msg);
            _mediator.SendMessage(this, msg);
        }

        public void Receive(string msg)
        {
            Console.WriteLine("A receive message:" + msg);
        }
    }


    public class ConcreteColleagueB : Colleague
    {
        public ConcreteColleagueB(IMediator mediator) : base(mediator)
        {
        }

        public void Send(string msg)
        {
            Console.WriteLine("B send message:" + msg);
            _mediator.SendMessage(this, msg);
        }

        public void Receive(string msg)
        {
            Console.WriteLine("B receive message:" + msg);
        }
    }


    public class ConcreteMediator : IMediator
    {
        public ConcreteColleagueA Colleague1 { get; set; }

        public ConcreteColleagueB Colleague2 { get; set; }

        public void SendMessage(Colleague caller, string msg)
        {
            if (caller == Colleague1)
                Colleague2.Receive(msg);
            else
                Colleague1.Receive(msg);
        }
    }


    public class Client
    {
        public static void Execute()
        {
            ConcreteMediator cm = new ConcreteMediator();


            //cm.SendMessage();
        }
    }

}
