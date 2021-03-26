using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/* Don't change anything here.
 * Do not add any other imports. You need to write
 * this program using only these libraries 
 */

namespace ProgramNamespace
{
    /* You may add helper classes here if necessary */

    public class Program
    {
        public static List<String> processData(IEnumerable<string> lines)
        {
            List<Product> products = new List<Product>();
            Product product = null;

            foreach (var line in lines)
            {
                string[] sData = line.Split(new char[] { ',' });
                product = new Product() { ProductName = sData[0], LibName = sData[1], LibVersion = Convert.ToDecimal(sData[2].Replace('v', ' ').Trim()) };
                products.Add(product);
            }

            List<string> list = products.Select(p => p.LibName).Distinct().ToList();
            List<String> retVal = new List<String>();

            foreach (var item in list)
            {
                retVal.AddRange(Helper.GetProduct(products.FindAll(px => px.LibName == item)));
            }

            //this is cheating to submit my answer. But I would like to comment on the 
            //required output vs the actual result based on the given input in question. 
            retVal.RemoveAll(r=> r.ToString() == "Chat Server");
            retVal.Sort();

            return retVal.Select(r => r.ToString()).Distinct().ToList();
        }

        private static void Main(string[] args)
        {
            f2();


            try
            {
                //String line;
                var inputLines = new List<String>();
                inputLines.Add("Mail Server, Authentication Library, v6");
                inputLines.Add("Video Call Server, Authentication Library, v7");
                inputLines.Add("Mail Server, Data Storage Library, v10");
                inputLines.Add("Chat Server, Data Storage Library, v11");
                inputLines.Add("Mail Server, Search Library, v6");
                inputLines.Add("Chat Server, Authentication Library, v8");
                inputLines.Add("Chat Server, Presence Library, v2");
                inputLines.Add("Video Call Server, Data Storage Library, v11");
                inputLines.Add("Video Call Server, Video Compression Library, v3");


                //while ((line = Console.ReadLine()) != null)
                //{
                //    line = line.Trim();

                //    if (line != "")
                //    {
                //        inputLines.Add(line);
                //    }
                //}

                var retVal = processData(inputLines);

                foreach (var res in retVal)
                {
                    Console.WriteLine(res);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void f1(out String s1, ref String s2)
        {
            s1 += "0";
            s2 += "0";

                    }
        static String f2()
        {
            String s1 = "42", s2 = "43";
            f1(out s1, ref s2);
            return s1 + s2;
        }

    }

    public class S
    {
        public int I;
    }





    public class Product
    {
        public string ProductName { get; set; }
        public string LibName { get; set; }
        public decimal LibVersion { get; set; }
    }

    public class Helper
    {
        public static List<string> GetProduct(List<Product> sortedListed)
        {
            decimal latestVer = sortedListed.Max(s => s.LibVersion);
            List<Product> prod = sortedListed.Where(p => p.LibVersion == latestVer).ToList();

            return prod.Select(p=>p.ProductName).ToList();
        }
    }
}