using System;

namespace DesignPattern.Creational.Singleton_V2
{
    /*
     The static constructor for a class executes at most once in a given application domain. 
     The execution of a static constructor is triggered by the first of the following events to occur within an application domain:
            •An instance of the class is created.
            •Any of the static members of the class are referenced.


    Advantages of a Singleton Pattern are:

        Singleton pattern can be implemented interfaces.
        It can be also inherited from other classes.
        It can be lazy-loaded.
        It has Static Initialization.
        It can be extended into a factory pattern.
        It helps to hide dependencies.
        It provides a single point of access to a particular instance, so it is easy to maintain.


    Disadvantages of a Singleton Pattern are:

        Unit testing is more difficult (because it introduces a global state into an application).
        This pattern reduces the potential for parallelism within a program because to access the singleton in a multi-threaded system, 
        an object must be serialized (by locking)


    Singleton class vs. Static methods:

        A Static Class cannot be extended whereas a singleton class can be extended.
        A Static Class can still have instances (unwanted instances) whereas a singleton class prevents it.
        A Static Class cannot be initialized with a STATE (parameter), whereas a singleton class can be.
        A Static class is loaded automatically by the CLR when the program or namespace containing the class is loaded.

    */


    //Note : Sealed class are used to restrict the users from inheriting the class.
    //       Sealed method is implemented so that no other class can overthrow it and implement its own method.      


    //First Version - Not Thread Safe
    public sealed class SingletonV1
    {
        private static SingletonV1 _instance = null;

        //ctor
        private SingletonV1()
        {
            string x = "";
        }

        public static SingletonV1 Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SingletonV1();
                }

                return _instance;
            }
        }
    }


    //Second Version - Simple Thread Safe
    public sealed class SingletonV2
    {
        private static SingletonV2 _instance = null;
        private static readonly object padLock = new object();

        //ctor
        private SingletonV2()
        {
            string x = "";
        }

        public static SingletonV2 Instance
        {
            get
            {
                lock (padLock)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonV2();
                    }

                    return _instance;
                }
            }
        }
    }


    //Third Version - not quite as lazy, but thread-safe without using locks
    public sealed class SingletonV3
    {
        private static readonly SingletonV3 _instance = new SingletonV3();

        //ctor
        static SingletonV3()
        {
            /* 
            Static constructors in C# are specified to execute only when an instance of the 
            class is created or a static member is referenced, and to execute only once per AppDomain

            - The laziness of type initializers is only guaranteed by .NET when the type isn'tmarked with a special flag called "beforefieldinit"
            - The C# compiler marks all types which don't have a static constructor as "beforefieldinit "
            */
        }

        //ctor
        private SingletonV3()
        {
        }

        public static SingletonV3 Instance
        {
            get
            {
                return _instance;
            }
        }
    }



    //Fourth Version -  fully lazy instantiation
    public sealed class SingletonV4
    {
        //ctor
        private SingletonV4()
        {
        }

        public static SingletonV4 Instance
        {
            get
            {
                //instantiation is triggered by the first reference to the static member of the nestedclass, which only occurs in Instance
                return Nested._instance; 
            }
        }

        //Note : although nestedclasses have access to the enclosing class's private members, 
        //       the reverse is not true, hence the need for "_instance" to be internal here
        private class Nested
        {
            internal static readonly SingletonV4 _instance = new SingletonV4();

            //ctor
            static Nested()
            {
            }
        }

    }


    //Fifth Version - using .NET 4.x Lazy<T> type
    public sealed class SingletonV5
    {
        //All you need to do is pass a delegate to the constructorwhich calls the Singleton constructor - which is done most easily with a lambda expression. 
        //The code above implicitly uses LazyThreadSafetyMode.ExecutionAndPublication as the threadsafety mode for the Lazy<Singleton>.
        private static readonly Lazy<SingletonV5> lazy = new Lazy<SingletonV5>(() => new SingletonV5(), true);

        //ctor
        private SingletonV5()
        {
        }

        public static SingletonV5 Instance
        {
            get
            {
                return lazy.Value;
            }
        }
    }
}
