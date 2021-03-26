using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.ExtensionMethod
{

    /*
     Extension methods allow you to inject additional methods without modifying, deriving or recompiling the original class, struct or interface. 
     Extension methods can be added to your own custom class, .NET framework classes, or third party classes or interfaces.

        * An extension method must be defined in a top-level static class.
        * An extension method with the same name and signature as an instance method will not be called.
        * Extension methods cannot be used to override existing methods.
        * The concept of extension methods cannot be applied to fields, properties or events.
        * Overuse of extension methods is not a good style of programming.

    */
    public static class IntExtensions
    {
        public static bool IsGreaterThan(this int i, int value)
        {
            return i > value;
        }

        public static int ToInt32(this string str)
        {
            return Int32.Parse(str);
        }

        public static string ToFirstUpperChar(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(text[0]) + text.Substring(1);
        }
    }

   

    public class Client
    {
        public static void Execute()
        {
            int i = 10;
            bool result = i.IsGreaterThan(100);

            string str = "123456";
            int num = str.ToInt32();

            string str1 = "amit";
            string output = str1.ToFirstUpperChar();
        }
    }
}
