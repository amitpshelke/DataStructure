using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.Const_ReadOnly
{
    /*
    CONST
        -const keyword can be applied to fields or local variables
        -We must assign const field at time of declaration
        -No Memory Allocated Because const value is embedded in IL code itself after compilation. It is like find all occurrences of const variable and replace by its value. 
         So the IL code after compilation will have hard-coded values in place of const variables
        -Const in C# are by default static.
        -The value is constant for all objects
        -There is dll versioning issue - This means that whenever we change a public const variable or property , (In fact, it is not supposed to be changed theoretically), 
         any other dll or assembly which uses this variable has to be re-built
        -Only C# built-in types can be declared as constant
        -Const field can not be passed as ref or out parameter

    READONLY
        -readonly keyword applies only to fields not local variables
        -We can assign readonly field at the time of declaration or in constructor,not in any other methods.
        -dynamic memory allocated for readonly fields and we can get the value at run time.
        -Readonly belongs to the object created so accessed through only instance of class. To make it class member we need to add static keyword before readonly.
        -The value may be different depending upon constructor used (as it belongs to object of the class)
        -If you declare a non-primitive types (reference type) as readonly only reference is immutable not the object it contains.
        -Since the value is obtained at run time, there is no dll versioning problem with readonly fields/ properties.
        -We can pass readonly field as ref or out parameters in the constructor context. 




        having to declare the value at the time of a definition for a const VS readonly values can be computed dynamically but need to be assigned before the constructor exits.. after that it is frozen.
'const's are implicitly static. You use a ClassName.ConstantName notation to access them
         
    */

    //Consider below class is a part of Assembly A.dll
    public class Const_ReadOnly
    {
        public const int constVar = 2;

        public readonly int readOnlyVar;

        public Const_ReadOnly(int x)
        {
            readOnlyVar = 3;
        }
    }


    /*
     Assembly B references Assembly A and uses these values in code. 

     When this is compiled,
     
     - in the case of the const value, it is like a find-replace, the value 2 is 'baked into' the Assembly B's IL. 
       This means that if tomorrow I'll update constVar to 20 in the future. Assembly B would still have 2 till we recompile it.
     
     - in the case of the readonly value, it is like a ref to a memory location. The value is not baked into AssemblyB's IL. 
       This means that if the memory location is updated, Assembly B gets the new value without recompilation. 
       So if readOnlyVar is updated to 30, you only need to build Assembly A. 
       
       All clients do not need to be recompiled.

    */
}
