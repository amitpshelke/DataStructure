using System;
using System.Linq;

namespace OOPS.String_Interpolation
{
    /*
        The $ special character identifies a string literal as an interpolated string. 
        An interpolated string is a string literal that might contain interpolation expressions. 
        
        When an interpolated string is resolved to a result string, items with interpolation expressions 
        are replaced by the string representations of the expression results. 
        
        This feature is available starting with C# 6.0
    */


    public class Sample
    {
        public void Method1()
        {
            string name = "Mark";
            var date = DateTime.Now;

            // string Formatting:
            Console.WriteLine("Hello, {0}! Today is {1}, it's {2:HH:mm} now.", name, date.DayOfWeek, date);

            // string Interpolation:
            Console.WriteLine($"Hello, {name}! Today is {date.DayOfWeek}, it's {date:HH:mm} now.");

            // Both calls produce the same output that is similar to:
            // Hello, Mark! Today is Wednesday, it's 19:40 now.



        }

        public void Method2()
        {
            /*
            As the colon (":") has special meaning in an interpolation expression item, in order to use a conditional operator 
            in an interpolation expression, enclose that expression in parentheses.
           */

            string name1 = "Horace";
            int age = 34;

            Console.WriteLine($"He asked, \"Is your name {name1}?\", but didn't wait for a reply.");

            Console.WriteLine($"{name1} is {age} year{(age == 1 ? "" : "s")} old.");

            // Expected output is:
            // He asked, "Is your name Horace?", but didn't wait for a reply.
            // Horace is 34 years old.
        }



        //@ special character serves as a verbatim identifier
        public void Method3()
        {
            string[] @for = { "John", "James", "Joan", "Jamie" };
            for (int ctr = 0; ctr < @for.Length; ctr++)
            {
                Console.WriteLine($"Here is your gift, {@for[ctr]}!");
            }

            // The example displays the following output:
            //     Here is your gift, John!
            //     Here is your gift, James!
            //     Here is your gift, Joan!
            //     Here is your gift, Jamie!
        }


        public void Method4()
        {
            string type1 = "a,b,c";
            string result1 = string.Join(",", type1.Split(',').Select(x => $"'{x}'"));

            string[] type2 = new string[3] { "a", "b", "c" };
            string result2 = string.Join(",", type2.Select(x => $"'{x}'"));
        }
    }


    public class Client
    {
        public static void Execute()
        {
            Sample s = new Sample();
            s.Method1();
            s.Method2();
            s.Method3();
        }
    }
}
