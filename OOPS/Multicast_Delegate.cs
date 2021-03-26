using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.Multicast_Delegate
{
    /*
      Delegate can be seen as a placeholder for a/some method(s).

      By defining a delegate, you are saying to the user of your class, "Please feel free to assign, any method that matches this signature, 
      to the delegate and it will be called each time my delegate is called".

      Typical use is of course events. All the OnEventX delegate to the methods the user defines.

      Delegates are useful to offer to the user of your objects some ability to customize their behavior. 
      Most of the time, you can use other ways to achieve the same purpose and I do not believe you can ever be forced to create delegates. 
      It is just the easiest way in some situations to get the thing done.


     1. In Multicasting, Delegates can be combined and when you call a delegate, a whole list of methods is called.
     2. All methods are called in FIFO (First in First Out) order.
     3. + or += Operator is used for adding methods to delegates.
     4. – or -= Operator is used for removing methods from the delegates list.
     5. Delegates can be used to define callback methods.
    */

    public delegate void RectangleDelegate(int len, int bre);

    //Deletegate with return type
    public delegate double ReturnTypeDelegate(int rad);

    //Deletegate with out parameter
    public delegate bool OutParamDelegate(int rad, out double circum);

    public class Rectangle
    {
        public void Area(int Length, int Breadth)
        {
            int area = Length * Breadth;
            Console.WriteLine("Area :: " + area);
        }

        public void Perimeter(int Length, int Breadth)
        {
            int Perimeter = 2 * (Length + Breadth);
            Console.WriteLine("Perimeter :: " + Perimeter);
        }

        public void DiagonalLength(int Length, int Breadth)
        {
            double dLength = Math.Sqrt((Length * Length) + (Breadth * Breadth));
            Console.WriteLine("DiagonalLength :: " + dLength);
        }
    }


    public class Circle
    {
        public double Area(int radius)
        {
            double area = (3.1514 * radius * radius);
            Console.WriteLine("Area of Circle : " + area);
            return area;
        }

        public bool Circumference(int radius, out Double circumference)
        {
            circumference = 2 * 3.1415 * radius;

            Console.WriteLine("Circumference of Circle : " + circumference);

            if (radius == 0)
                return false;
            else
                return true;
        }
    }



    //Delegate as a parameter

    public delegate void PrintDelegate(int value);

    public class Print
    {
        public static void PrintHelper(PrintDelegate delegateFunc, int numToPrint)
        {
            delegateFunc(numToPrint);
        }

        public static void PrintNumber(int num)
        {
            Console.WriteLine("Number: {0,-12:N0}", num);
        }

        public static void PrintMoney(int money)
        {
            Console.WriteLine("Money: {0:C}", money);
        }
    }



    public class Client
    {
        public static void Execute()
        {
            Rectangle rect = new Rectangle();

            RectangleDelegate rd = rect.Area;
            rd.Invoke(2, 3);

            //Adding a method to delegate object
            rd += rect.Perimeter;
            rd.Invoke(5, 7);

            //Removing a method from delegate object
            rd -= rect.Area;
            rd -= rect.Perimeter;

            rd += rect.DiagonalLength;
            rd.Invoke(6, 4);
            rd -= rect.DiagonalLength;


            //Another way to call delegate
            RectangleDelegate rd1 = rect.Area;

            RectangleDelegate rd2 = rect.Perimeter;

            RectangleDelegate rd3 = rect.DiagonalLength;

            RectangleDelegate rdFinal = rd1 + rd2 + rd3;

            rdFinal.Invoke(7, 8);


            Circle cir = new Circle();
            ReturnTypeDelegate rt = cir.Area;
            rt.Invoke(11);


            OutParamDelegate opd = cir.Circumference;
            double Circum = 0.0;
            bool success = opd.Invoke(13, out Circum);


            //Delegate as a parameter
            Print.PrintHelper(Print.PrintNumber, 10000);
            Print.PrintHelper(Print.PrintMoney, 10000);
        }
    }
}
