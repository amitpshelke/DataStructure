using System.Collections.Generic;


namespace OOPS.Aggregation_Association_Composition
{
    /*
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
