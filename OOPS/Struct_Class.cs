using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.Struct_Class
{
    public class A
    {
    }

    public class B : A
    {
    }

    public struct C
    {
        //struct are value types

        //inheritance cannot be applied in struct

        //Structs are value types, allocated either on the stack or inline in containing types.

        //Function members in a struct cannot be abstract or virtual, and the override modifier is allowed only to the override methods inherited from System.ValueType.
        //Struct does not allow the instance field declarations to include variable initializers.But, static fields of a struct are allowed to include variable initializers.

        //A struct can implement interfaces.
        //A struct can be used as a nullable type and can be assigned a null value

        //Abstract and sealed modifiers are not allowed and struct member cannot be protected or protected internals.

        //Struct cannot be a base class. So, Struct types cannot abstract and are always implicitly sealed.
    }

    public class Client
    {
        public static void Execute()
        {
            A a = new B();

            C c = new C();
        }
    }

}
