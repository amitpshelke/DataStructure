using System;

/*
 Inheritance is a way to specify different implementations of an abstraction. 
 But in this way, implementations are tightly bound to the abstraction and cannot be modified independently. 
 The Bridge pattern provides an alternative to inheritance when there is more than one version of abstraction. 
     
*/



namespace DesignPattern.Structural.Bridge
{
    public interface IMessageSender
    {
        void Send(string Subject, string Body, string Type);
    }

    public abstract class Message
    {
        public IMessageSender MessageSender { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public abstract void Send();  //abstract Method
    }

    //Redefine Abstraction
    public class SystemMessage : Message
    {
        public override void Send()
        {
            MessageSender.Send(Subject, Body, MessageSender.GetType().ToString());
        }
    }

    //Redefine Abstraction
    public class UserMessage : Message
    {
        public override void Send()
        {
            MessageSender.Send(Subject, Body, MessageSender.GetType().ToString());
        }
    }

    //Concrete Implementation
    public class EmailMessage : IMessageSender
    {
        public void Send(string Subject, string Body, string Type)
        {
            Console.WriteLine(Subject + " :: " + Body + " :: " + Type);
        }
    }

    //Concrete Implementation
    public class TextMessage : IMessageSender
    {
        public void Send(string Subject, string Body, string Type)
        {
            Console.WriteLine(Subject + " :: " + Body + " :: " + Type);
        }
    }

    public class Client
    {
        public static void Execute()
        {
            IMessageSender email = new EmailMessage();
            IMessageSender text = new TextMessage();

            Message message = new SystemMessage();
            message.Subject = "SystemMessage";
            message.Body = "this is test.";
            message.MessageSender = email; //<==
            message.Send();

            UserMessage userMessage = new UserMessage();
            userMessage.Subject = "UserMessage";
            userMessage.Body = "this is test.";
            userMessage.MessageSender = text; //<==
            userMessage.Send();

            Console.ReadLine();
        }
    }

}
