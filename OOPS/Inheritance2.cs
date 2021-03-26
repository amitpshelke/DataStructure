using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.Inheritance2
{
    public class Employee
    {
    }

    public class PermanentEmployee : Employee
    {
    }

    public class ContractualEmployee : Employee
    {
    }

    //Below declaration is perfectly allowed without any error.
    //Its like function Overloading


    public class Attendance
    {
        public void Calculate(Employee e)
        {
            Console.WriteLine("Employee");
        }

        public void Calculate(PermanentEmployee e)
        {
            Console.WriteLine("PermanentEmployee");
        }

        public void Calculate(ContractualEmployee e)
        {
            Console.WriteLine("ContractualEmployee");
        }
    }

    public class Client
    {
        public static void Execute()
        {
            //whichwever type of parameter is passed, respective method will get called.
            

            Attendance a = new Attendance();
            a.Calculate(new Employee());    
            a.Calculate(new PermanentEmployee());
            a.Calculate(new ContractualEmployee());


            //If there is NO class ContractualEmployee exist then, 
            //a.Calculate(null); --- > this line will NOT show error as call AMBIGUITY.
            //in this case only derived class method will get called, as it will use the latest version of the definition

            //AND
            //If there is class ContractualEmployee exist then,
            //a.Calculate(null);   --- > this line will show error as call AMBIGUITY.


        }
    }
}
