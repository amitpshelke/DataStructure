using System;
using System.Collections.Generic;


//LISKOV SUBSTITUTION PRINCIPLE

namespace SOLID.LSP
{
    public abstract class Employee
    {
        public virtual string GetProjectDetails(int employeeId)
        {
            return "Base Project";
        }
        public virtual string GetEmployeeDetails(int employeeId)
        {
            return "Base Employee";
        }
    }


    public class CasualEmployee : Employee
    {
        public override string GetProjectDetails(int employeeId)
        {
            return "Child Project";
        }
        // May be for contractual employee we do not need to store the details into database.
        public override string GetEmployeeDetails(int employeeId)
        {
            return "Child Employee";
        }
    }


    public class ContractualEmployee : Employee
    {
        public override string GetProjectDetails(int employeeId)
        {
            return "Child Project";
        }
        // May be for contractual employee we do not need to store the details into database.
        public override string GetEmployeeDetails(int employeeId)
        {
            throw new NotImplementedException();
        }
    }

    /**********************************************************************************************************************************
    This principle is simple but very important to understand. Child class should not break parent class’s type definition and behavior
    Yes right, for contractual employee, you will get "NotImplementedException" and that is violating LSP. Then what is the solution? 
    Break the whole thing in 2 different interfaces, 
    1. IProject 
    2. IEmployee 
    and implement according to employee type.
    **********************************************************************************************************************************/

    public class ExecuteCase
    {
       public static void Execute()
        {
            List<Employee> employeeList = new List<Employee>();

            employeeList.Add(new ContractualEmployee());
            employeeList.Add(new CasualEmployee());

            foreach (Employee e in employeeList)
            {
                e.GetEmployeeDetails(1245);
            }


            List<IEmployee> employees = new List<IEmployee>();
            employees.Add(new CasualEmployee_Extn());
            employees.Add(new ContractualEmployee_Extn());

            List<IProject> projects = new List<IProject>();
            projects.Add(new CasualEmployee_Extn());
            //projects.Add(new ContractualEmployee_Extn());    <======= This line will give COMPILE TIME ERROR

        }
    }

    public interface IEmployee
    {
        string GetEmployeeDetails(int employeeId);
    }

    public interface IProject
    {
        string GetProjectDetails(int employeeId);
    }




    public class CasualEmployee_Extn : IEmployee, IProject
    {
        public string GetEmployeeDetails(int employeeId)
        {
            throw new NotImplementedException();
        }

        public string GetProjectDetails(int employeeId)
        {
            throw new NotImplementedException();
        }
    }

    public class ContractualEmployee_Extn : IEmployee
    {
        public string GetEmployeeDetails(int employeeId)
        {
            throw new NotImplementedException();
        }
    }

}
