using System;

//DEPENDENCY INVERSION PRINCIPLE

namespace SOLID.DIP
{

    /*****************************************************************************************************************
    This principle tells you not to write any tightly coupled code because that is a nightmare to maintain when the application is growing bigger and bigger. 
    If a class depends on another class, then we need to change one class if something changes in that dependent class. 
    We should always try to write loosely coupled class.
    *******************************************************************************************************************/

    public class Email
    {
        public void SendEmail()
        {
        }
    }

    public class Notification
    {
        private Email _email;
        public Notification()
        {
            _email = new Email();
        }

        public void PromotionalNotification()
        {
            _email.SendEmail();
        }
    }

    /*****************************************************************************************************************
    Now Notification class totally depends on Email class, because it only sends one type of notification. 
    If we want to introduce any other like SMS then? We need to change the notification system also. 
    And this is called tightly coupled. 
    What can we do to make it loosely coupled? 
    Ok, check the following implementation.
    *******************************************************************************************************************/

    public interface IMessenger
    {
        void SendMessage();
        
    }
    public class Email_Extn : IMessenger
    {
        public void SendMessage()
        {
            // code to send email
        }
    }

    public class SMS_Extn : IMessenger
    {
        public void SendMessage()
        {
            // code to send SMS
        }
    }


    public class Notification_Extn
    {
        private IMessenger _iMessengerEmail;
        //private IMessenger _iMessengerSMS;

        public Notification_Extn()
        {
            _iMessengerEmail = new Email_Extn();
            //_iMessengerSMS = new SMS_Extn();
        }
        public void DoNotify()
        {
            _iMessengerEmail.SendMessage();
            //_iMessengerSMS.SendMessage();
        }
    }


    /*****************************************************************************************************************
    Still Notification class depends on Email class. Now, we can use dependency injection so that we can make it loosely coupled.
    There are 3 types to DI, Constructor injection, Property injection and method injection.
    *******************************************************************************************************************/

    public class Notification_Extn2
    {
        private IMessenger _iMessenger;
        public Notification_Extn2(IMessenger pMessenger)
        {
            _iMessenger = pMessenger;
        }
        public void DoNotify()
        {
            _iMessenger.SendMessage();
        }
    }


    public class ExecuteCase
    {
        public void Execute()
        {
            Notification_Extn n = new Notification_Extn();  
            n.DoNotify(); // it will only call Email


            //Base on constructor type DoNotify will excute the relevant class method
            Notification_Extn2 n2 = new Notification_Extn2(new Email_Extn()); 
            n2.DoNotify();

            Notification_Extn2 n3 = new Notification_Extn2(new SMS_Extn());
            n2.DoNotify();
        }
    }
}