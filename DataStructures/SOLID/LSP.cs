using System;
using System.Collections.Generic;


//LISKOV SUBSTITUTION PRINCIPLE

namespace SOLID.LSP
{
    public abstract class Employee
    {
        public abstract string GetProjectDetails(int employeeId);

        public abstract string GetPFDetails(int employeeId);

        public abstract string GetDailyWages(int employeeId);
    }


    public class PermanentEmployee : Employee
    {
        public override string GetProjectDetails(int employeeId)
        {
            return "Child Project";
        }
        // May be for contractual employee we do not need to store the details into database.
        public override string GetPFDetails(int employeeId)
        {
            return "Child Employee";
        }

        public override string GetDailyWages(int employeeId)
        {
            throw new NotImplementedException(); // considering Daily Wages is only applicable to Contractual Employee
        }
    }


    public class ContractualEmployee : Employee
    {
        public override string GetProjectDetails(int employeeId)
        {
            return "Child Project";
        }

        public override string GetDailyWages(int employeeId)
        {
            return "Child Wages";
        }
        // May be for contractual employee we do not need to store the details into database.
        public override string GetPFDetails(int employeeId)
        {
            throw new NotImplementedException(); // considering PF is only applicable to Permanent Employee
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
            employeeList.Add(new PermanentEmployee());

            foreach (Employee e in employeeList)
            {
                e.GetPFDetails(1245);
            }


            List<IEmployee> employees = new List<IEmployee>();
            employees.Add(new PermanentEmployee_Extn());
            employees.Add(new ContractualEmployee_Extn());

            List<IProvidentFund> projects = new List<IProvidentFund>();
            projects.Add(new PermanentEmployee_Extn());
            //projects.Add(new ContractualEmployee_Extn());    <======= This line will give COMPILE TIME ERROR

        }
    }

    public interface IEmployee
    {
        string GetEmployeeDetails(int employeeId);
    }

    public interface IProvidentFund
    {
        string GetPFDetails(int employeeId);
    }

    public interface IDailyWages
    {
        string GetWagesDetails(int employeeId);
    }




    public class PermanentEmployee_Extn : IEmployee, IProvidentFund
    {
        public string GetEmployeeDetails(int employeeId)
        {
            return "";
        }

        public string GetPFDetails(int employeeId)
        {
            return "";
        }
    }

    public class ContractualEmployee_Extn : IEmployee, IDailyWages
    {
        public string GetEmployeeDetails(int employeeId)
        {
            return "";
        }

        public string GetWagesDetails(int employeeId)
        {
            return "";
        }
    }

}
