using SOLID.SRP;


//OPEN CLOSED PRINCIPLE

//[This class should be open for extension but closed for modification.]
namespace SOLID.OCP
{
    public class ReportGeneration
    {
        public string ReportType { get; set; }

        /// Method to generate report
        public void GenerateReport(Employee em)
        {
            if (ReportType == "CRS")
            {
                // Report generation with employee data in Crystal Report.
            }
            if (ReportType == "PDF")
            {
                // Report generation with employee data in PDF.
            }
        }
    }

    /****************************************************************************************************************************** 
     too much ‘If’ clauses are there and if we want to introduce another new report type like ‘Excel’, then you need 
     to write another ‘if’. This class should be open for extension but closed for modification.

     So if you want to introduce a new report type, then just inherit from IReportGeneration. 
     So IReportGeneration is open for extension but closed for modification.
    ******************************************************************************************************************************/

    public interface IReportGeneration
    {
        void GenerateReport(Employee em);
    }


    public class ReportGenerationExt
    {
        /// Method to generate report
        public virtual void GenerateReport(Employee em)
        {
        }
    }
  
    public class CrystalReportGeneration : IReportGeneration//ReportGenerationExt
    {
        public void GenerateReport(Employee em)
        {
            // Generate crystal report.
        }
    }
   
    public class PDFReportGeneration : ReportGenerationExt
    {
        public override void GenerateReport(Employee em)
        {
            // Generate PDF report.
        }
    }
}
