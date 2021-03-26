using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MultiThreading
{
    public class Example14
    {
        public void MainThread()
        {
            Func<string, int> method = Work;

            method.BeginInvoke("Test Work", Done, method);
        }

        private int Work(string s)
        {
            return s.Length;
        }

        //Its a callback function
        private void Done(IAsyncResult asyncResult)
        {
            var temp = (Func<string, int>)asyncResult.AsyncState;

            int result = temp.EndInvoke(asyncResult);

            Console.WriteLine("String Length : " + result);
        }
    }
}
