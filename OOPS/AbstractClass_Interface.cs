
using System;

namespace OOPS.AbstractClass_Interface
{
    //Abstract Class : An abstract class allows you to create functionality that subclasses can implement or override.
    //Interface      : An interface only allows you to define functionality, not implement it. 

    //   https://www.codementor.io/vipinc/when-to-use-abstract-classes-and-when-interfaces-c-interview-questions-jtzll1sn7

    /*
    An abstract class is a special type of class that cannot be instantiated. 
    An abstract class can have constructors—this is one major difference between an abstract class and an interface

        USE AN ABSTRACT CLASS
            1). When creating a class library which will be widely distributed or reused—especially to clients, 
                use an abstract class in preference to an interface; because, it simplifies versioning. 
                This is the practice used by the Microsoft team which developed the Base Class Library.

            2). Use an abstract class to define a common base class for a family of types.
            3). Use an abstract class to provide default behavior.
            4). Subclass only a base class in a hierarchy to which the class logically belongs.

            USE AN INTERFACE
            1). When creating a standalone project which can be changed at will, use an interface because it offers more design flexibility.
            2). Use interfaces to introduce polymorphic behavior without subclassing and to model multiple inheritance—allowing a specific type to support numerous behaviors.
            3). Use an interface to design a polymorphic hierarchy for value types.
            4). Use an interface when an immutable contract is really intended.
            5). A well-designed interface defines a very specific range of functionality. Split up interfaces that contain unrelated functionality.


        WHY DO WE NEED ABSTRACT CLASS WHEN WE HAVE NORMAL CLASS AS BASE CLASS

        Abstract class basically allows us to provide default functionality for all the child classes through non-abstract methods.
 
        Below are reasons to define a class as abstract, 
        - When we do not want developers to create object of parent class because parent class object won't allow us to use method of child class, 
          and will probably give run time exception if any method throws MethodNotImplemented exception in base class. So use abstract class instead of 
          concrete class.And when we try to create object of an abstract class user will get error on compilation instead of run-time. So,it is safe to have abstract class.

        - Updating base class in large project system is easier than changing it in interface. In case we have added one new parameter to non-abstract method of abstract 
          class then we only need to update the calling part where we need to pass an extra parameter. But changing this in interface will break the code in all the inherited classes of the interface where actual implementation is written. 

        - Code duplicacy/maintainability needs to be handled by reusing the code. And abstract helps that part.
          
          * Why do we need abstract method in abstract class?

            When we want to force child class to provide the implementation of any method.
 
            Suppose we have child classes for full-time and part-time employees and they needed to calculate salary of both type of employees separately since they have
            different implementation for the calculations. A full timer may be on a yearly basis and part timers are on a monthly or project basis. In that case we need 
            to have an abstract method called calculateSalary() in abstract class and why we need it is because we must require the salary of each employee irrespective of 
            its type, otherwise child classes may neglect it to give it an implementaion. Since it's in abstract class, compiler will make sure that each child class has 
            its own separate implementation.

    */
    public abstract class Employee
    {
        protected string id;
        protected string fname;
        protected string lname;

        public abstract string ID { get; set; }
        public abstract string FName { get; set; }
        public abstract string LName { get; set; }


        //ctor
        public Employee()
        {
            Console.WriteLine("Base Constructor is called");
            //Constructor is allowed in Abstract class, only private constructor is not allowed
        }
        public Employee(int x)
        {
            Console.WriteLine("Base Constructor is called");
            //Constructor is allowed in Abstract class, only private constructor is not allowed
        }

        static Employee()
        {
            Console.WriteLine("Base Static Constructor is called");
        }


        public string Add()
        {
            return "abstract Employee Added :: " + id + "::" + fname + "::" + lname;
        }

        public string Update()
        {
            return "abstract Employee Updated :: " + id + "::" + fname + "::" + lname;
        }

        public string Delete()
        {
            return "abstract Employee Deleted :: " + id + "::" + fname + "::" + lname;
        }

        public abstract void Print();
    }



    public interface IEmployee
    {
        string ID { get; set; }
        string FName { get; set; }
        string LName { get; set; }


        string Add();
        string Update();
        string Delete();

    }




    public class Emp_FullTime1 : Employee
    {
        static Emp_FullTime1()
        {
            Console.WriteLine("Derived Static Constructor is called");
        }

        public Emp_FullTime1() : base()
        {
            Console.WriteLine("Derived Constructor is called");
        }

        public Emp_FullTime1(int x):base(x)
        {
            Console.WriteLine("Derived Constructor is called");
        }

        public override string ID
        {
            get { return id; }
            set { id = value; }
        }
        public override string FName
        {
            get { return fname; }
            set { fname = value; }
        }
        public override string LName
        {
            get { return lname; }
            set { lname = value; }
        }

        public new string Add() // this will not get called unless the base class method is not virtual
        {
            return "Derived Employee Added :: " + id + "::" + fname + "::" + lname;
        }

        public override void Print()
        {
           Console.WriteLine("Abstract Method Called");
        }
    }



    public class Emp_FullTime2 : IEmployee
    {
        protected string id;
        protected string fname;
        protected string lname;

        public string ID { get => id; set => id = value; }
        public string FName { get => fname; set => fname = value; }
        public string LName { get => lname; set => lname = value ; }

        public string Add()
        {
            return "Employee Added :: " + id + "::" + fname + "::" + lname;
        }

        public string Delete()
        {
            return "Employee Deleted :: " + id + "::" + fname + "::" + lname;
        }

        public string Update()
        {
            return "Employee Updated :: " + id + "::" + fname + "::" + lname;
        }
    }



    public class Client
    {
        public static void Execute()
        {
            //Base B = new Derived .... this allowed in Abstract class

            //Abstract Class 
            Employee emp = new Emp_FullTime1(5);    //this will call static constructor
            emp.ID = "123";
            emp.FName = "John";
            emp.LName = "Cena";

            Employee emp1 = new Emp_FullTime1(10);   //this will not call static constructor, as it has already been called in above instantiation

            Console.WriteLine(emp.Add());

            emp.Print();



            //Interface
            IEmployee iemp = new Emp_FullTime2();
            iemp.ID = "456";
            iemp.FName = "Harry";
            iemp.LName = "Carter";

            Console.WriteLine(iemp.Add());
        }
    }

}
