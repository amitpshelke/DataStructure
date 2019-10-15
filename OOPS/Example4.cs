using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.Polymorphism
{

    //Compile-Time Polymorphism or Early Binding or Static Polymorphism
    //
    // This can be achieved through Method Overloading

    public class StaticPolymorphism
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Add(int a, int b, int c)
        {
            return a + b + c;
        }
    }




    //Run-Time Polymorphism or Late Binding or Dynamic Polymorphism
    //
    // This can be achieved through Method Overriding

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
            sp.Add(1, 2, 3);

            Console.WriteLine("----------------------Dynamic Polymorphism---------------------");

            Drawing d = new Square();
            d.Area();

        }
    }

}
