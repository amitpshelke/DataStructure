
// SINGLE RESPONSIBILITY PRINCIPLE

namespace SOLID.SRP 
{
    public class Employee
    {
        public int Employee_Id { get; set; }
        public string Employee_Name { get; set; }



        // Method to insert into Employee table
        public bool InsertIntoEmployeeTable(Employee em)
        {
            return true;
        }

        // Method to generate report
        public void GenerateReport(Employee em)
        {
        }
    }

    /******************************************************************************************************************************************
      Employee class is taking 2 responsibilities, 
      (1)one is to take responsibility of employee database operation 
      (2)another one is to generate employee report. 
      Employee class should not take the report generation responsibility because suppose some days after your customer asked you to give a facility to generate the report 
      in Excel or any other reporting format, then this class will need to be changed and that is not good.

       So according to SRP, one class should take one responsibility so we should write one different class for report generation, 
       so that any change in report generation should not affect the ‘Employee’ class.
    *******************************************************************************************************************************************/

    public class EmployeeModified
    {
        public int Employee_Id { get; set; }
        public string Employee_Name { get; set; }


        // Method to insert into Employee table
        public bool InsertIntoEmployeeTable(EmployeeModified em)
        {
            return true;
        }
    }

    public class ReportGeneration
    {
        /// Method to generate report
        public void GenerateReport(EmployeeModified em)
        {
        }
    }

}
