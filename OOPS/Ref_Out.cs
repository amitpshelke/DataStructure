using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.Ref_Out
{
    public class Person
    {
        public string Name { get; set; }
    }

    public class AppData
    {
        public void DoSomething(ref Person p, ref int radius)
        {
            //ref parameter must be initialized before passing to a method, else it will be null
            p.Name = "Riyanshi";

            double area = 3.1415 * radius * radius;

            //even value type variable will act like refence variable
            radius = 10;
        }

        public void Nothing(out Person p)
        {
            p = new Person();   // if this line is commented then it causes --->    Error :: out parameter must be assigned a value before control leaves the current method
            p.Name = "Harry";   
        }
    }

    public class Client
    {
        public static void Execute()
        {
            int rad = 5;

            Person px = new Person();
            px.Name = "Amit";

            AppData appData = new AppData();

            Console.WriteLine("Radius :" + rad);
            appData.DoSomething(ref px, ref rad); 
            Console.WriteLine("New Radius :" + rad);

            appData.Nothing(out px);
        }
    }
}
