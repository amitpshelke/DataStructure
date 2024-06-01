using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.Covariance_ContraVariance
{
    public class Animal
    {
    }

    public class Dog : Animal
    {
    }

    public class Cat : Animal
    {
    }



    public delegate Animal Behaviour(Dog dog);

    public class Covariance_Delegate
    {
        public static Dog Eat(Dog d)
        {
            Console.WriteLine("Dog can eat");
            return new Dog();
        }

        public static Cat Eat(Cat c)
        {
            Console.WriteLine("Cat can eat");
            return new Cat();
        }
    }


    public delegate Animal Sound(Dog dog);

    public class Contravariance_Delegate
    {
        //Input::Base | Ouput::Base
        public static Animal MakeSound(Animal a)
        {
            Console.WriteLine("Animal can MakeSound");
            return new Animal();
        }

        //Input::Derived | Ouput::Base
        public static Animal SuperBark(Dog d)
        {
            Console.WriteLine("Dog can SuperBark");
            return new Animal();
        }

        //Input::Derived | Ouput::Derived
        public static Dog Bark(Dog d)
        {
            Console.WriteLine("Dog can bark");
            return new Dog();
        }
    }



    public class Client
    {
        public static void Execute()
        {
            Animal a= new Dog();
            a = new Cat();

            //Above two are perfectly valid statement. 
            //i.e. An object of base class can point to derived class; this is Dynamic Polymorphism
            //so list of object of base class can point to list of derived class

            //Group of Animal can point to group of derived class. 
            //******* But this was not possible in framework 3.5 or below
            IEnumerable<Animal> IAnimal = new List<Animal>();

            /*
            This is due to out parameter in IEnumerable interface.
            System.Collections.Generic.IEnumerable<out T> 
            The type of object to enumerate. This type parameter is Covariant. That is, you can use either the type you specified or any type that is more derived  
            */





            //Covariance_Delegate

            //return type of delegate is base class but we can still assign derived class method 

            Behaviour behaviour = Covariance_Delegate.Eat;
            Animal animal = behaviour(new Dog());

            Func<Dog,Dog> action = Covariance_Delegate.Eat;

            //Contravariance_Delegate [Also example of Multicast Delegate]

            Sound sound = Contravariance_Delegate.Bark;
            sound += Contravariance_Delegate.SuperBark;
            sound += Contravariance_Delegate.MakeSound;


            /*
             If you look up the definitions, this is what you will find:
                - Covariance enables you to use a more derived type than originally specified.
                - Contravariance enables you to use a less derived type than originally specified.
            */

        }
    }
}
