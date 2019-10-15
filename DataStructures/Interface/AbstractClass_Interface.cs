using System;

namespace DataStructures.AbstractClass_Interface
{
    public abstract class Employee
    {
        protected string id;
        protected string fname;
        protected string lname;

        public abstract string ID { get; set; }
        public abstract string FName { get; set; }
        public abstract string LName { get; set; }


        public string Add()
        {
            return "Employee Added :: " + id + "::" + fname + "::" + lname;
        }

        public string Update()
        {
            return "Employee Updated :: " + id + "::" + fname + "::" + lname;
        }

        public string Delete()
        {
            return "Employee Deleted :: " + id + "::" + fname + "::" + lname;
        }
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
        public Emp_FullTime1()
        {
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
    }



    public class Emp_FullTime2 : IEmployee
    {
        protected string id;
        protected string fname;
        protected string lname;

        public string ID { get => id; set => id =value; }
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
            //Abstract Class 
            Employee emp = new Emp_FullTime1();
            emp.ID = "123";
            emp.FName = "John";
            emp.LName = "Cena";

            Console.WriteLine(emp.Add());


            //Interface
            IEmployee iemp = new Emp_FullTime2();
            iemp.ID = "456";
            iemp.FName = "Harry";
            iemp.LName = "Carter";

            Console.WriteLine(iemp.Add());
        }
    }

}
