using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace OOPS.RegularExpression
{
    public class RegExpression
    {
        public void Resolve(string inputData, string Expression)
        {
            MatchCollection mc = Regex.Matches(inputData, Expression);

            Console.WriteLine("Input Data : " + inputData);
            Console.WriteLine("Expression : " + Expression);
            foreach (Match m in mc)
            {
                Console.Write(string.Join(" | " , m.Value.ToString()));
            }
        }
    }

    public class Client
    {
        public static void Execute()
        {
            RegExpression regExpression = new RegExpression();
            regExpression.Resolve("the fat cat run down the street, it was searching for mouse to eat", "[a-z]");  //look for cat word in complete string,  g - stands for 'global'
            regExpression.Resolve("the fat cat run down the street, it was searching for mouse to eat", "[a-m]");  //look for first instance cat word 
            regExpression.Resolve("the fat cat run down the street, it was searching for mouse to eat", "^[a-m]$");
        }
    }
}
