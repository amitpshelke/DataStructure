using System;

/*
 There are situations in a project where we want only one instance of the object to be created and shared between the clients. 
 No client can create an instance of the object from outside. 
 There is only one instance of the class which is shared across the clients.

  Below are the steps to make a singleton pattern :- 
  1. Define the constructor as private.
  2. Define the instances and methods as static.

*/

namespace DesignPattern.Creational.SingleTon
{
    public class UIButtonSingleTon
    {
        private static int Counter = 0;

        private UIButtonSingleTon()
        { //this is a private Constructor
        }

        public static void Hit()
        {
            Counter++;
        }

        public static int TotalHits()
        {
            return Counter;
        }

    }


    public class Client
    {
        public static void Execute()
        {
            Console.WriteLine("I got hit :" + UIButtonSingleTon.TotalHits());

            UIButtonSingleTon.Hit();
            Console.WriteLine("I got hit :" + UIButtonSingleTon.TotalHits());

            UIButtonSingleTon.Hit();
            UIButtonSingleTon.Hit();
            Console.WriteLine("I got hit :" + UIButtonSingleTon.TotalHits());

        }
    }

}
