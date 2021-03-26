using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.GenericsComplete
{
    public class Product
    {
        public string ProductName { get; set; }
        public int Price { get; set; }
    }
    public class Book : Product
    {
        public string ISBN { get; set; }
    }


    // Below is the simple implementation of a list, where Add, Remove could be simple method of the list
    public class List
    {
        public void Add(int number)
        {
        }

        public int this[int index]
        {
            get { return this[index]; }
        }
    }

    //if you want to store Book in list the above class wont work
    public class BookList
    {
        public void Add(Book book)
        {
        }

        public Book this[int index]
        {
            get { return this[index]; }
        }
    }

    //Ok but above will only support collection of Type Book. It will not support other types
    //So even if we draw class for multiple type, and if there is modification/bug then it will at multiple places.


    //we can create a little generic list of object, as every class is derived from System.Object
    public class ObjectList
    {
        public void Add(Object value)
        {
        }

        public Object this[int index]
        {
            get { return this[index]; }
        }
    }

    //but the issue is performance
    // 1. if we use value types to store the in the objectlist then boxing and unboxing is require, which will hamper performance
    // 2. if we use reference types still casting to a particular type will be overhead again.

    // so to solve this we have Generics


    public class GenericList<T>
    {
        public void Add(T value)
        {
        }

        public T this[int index]
        {
            get { return this[index]; }
        }
    }


    // so the consumer of the class will decide the which type of list to be created
    // var numbers = new GenericList<int>();
    // var books = new GenericList<Book>();

    //Everthing will be decided at runtime.

    //All the generic list are under namespace System.Collection.Generic

    //Now if I want to create generic version of Dictonary

    public class GenericDictonary<TKey, TValue>
    {
        public void Add(TKey key, TValue value)
        {
        }
    }

    //Now to use it     
    //var dict =  new GenericDictonary<int, Book>();
    //dict.Add(123, new Book());

    //Now using generic paramter for creating list is good, let say we want to use class that compare two numbers and retuns big one

    public class Utilities
    {
        public int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        //this function will work, but if we want to create a generic version of this


        //this will not work, because compiler thinks a and b are object.
        //public T Max<T>(T a, T b)
        //{
        //    return a > b ? a : b;  
        //}

        public T Max<T>(T a, T b) where T : IComparable   // this is generic method inside a non generic class, which is perfectly fine
        {
            return a.CompareTo(b) > 0 ? a : b;  
        }
    }

    //Now the same effect with generic class
    public class Utlities1<T> where T: IComparable
    {
        public T Max(T a, T b)
        {
            return a.CompareTo(b) > 0 ? a : b;
        }
    }


    //Now using T as Class

  

    public class DicountCalculator<T> where T : Product  //the T constraint is Reference Type 
    {
        public int Calc(T val)
        {
            return val.Price;  // see properties of Product is shown in val
        }
    }



    public class Nullable<T> where T : struct  // the T constraint can be also value type
    {
        private object _value;

        public Nullable()
        {
            //Default constructor
        }

        public Nullable(T value)   //parameterized ctor
        {
            _value = value;
        }

        public bool HasValue
        {
            get { return _value != null; }
        }

        public T GetValueorDefault()
        {
            if (HasValue)
                return (T)_value;

            return default(T);
        }
    }


    //Now to use this class

    //var number = new Nullable<int>(5);
    //Console.WriteLine("Has Value ? " + : number.HasValue);
    //Console.WriteLine("Value: " + number.GetValueorDefault());

    //var number = new Nullable<int>();
    //Console.WriteLine("Has Value ? " + : number.HasValue);
    //Console.WriteLine("Value: " + number.GetValueorDefault());


    public class Utlities2<T> where T : IComparable, new()
    {
        public void DoSomeThing()
        {
            var obj = new T(); //to achieve we need to add new() to constraint list.
        }
    }

}
