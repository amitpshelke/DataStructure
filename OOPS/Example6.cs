using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.BeforeFieldInit
{

    /* 
      The static constructor for a class executes at most once in a given application domain. 
      The execution of a static constructor is triggered by the first of the following events to occur within an application domain:
          •An instance of the class is created.
          •Any of the static members of the class are referenced.
    */

    //The C# specification implies that no types with static constructors should be marked with the beforefieldinit flag. 
    //Indeed, this is upheld by the compiler, but with a slightly odd effect
    class Example6
    {
    }
}
