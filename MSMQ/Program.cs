using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSMQ
{
    class Program
    {
        static void Main(string[] args)
        {
            ReservationSystem rs = new ReservationSystem();
            rs.Create();
            rs.ReadQueue(@".\Private$\IDG");

        }
    }
}
