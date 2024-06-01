using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.Covariance_ContraVariance_Invariance
{
    /*
     CoVariance and ContraVariance and not just individual topics but it depends or it is connected to 
    
     - Polymorphism, 
     - IN vs OUT Type,  
     - Assignment Compatibility, 
     - SubTyping Principle, 
     - Liskov Substitute Principle, 
     - More Derived vs. Less Derived Type 
    */
    
    
    /*
     
       *** Polymorphic Behaviour ***

         1. Polymorphic behaviour is the ability of a subtype (derived type) to be treated as if it were an instance of the supertype (base type). 

         2. Any method that accepts an instance of supertype (base type) will also be able to accept an instance of subtype (derived type) without any explicit 
            casting and also without any type sniffing. 

         3. Now variance will come into the picture when you introduce another type that might use Supertype and/or Subtype through a generic parameter.

         4. In short Covariance and Contravariance are polymorphism extensions to the arrays, delegates, and generics.
     
     */

            public class GrandFather : Object
            {
                public int Id { get; set; }
                public string Name { get; set; }
            }

            public class Father : GrandFather
            {
                public int Age { get; set; }

                public string City { get; set; }
            }

            public class Son : Father
            {
                public string Address1 { get; set; }

                public string Address2 { get; set; }
            }


    /*
        *** SubTyping Principle and Covariant Returns ***

        1. C# has a relationship defined for types and objects in the form of Inheritance, Polymorphism, and Subtyping.

        2. A Derived Class reference can be assigned to the Base Class reference, this is known as SubTyping. 

           For example:  GrandFather_object = Father_object

                         Base b = new Derived

        3. If a method has an input parameter of type GrandFather class, the caller can pass an instance of Father class as input.

        4. If a method has a GrandFather class return type, it can return a Father class object also. 

        5. But if a method is virtual and is overridden in a derived class, the override method can return any subtype reference 
           but it cannot change the return type from the overriding method signature (until C# 8).

        6. Thanks to C# 9 for introducing the Covariant Return Type. So it allows the overriding method to declare a "More Derived" return type than the method it overrides.

        7. Covariant Return Type is a feature that enables you to override a method of a base class with a method in the derived class to return a more specific type.  
           Earlier versions of C# did not allow returning a different type in an overridden method of a derived class.
    */


    /*
    
       *** Liskov Substitute Principle (LSP) ***

       This is one of the most common SOLID Principles of OOPS. 
       
       It says:

                "If S is a subtype of T, then objects of type T may be replaced with objects of type S, without breaking the program."

                In short, the object of the parent class can be replaced with the object of the child class without any breaking changes.

                For example: GrandFather_object = Father_object
    
    */


    /*
     
       *** More Derived vs. Less Derived Type | More Specific vs Less Specific Type ***

       1. Inheritance is the most common feature of any OOPS language. So in C#, we can make a transition between related types.

       2. In C# language every type derives from the Object class. So the Object class is the Super Base Class.

       3. So Object class is always the Less Derived type compared to any other type.

       4. A Child type is always more derived compare to the immediate parent.

          For Example:  (Less Derived) Object < GrandFather < Father < Child (More Derived)

          Here:

                a) Object is a Less Derived Type or Less Specific Type compare to any other type (GrandFather, Father, and Child).

                b) GrandFather is More Derived or More Specific compare to the Object type. At the same time, it is Less Derived or Less Specific compare to Father.

                c) Father is More Derived or More Specific compare to the GrandFather or Object type. At the same time, it is Less Derived or Less Specific compare to Child.

                d) Finally Child is Most Derived or Most Specific compare to any other parent type (GrandFather, Father, and Object).

     */


    /*
     
       *** Assignment Compatibility: (Conversion, Casting, Boxing and Unboxing) ***

       1. When we do an assignment in C#, the Left Hand Side type must be compatible with the Right Hand Side type otherwise you will get a compile-time error. 
          So you can say that in C# assignments work with covariant mode. 

       2. We can assign More Derived types to Less Derived types without any problems. But the reverse is not true.

       3. If the LHS type is compatible, the compiler does the implicit conversion and boxing internally for you.

       4. Using Covariance, we can convert all types to Object types and used them for assignments.

       5. Covariance preserves the assignment compatibility and Contravariance opposite the covariance functionality.
     
     */


    /*
     
       *** Generics ***

        1. Generics were introduced in C# 2.0 with Visual Studio 2005 in the year 2005.

        2. Generics are used to decouple the type from the method, class, or interface.

        3. Generics introduces the concept of type parameters to .NET, which makes it possible to design classes and methods that 
           defer the specification of one or more types until the class or method is declared and instantiated by client code. 

        4. Generics reduces both the cost or risk of runtime casts and boxing operations.
    
     */
}
