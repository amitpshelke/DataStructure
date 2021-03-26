using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.ExtensionMethods
{
    /*
     * Extension methods allow you to inject additional methods without modifying, deriving or recompiling the original class, struct or interface.
     * Extension methods can be added to your own custom class, .NET framework classes, or third party classes or interfaces.
     */

    public static class IntExtensions
    {
        public static bool IsGreaterThan(this int i, int value)
        {
            return i > value;
        }
    }

    public static class StringExtensions
    {
        public static string FirstCharToUpper(this string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }
    }


    public class Client
    {
        public static void Execute()
        {
            string x = "amit".FirstCharToUpper();
            int y = 20;

            bool result = y.IsGreaterThan(5);
        }
    }
}
