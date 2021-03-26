using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuance
{
    public class Advertisement
    {
        private string _content = string.Empty;
        public Advertisement(string Content)
        {
            _content = Content;
        }
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
    }
}
