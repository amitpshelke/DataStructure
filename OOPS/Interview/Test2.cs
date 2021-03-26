using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.Test2
{
   //the question was asked by Microsoft
   //Create a diff tool algorithm 
   //

   //So that fastest way to compare two string is through getting the hashcode of that string

    public class Test2
    {
        public void ReadFile()
        {
            int counter = 0;
            string line;

            // Read the file and display it line by line.  
            System.IO.StreamReader file =  new System.IO.StreamReader(@"d:\test.txt");
            while ((line = file.ReadLine()) != null)
            {
                System.Console.WriteLine(line);
                int x = line.GetHashCode();
                counter++;
            }
            file.Close();
        }
    }

    public class Client
    {
        public static void Execute()
        {
            Test2 t2 = new Test2();
            t2.ReadFile();
        }
    }
}
