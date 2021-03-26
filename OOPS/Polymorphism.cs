using System;
  
namespace OOPS.Polymorphism
{

    //Overloading | Static Polymorphism | Compile time Polymorphism | Early Binding
    public class StaticPolymorphism
    {
        //the return type is not considered in case of overloading

        public int Add(int a, int b)
        {
            return a + b;
        }

        //       NOT ALLOWED
        //public int Add(int b, int a)
        //{
        //    return a + b;
        //}

        public long Add(int a, long b)
        {
            return a + b;
        }

        public long Add(long a, int b)
        {
            return a + b;
        }

        public double Add(int a, double b)
        {
            return a + b;
        }

        public float Add(int a, float b)
        {
            return a + b;
        }

        public int Add(int a, int b, int c = 10)
        {
            return a + b;
        }



        //        NOT ALLOWED
        //public int Add(int a, int b, int x)
        //{
        //    return a + b + x;
        //}
    }

    //OverRiding | Dynamic Polymorphism | Run time Polymorphism | Late Binding
    

    public class Drawing
    {
        public virtual double Area()
        {
            return 0;
        }
    }

    public class Square : Drawing
    {
        public double Length { get; set; }

        public Square()
        {
            Length = 6;
        }
        public override double Area()
        {
            return Math.Pow(Length, 2);
        }
    }


    public class Client
    {
        public static void Execute()
        {
            Console.WriteLine("----------------------Static Polymorphism---------------------");
            
            StaticPolymorphism sp = new StaticPolymorphism();
            sp.Add(5, 5);
            sp.Add(1, 2L);
            sp.Add(1L, 2);
            sp.Add(8, 4.5);
            sp.Add(7, 2.3F);  

            Console.WriteLine("----------------------Dynamic Polymorphism---------------------");

            Drawing d = new Square();
            d.Area();

        }
    }

}
