using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Static_class2
{
    /*
    Whenever a process is loaded in the RAM, we can say that the memory is roughly divided into three areas (within that process): 
    Stack, Heap, and Static (which, in .NET, is actually a special area inside Heap only known as High Frequency Heap). 

   The static part holds the “static” member variables and methods. 
   What exactly is static? Those methods and variables which don't need an instance of a class to be created are defined as being static. 
   In C# (and Java too), we use the static keyword to label such members as static. For e.g.:
   */

    class MyClass
    {
        public static int a;
        public static void DoSomething()
        {

            if(a==null)
            { }
        }
    }


    //These member variables and methods can be called without creating an instance of the enclosing class. 
    //E.g., we can call the static method DoSomething()

    //MyClass.DoSomething();


    /*
      We don't need to create an instance to use this static method.
        MyClass m = new MyClass();
        m.DoSomething(); //wrong code. will result in compilation error.
    */



    /*
    An important point to note is that the static methods inside a class can only use static member variables of that class. Let me explain why:
    Suppose you have a private variable in MyClass which is not static: 
    */


    class MyClass1
    {
        // non-static instance member variable
        private int a;
        //static member variable
        private static int b;
        //static method
        public static void DoSomething()
        {
            //this will result in compilation error as "a" has no memory
            //a = a + 1;
            //this works fine since "b" is static
            b = b + 1;
        }
    }

    //Now, we will call the DoSomething method as:
    //MyClass.DoSomething();

    /*
     Note that we have not created any instance of the class, so the private variable "a" has no memory as when we call a static method for a class, 
     only the static variables are present in the memory (in the Static part). Instance variables, such as “a” in the above example, 
     will only be created when we create an instance of the class using the “new” keyword, as:
    */

    //MyClass m = new MyClass();  ---> now "a" will get some memory


    /*
     But since we haven’t created an instance yet, the variable “a” is not there in the process memory. Only “b” and “DoSomething()” are loaded. 
     So when we call DoSomething(), it will try to increment the instance variable “a” by 1, but since the variable isn’t created, it results in an error. 
     The compiler flags an error if we try to use instance variables in static methods.

     Now, what is a static class? When we use the static keyword before a class name, we specify that the class will only have static member variables and methods. 
     Such classes cannot be instantiated as they don’t need to: they cannot have instance variables. Also, an important point to note is that such static classes are sealed by default, 
     which means they cannot be inherited further.

      This is because static classes have no behavior at all. There is no need to derive another class from a static class (we can create another static class).
     */



    /*
    Why do we need static classes? 
     
    As already written above, we need static classes when we know that our class will not have any behavior as such. 
    Suppose we have a set of helper or utility methods which we would like to wrap together in a class. Since these methods are generic in nature, 
    we can define them all inside a static class. Remember that helper or utility methods need to be called many times, and since they are generic in nature, 
    there is no need to create instances. E.g., suppose that you need a method that parses an int to a string. This method would come in the category of a utility or helper method.

     So using the static keyword will make your code a bit faster since no object creation is involved.


     **** Just like C# and Java, these variables don’t need an object to be declared to use them.
    */
}
