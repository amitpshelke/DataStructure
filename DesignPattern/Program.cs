using System;

namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creational
            //Creational.Factory.Client.Execute();

            //Creational.AbstractFactory.Client.Execute();
            //Creational.SingleTon.Client.Execute();


            //this is not design pattern, but a concept associted with singleton and static constructor

            //Creational.Singleton_V2.SingletonV1 v1 = Creational.Singleton_V2.SingletonV1.Instance;
            Creational.Singleton_V2.SingletonV2 v2 = Creational.Singleton_V2.SingletonV2.Instance;
            //Creational.Singleton_V2.SingletonV3 v3 = Creational.Singleton_V2.SingletonV3.Instance;
            //Creational.Singleton_V2.SingletonV4 v4 = Creational.Singleton_V2.SingletonV4.Instance;
            //Creational.Singleton_V2.SingletonV5 v5 = Creational.Singleton_V2.SingletonV5.Instance;
            //Creational.BeforeFieldInit.Client.Execute(); 
            //Creational.Singleton_Inheritance.Client.Execute();

            //Behavioural
            //Behavioural.Observer.Client.Execute();
            //new Behavioural.PublisherSubscriber.Client().Execute();
            //Behavioural.PublisherSubScriber2.Client.Execute();
            //Behavioural.Strategy.Client.Execute();
            //Structural
            //Structural.Bridge.Client.Execute();
            //Structural.Decorator.Client.Execute();


            Console.ReadKey();
        }
    }
}
