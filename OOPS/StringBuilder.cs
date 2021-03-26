using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.StringBuilder_String
{
    /*
    StringBuilder is used to represent a mutable string of characters. 
    Mutable means the string which can be changed. 

    So String objects are immutable but StringBuilder is the mutable string type. 

    It will not create a new modified instance of the current string object but do the modifications in the existing string object. 
    The complete functionality of StringBuilder is provided by StringBuilder class which is present in System.Text namespace.

    Need of the StringBuilder: As stated above that the String class objects are immutable which means that if the user will modify any 
    string object it will result into the creation of a new string object. 

    It makes the use of string costly. 

    So when the user needs the repetitive operations on the string then the need of StringBuilder come into existence. 
    It provides the optimized way to deal with the repetitive and multiple string manipulation operations. 
         
    */


    public class StringBuilderDemo
    {
        public void DoSomeThing1()
        {
            string a = "Geek";
            // taking a string which is to be Concatenate 
            String b = "forGeeks";

            // using String.Concat method you can also replace it with 
            a = a + b; 
        }

        public void DoSomeThing2()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Geek");
            sb.Append("for geeks");
        }

        public void DoSomeThing3()
        {
            try
            {
                string firstName = "Amit";
                Console.WriteLine(firstName[1]);
                Console.WriteLine(firstName[3]);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
    }


    public class Client
    {
        public static void Execute()
        {
            StringBuilderDemo sbd = new StringBuilderDemo();
            sbd.DoSomeThing1();
            sbd.DoSomeThing2();
            sbd.DoSomeThing3();
        }
    }
}
