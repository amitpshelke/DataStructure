using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.Interview
{
    class Test11
    {
        static string value = "";

        public void Execute()
        {
            FooAsync();
            value = "amit";
        }

        static async Task FooAsync()
        {
            await Task.Delay(6);
            Console.WriteLine(value);
        }
    }
}
