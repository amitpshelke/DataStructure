using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Behavioural.PublisherSubscriber
{
    // ****  Implementation with Event


    /*
     
    - The Publisher/Subscriber pattern is one of the variations of the Observer designer pattern.
    - In the Publisher/Subscriber pattern a publisher (entiry responsible for publishing a message) publishes a message 
      and there are one or more Subscribers (entity subsribing, in other words intested in a message of a specified message type) who capture the published message.



     Where To Apply Publish Subscribe Pattern?
     - When you want loose coupling between objects that interact with each other.

     - When you want to specify the kind of notification you want to send, by defining a number of events, to a subscriber depending on the type or scope of change. 
       The subscriber will thus be able to choose to subscribe a specific notifications that matters.
    
    */

    //This class that represents a message that is published by a Publisher and is captured by an interested Subscriber.
    public class MessageArgs<T> : EventArgs
    {
        public T Message { get; set; }

        public MessageArgs(T message)
        {
            Message = message;
        }
    }

    public interface IPublisher<T>
    {
        event EventHandler<MessageArgs<T>> DataPublisher;
        void OnDataPublisher(MessageArgs<T> args);
        void PublishData(T data);
    }

    //The Publisher class provides the event DataPublisher that a subscriber attaches to listen for messages.
    //PublishData is a publisher class method that publishes data to Subscribers.

    /*
        Technically Publisher is a generic class that inherits the IPublisher interface. 
        Since Publisher is a generic class an instance of it can be of any type represented by a T template type. 
        A Publisher instance is created of a selected type and publishes that type of message only. 
        To publish a different type of message a different type of Publisher instance must be created. 
    */

    public class Publisher<T> : IPublisher<T>
    {
        public event EventHandler<MessageArgs<T>> DataPublisher;

        public void OnDataPublisher(MessageArgs<T> args)
        {
            var handler = DataPublisher;

            if (handler != null)
                handler(this, args);
        }

        public void PublishData(T data)
        {
            MessageArgs<T> message = (MessageArgs<T>)Activator.CreateInstance(typeof(MessageArgs<T>), new object[] { data });

            OnDataPublisher(message);
        }
    }


    //Subscriber captures messages of the type it is interested in.

    //Technically a Subscriber is a generic class that allows creation of multiple instances of a subscriber and each subscriber subscribes 
    //to the messages it is interested in using a publisher.

    //A Subscriber passes an instance of a specific type of publisher to capture messages published by that Publisher.

    public class Subscriber<T>
    {
        public IPublisher<T> Publisher
        {
            get;
            private set;
        }

        public Subscriber(IPublisher<T> publisher)
        {
            Publisher = publisher;
        }
    }



    public class Client
    {
        private readonly IPublisher<int> IPublisher1;
        private readonly IPublisher<string> IPublisher2;

        private readonly Subscriber<int> Subscriber1;
        private readonly Subscriber<string> Subscriber2;

        public Client()
        {
            IPublisher1 = new Publisher<int>();
            Subscriber1 = new Subscriber<int>(IPublisher1);
            Subscriber1.Publisher.DataPublisher += Publisher_DataPublisher1;

            IPublisher2 = new Publisher<string>();
            Subscriber2 = new Subscriber<string>(IPublisher2);
            Subscriber2.Publisher.DataPublisher += Publisher_DataPublisher;
        }

       

        private void Publisher_DataPublisher1(object sender, MessageArgs<int> e)
        {
            Console.WriteLine("Subscriber 1 : " + e.Message);
        }
        private void Publisher_DataPublisher(object sender, MessageArgs<string> e)
        {
            throw new NotImplementedException();
        }

        public void Execute()
        {
            IPublisher1.PublishData(10);
            IPublisher2.PublishData("Twenty");
        }
    }
}
