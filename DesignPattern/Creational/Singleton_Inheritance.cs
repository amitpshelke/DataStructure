using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Creational.Singleton_Inheritance
{
    /*
        Singleton Objects stored on heap while static class stored in High frequency heap.
        Singleton Objects can dispose but not static class. 

        The big difference between a singleton & static is that singletons can implement interfaces
    */



    public class Animal
    {
        public virtual void Eat()
        {
            Console.WriteLine("Calling the base : Eat");
        }

        public virtual void Sleep()
        {
            Console.WriteLine("Calling the base : Sleep");
        }
    }

    public class Dog : Animal
    {
        private static Dog _instance = null;

        //ctor
        private Dog()
        {
            //Since this constructor is private we cannot create instance of Dog Class i.e. Dog d = new Dog();     ---- this will throw compile error 
        }

        public static Dog Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Dog();
                }

                return _instance;
            }
        }

        public override void Eat()
        {
            base.Eat();    //this line will call base method
            Console.WriteLine("Calling the Derived : Eat");
        }

        public new void Sleep()
        {
            base.Sleep();    //this line will call base method
            Console.WriteLine("Calling the Derived : Eat");
        }
    }


    public class Client
    {
        public static void Execute()
        {
            Dog.Instance.Eat();
            Dog.Instance.Sleep();
        }
    }
}
