using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Behavioural.PublisherSubScriber2
{
    //***  Implementation with EventAggregator

    /*
    An Event/Delegate is easy to implement and good for small projects or in a project where there are fewer Publishers and Subscribers. 
    An EventAggregator is suitable for large projects or projects with a large number of Publishers and Subscirbers.
    But I think it's always good to use EventAggregator because it offers loose coupling.
    */


    /*
        EventAggregator: by the name one can easily say it aggregates events. An Publisher/Subscriber EventAggregator woks as a HUB whose task is 
        to aggregate all the published messages and send the message to the interested subscribers.

        1. Publisher publishes a message.
        2. EventAggregator receives a message sent by publishers.
        3. EventAggregator gets a list of all subscriber interested messages.
        4. EventAgregator sends the messages to the interested subscriber.
    */

    //Does used by EventAggregator to reserve subscription  
    public class Subscription<Tmessage> : IDisposable
    {
        public Action<Tmessage> Action { get; private set; }

        private readonly EventAggregator EventAggregator;
        private bool isDisposed;


        public Subscription(Action<Tmessage> action, EventAggregator eventAggregator)
        {
            Action = action;
            EventAggregator = eventAggregator;
        }



        ~Subscription()
        {
            if (!isDisposed)
                Dispose();
        }

        public void Dispose()
        {
            EventAggregator.UnSubscribe(this);
            isDisposed = true;
        }
    }

    public class EventAggregator
    {
        private Dictionary<Type, IList> subscriber;

        public EventAggregator()
        {
            subscriber = new Dictionary<Type, IList>();
        }

        //This a method to publish messages.As in the code, 
        //this method receives messages as input then filters out a list of all subscribers by message type and publishes messages to the subscriber.
        public void Publish<TMessageType>(TMessageType message)
        {
            Type t = typeof(TMessageType);
            IList actionlst;


            if (subscriber.ContainsKey(t))
            {
                actionlst = new List<Subscription<TMessageType>>(subscriber[t].Cast<Subscription<TMessageType>>());
                foreach (Subscription<TMessageType> a in actionlst)
                {
                    a.Action(message);
                }
            }
        }

        //This a method for subsribing to interested message types. As in the code this method recevies an Action delegate as input. 
        //It maps an Action to a specific MessageType, in other words it creates an entry for message type if not present in the dictionary and 
        //maps a Subscription object (that waps an Action) to a message entry.
        public Subscription<TMessageType> Subscribe<TMessageType>(Action<TMessageType> action)
        {
            Type t = typeof(TMessageType);
            IList actionlst;
            var actiondetail = new Subscription<TMessageType>(action, this);

            if (!subscriber.TryGetValue(t, out actionlst))
            {
                actionlst = new List<Subscription<TMessageType>>();
                actionlst.Add(actiondetail);
                subscriber.Add(t, actionlst);
            }
            else
            {
                actionlst.Add(actiondetail);
            }

            return actiondetail;
        }

        //This a method for unsubscribing from a specific message type. It receives a Subscription object as input and removes an object from the dictionary.
        public void UnSubscribe<TMessageType>(Subscription<TMessageType> subscription)
        {
            Type t = typeof(TMessageType);
            if (subscriber.ContainsKey(t))
            {
                subscriber[t].Remove(subscription);
            }
        }
    }

    //Code of Publisher class that shows how a publisher publishes a message using EventAggregator.
    public class Publisher
    {
        EventAggregator EventAggregator;
        public Publisher(EventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
        }

        public void PublishMessage()
        {
            EventAggregator.Publish(new MyMessage());
            EventAggregator.Publish(10);
        }
    }

    //Code of the Subscriber class that shows a subscriber subscribing to messages that it is interested in using EventAggregator.
    public class Subscriber
    {
        Subscription<MyMessage> myMessageToken;
        Subscription<int> intToken;
        EventAggregator eventAggregator;

        public Subscriber(EventAggregator eve)
        {
            eventAggregator = eve;
            eve.Subscribe<MyMessage>(this.Test);
            eve.Subscribe<int>(this.IntTest);
        }

        private void IntTest(int obj)
        {
            Console.WriteLine(obj);
            eventAggregator.UnSubscribe(intToken);
        }

        private void Test(MyMessage test)
        {
            Console.WriteLine(test.ToString());
            eventAggregator.UnSubscribe(myMessageToken);
        }
    }


    public class MyMessage
    {
    }

    public class Client
    {
        public static void Execute()
        {
            EventAggregator eve = new EventAggregator();
            Publisher pub = new Publisher(eve);
            Subscriber sub = new Subscriber(eve);

            pub.PublishMessage();

            Console.ReadLine();

        }
    }
}
