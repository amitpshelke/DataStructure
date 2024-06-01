using System.Collections.Generic;


namespace OOPS.Aggregation_Association_Composition
{
    /*
     
        Association => Association is a more general term to define a relationship among objects. Association means that an object "uses" another object.
                       We can define a one-to-one, one-to-many, many-to-one and many-to-many relationship among objects.

        Aggregation => Aggregation is a special type of Association. Aggregation is "*the*" relationship among objects. 
                       We can say it is a direct association among the objects. 
                       In Aggregation, the direction specifies which object contains the other object. 
                       There are mutual dependencies among objects.

        Composition => Composition is special type of Aggregation. 
                       It is a strong type of Aggregation. 
                       In this type of Aggregation the child object does not have their own life cycle. 
                       The child object's life depends on the parent's life cycle. Only the parent object has an independent life cycle. 
                       If we delete the parent object then the child object(s) will also be deleted. 
                       We can define the Composition as a "Part of" relationship.

     
     
     1. A Manager is a type of Employee                    [Inheritance]
     2. Manager has a swipe card to enter company premises [Association]
     3. manager has many workers under him                 [Aggregation]
     4. Manager salary depends on project success          [Composition]
     5. Project success depends on a manager               [Composition]
    */


    public class Employee
    {
        public Employee()
        {
        }
    }


    public class Manager : Employee
    {
        public List<Worker> workers = new List<Worker>();
        public Project project;
        public double Salary;


        //ctor
        public Manager()
        {
            project = new Project(this);
        }

        public void LogOn(SwipeCard swipeCard)
        {
            swipeCard.Swipe(this);
        }

        public string GetManagerName()
        {
            return "Amit";
        }

       
        public void HowIsManager(bool IsGood)
        {
            project.IsSucess = IsGood;
        }
    }



    public class SwipeCard
    {
        public void Swipe(Manager manager)
        {
            manager.LogOn(this);
        }

        public string MakeofSwipCard()
        {
            return "IZipCard";
        }
    }



    public class Worker
    {
        public string WorkerName = "";
    }



    public class Project
    {
        private Manager mgr;
        private bool isSucess = false;

        public bool IsSucess
        {
            get => isSucess;
            set
            {
                isSucess = value;
                if (isSucess)
                    mgr.Salary++;
                else
                    mgr.Salary--;
            }
                
        }

        public Project(Manager manager)
        {
            manager = this.mgr;
        }
    }




    public class Client
    {
        public static void Execute()
        {
            Manager mgr = new Manager();
            mgr.GetManagerName();

            SwipeCard swpCrd = new SwipeCard();
            swpCrd.MakeofSwipCard();

            Project prj = new Project(mgr);

            Worker wrk = new Worker();

        }
    }
}
