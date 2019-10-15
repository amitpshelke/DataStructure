using System;


//INTERFACE SEGREGRATION PRINCIPLE 

namespace SOLID.ISP
{
    /******************************************************************************************************************
    This principle states that any client should not be forced to use an interface which is irrelevant to it. 
    Now what does this mean, suppose there is one database for storing data of all types of employees (i.e. Permanent, non-permanent), 
    now what will be the best approach for our interface?

    *******************************************************************************************************************/
    public interface IEmployee
    {
        bool AddEmployeeDetails();
    }

    public class PermanentEmployee : IEmployee
    {
        public bool AddEmployeeDetails()
        {
            throw new NotImplementedException();
        }
    }

    public class ContratualEmployee : IEmployee
    {
        public bool AddEmployeeDetails()
        {
            throw new NotImplementedException();
        }
    }

    /***********************************************************************************************************************
    And all types of employee class will inherit this interface for saving data. This is fine right? Now suppose that 
    company one day told to you that they want to read only data of permanent employees. What you will do, just add one method to this interface?
    ************************************************************************************************************************/

    public interface IEmployeeExtn
    {
        bool AddEmployeeDetails();
        bool ShowEmployeeDetails(int EmpId);
    }

    /************************************************************************************************************************
    But now we are breaking something.We are forcing non-permanent employee class to show their details from database.
    So, the solution is to give this responsibility to another interface.
    *************************************************************************************************************************/

    public interface IAddOperation
    {
        bool AddEmployeeDetails();
    }
    public interface IGetOperation
    {
        bool ShowEmployeeDetails(int employeeId);
    }

    /*************************************************************************************************************************
     And non-permanent employee will implement only IAddOperation and permanent employee will implement both the interface.
    *************************************************************************************************************************/


}
