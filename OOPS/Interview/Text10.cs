using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.Interview
{
    class Text10
    {
        public void Execute()
        {
            List<Action> actions = new List<Action>();
            for (int i = 0; i < 10; i++)
            {
                i = 5;
                actions.Add(() => Console.WriteLine(i));   // this not print anything. It will just add anonymous method to collection.
            }

            foreach (var action in actions)
            {
                action(); // this will call the anonymous function to print the current value of i, which is  i = 10 in last iteration of above loop
            }

            //so the output will be 10 print 10 times
        }


        public void Execute1()
        {
            List<Action> actions = new List<Action>();

            int i = 0;

            for (i = 0; i < 10; i++)
            {
                i = 5;
                actions.Add(() => Console.WriteLine(i));   // this not print anything. It will just add anonymous method to collection.
            }

            i = 15;  //here current value is changed

            foreach (var action in actions)
            {
                action(); // this will call the anonymous function to print the current value of i, which is  i = 15 in last iteration of above loop
            }

            //so the output will be 15 print 10 times
        }
    }
}
