using System;

/*

 */

//TO stop the inheritance we need to make the class as sealed.
//we can create the instance of the sealed class but we cannot inherit






namespace OOPS.Inheritance
{
    public class A
    {
        public void Method()
        {
            Console.WriteLine("I am in A");
        }

        public virtual void Data()
        {
            Console.WriteLine("I am in A");
        }
    }

    // below declaration of class X is absoultley allowed, 
    public class X : A
    {
        public void Method()
        {
            Console.WriteLine("I am in A");
        }
    }

    public class B : A
    {

        //if the base class and the derived class have same method name still it will run without any error and base class method will get called
        public virtual void Method()     
        {
            Console.WriteLine("I am in B");
        }

        public override void Data()
        {
            Console.WriteLine("I am in B: Data");
            base.Data();   //------------>  this will call base class Data function, also this line can be written anywhere in the class, lets say in any other function
        }
    }

    public class C : B
    {
        public override void Method()
        {
            Console.WriteLine("I am in C");
        }
    }

    public class D : B
    {
        public new void Method()
        {
            Console.WriteLine("I am in D");
        }
    }


    public class Client
    {
        public static void Execute()
        {
            A a = new B();
            a.Method();      //----- base method gets called
            a.Data();        //------ both derived and base class method gets called


            B b = new C();
            b.Method();      //----- derived method gets called  (override)

            B b1 = new D();
            b1.Method();     //----- base method gets called   (new)

            A ax = new X();
            ax.Method();    //----- base method gets called
        }
    }
}
