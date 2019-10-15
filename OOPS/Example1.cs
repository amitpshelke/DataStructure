using System;


namespace OOPS.OverrideExamples
{
    class BaseClass
    {
        public BaseClass()
        {
            Console.WriteLine("Constructor ## Base");
        }

        public void Func1()
        {
            Console.WriteLine("Base: Func1");
        }

        public virtual void Func2()
        {
            Console.WriteLine("Base: Func2");
        }

        public virtual void Func3()
        {
            Console.WriteLine("Base: Func3");
        }
    }
    class DerivedClass : BaseClass
    {
        //ctor
        public DerivedClass()
        {
            Console.WriteLine("Constructor ## Derived");
        }

        public new void Func1()
        {
            Console.WriteLine("Derived: Func1");
        }
      
        public override void Func2()
        {
            Console.WriteLine("Derived: Func2");
        }
        public new void Func3()
        {
            Console.WriteLine("Derived: Func3");
        }
    }

    public class Client
    {
        public static void Execute()
        {
            BaseClass bx = new BaseClass();
            bx.Func1();
            bx.Func2();
            bx.Func3();

            Console.WriteLine("--------------------------------------------------------------------------");

            DerivedClass d = new DerivedClass();
            d.Func1();
            d.Func2();
            d.Func3();

            Console.WriteLine("--------------------------------------------------------------------------");


            //When we call base class object from instance of derived class
            //function with NEW will call base class function 
            //function with OVERRIDE will call derived class function

            BaseClass b = new DerivedClass();
            b.Func1();
            b.Func2();
            b.Func3();
        }
    }

}
