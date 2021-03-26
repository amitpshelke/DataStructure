using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    /*
     Data Abstraction is the property by virtue of which only the essential details are exhibited to the user.

     Data Abstraction may also be defined as the process of identifying only the required characteristics of an 
     object ignoring the irrelevant details. The properties and behaviors of an object differentiate it 
     from other objects of similar type and also help in classifying/grouping the objects.

    
    ** Encapsulation vs Data Abstraction **
        Encapsulation is data hiding(information hiding) while Abstraction is detail hiding(implementation hiding).
        
        While encapsulation groups together data and methods that act upon the data, data abstraction deals with 
        exposing to the user and hiding the details of implementation.

    ** Advantages of Abstraction **
        It reduces the complexity of viewing the things.
        Avoids code duplication and increases reusability.
        Helps to increase security of an application or program as only important details are provided to the user.

    */
    public abstract class Shape
    {
        public abstract int area();
    }

    
    public class Square : Shape
    {
        private int side;

        public Square(int x = 0)
        {
            side = x;
        }
      
        public override int area()
        {
            Console.Write("Area of Square: ");
            return (side * side);
        }
    }


    public class Client
    {
        public static void Execute()
        {
            Shape sh = new Square(4);
            double result = sh.area();
            Console.Write("{0}", result);
        }
    }

}
