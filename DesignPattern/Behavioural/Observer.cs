using System;
using System.Collections;

/*
 Observer pattern helps us to communicate between parent class and its associated or dependent classes. 
 There are two important concepts in observer pattern 'Subject' and 'Observers'. 
 The subject sends notifications while observers receive notifications if they are registered with the subject.
*/



namespace DesignPattern.Behavioural.Observer
{
    public interface INotifications
    {
        void Notify();
    }

    public class Email : INotifications
    {
        public void Notify()
        {
            Console.WriteLine("Email sent.");
        }
    }

    public class SMS : INotifications
    {
        public void Notify()
        {
            Console.WriteLine("SMS sent.");
        }
    }

    public class Message : INotifications
    {
        public void Notify()
        {
            Console.WriteLine("Message sent.");
        }
    }


    public class Notifier
    {
        private ArrayList listNotifier = new ArrayList();

        public void AddNotification(INotifications iNotifications)
        {
            listNotifier.Add(iNotifications);
            Console.WriteLine("Notifer Added of Type : " + iNotifications.GetType());
        }

        public void RemoveNotification(INotifications iNotifications)
        {
            listNotifier.Remove(iNotifications);
            Console.WriteLine("Notifer Removed of Type : " + iNotifications.GetType());
        }

        public void NotifyAll()
        {
            foreach (INotifications item in listNotifier)
            {
                item.Notify();
            }
        }
    }


    public class Client
    {
        public static void Execute()
        {
            Notifier nt = new Notifier();

            INotifications email = new Email();
            nt.AddNotification(email);

            INotifications sms = new SMS();
            nt.AddNotification(sms);

            INotifications message = new Message();
            nt.AddNotification(message);


            nt.RemoveNotification(sms);

            nt.NotifyAll();
        }
    }

}
