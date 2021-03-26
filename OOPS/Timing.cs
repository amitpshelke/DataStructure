using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace OOPS.TimingSample
{
    public class Timing
    {
        TimeSpan startTime;
        TimeSpan duration;

        public Timing()
        {
            startTime = new TimeSpan(0);
            duration = new TimeSpan(0);
        }

        /// <summary>
        /// Without calling GC explicitly
        /// </summary>
        /// <returns>Duration to run the code</returns>
        public string DoTest1() 
        {
            int[] nums = new int[100000];
            BuildArray(nums);

            startTime = Process.GetCurrentProcess().Threads[0].UserProcessorTime;

            WriteOutput(nums);

            duration = Process.GetCurrentProcess().Threads[0].UserProcessorTime.Subtract(startTime);

            return duration.TotalSeconds.ToString();
        }

        /// <summary>
        /// Calling GC explicitly
        /// </summary>
        /// <returns>Duration to run the code</returns>
        public string DoTest2()
        {
            int[] nums = new int[100000];
            BuildArray(nums);

            GC.Collect();
            GC.WaitForPendingFinalizers();

            startTime = Process.GetCurrentProcess().Threads[0].UserProcessorTime;

            WriteOutput(nums);

            duration = Process.GetCurrentProcess().Threads[0].UserProcessorTime.Subtract(startTime);

            return duration.TotalSeconds.ToString();
        }

        private void BuildArray(int[] arr)
        {
            for (int i = 0; i < 99999; i++)
            {
                arr[i] = i;
            }
        }

        private void WriteOutput(int[] arr)
        {
            string output = "";
            for (int i = 0; i < arr.GetUpperBound(0); i++)
            {
                output += arr[i] + " ";
            }
        }
    }


    public class Client
    {
        public static void Execute()
        {
            Timing t1 = new Timing();
            //t1.DoTest1();
            Timing t2 = new Timing();
            //t2.DoTest2();
        }
    }
}
