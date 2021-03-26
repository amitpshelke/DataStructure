using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxCopSamples
{
    public class Math
    {
        public string Add(string val1, string val2)
        {
            if (string.IsNullOrEmpty(val1) || string.IsNullOrEmpty(val2))
                return "Please enter value";

            return (double.Parse(val1) + double.Parse(val2)).ToString();
        }

       
    }
}
