using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.DelegateSample
{
    public class Delegates
    {
        public delegate void Areapointer(int r);
        public static Areapointer areapointer = CalculateArea;


        public static void CalculateArea(int radius)
        {
            double area = 3.1415 * radius * radius;
            Console.WriteLine("Area :: " + area);
        }
    }

    public class AnanoymousMethods
    {
        public delegate void AreaPointer(int r);
        public AreaPointer areapointer;

        public delegate double CircumferencePointer(int r);
        public CircumferencePointer circumpointer;

        //ctor
        public AnanoymousMethods()
        {
            areapointer = new AreaPointer(delegate(int radius)
                                                        {
                                                            double area = 3.1415 * radius * radius;
                                                            Console.WriteLine("Area :: " + area);
                                                        });


            circumpointer = new CircumferencePointer(delegate (int radius)
                                                                        {
                                                                            double circumference = 2 * 3.1415 * radius;
                                                                            Console.WriteLine("Circumference :: " + circumference);
                                                                            return circumference;
                                                                        });

        }
    }

    public class FuncDelegate
    {
        public void Express()
        {
            //when it is require to have input and output from a function then this Func is used Func<input, output>

            Func<Double, Double> area = r => (3.1415 * r * r);
            Console.WriteLine("Area : " + area(10));

            Func<Double, Double> circum = r => (3.1415 * r * r);
            Console.WriteLine("Circumference : " + circum(10));
        }
    }


    public class ActionDelegate
    {
        public void Express()
        {
            ////when it is require to have input and no output from a function then this Action is used Action<input>
            Action<string> action = a => Console.WriteLine(a);
            action("this is sample text");
        }
    }

    public class PredicateDelegate
    {
        public void Express()
        {
            ////when it is require to have input and boolean output from a function then this Action is used Predicate<input>
            Predicate<string> pred = p => (p.Length > 5);
            Console.WriteLine(pred("Sample_Text"));

            //Using the above predicate to a list of string to find out the length of items with length greater than 5
            List<string> olist = new List<string>();
            olist.Add("amit");
            olist.Add("swati");
            olist.Add("shelke");
            olist.Add("riyanshi");

            int result = olist.RemoveAll(pred);
            Console.WriteLine("Total Items Removed : " + result);
        }
    }




    public class Client
    {
        public static void Execute()
        {

            Console.WriteLine("************************** Delegates *********************************");
            Delegates.areapointer.Invoke(15);


            Console.WriteLine("************************** Ananoymous Methods *********************************");
            AnanoymousMethods am = new AnanoymousMethods();
            am.areapointer(25);
            am.circumpointer(30);


            Console.WriteLine("************************** Generic Delegate Func<> *********************************");
            FuncDelegate gd = new FuncDelegate();
            gd.Express();

            Console.WriteLine("************************** Generic Delegate Action<> *********************************");
            ActionDelegate ad = new ActionDelegate();
            ad.Express();

            Console.WriteLine("************************** Generic Delegate Predicate<> *********************************");
            PredicateDelegate pd = new PredicateDelegate();
            pd.Express();


            Console.ReadKey();
        }
    }
}
