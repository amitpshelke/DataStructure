using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;


namespace SampleWinApp
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        Timer t1 = new Timer();
        public Form1()
        {
            InitializeComponent();


            doStuff();  //first time when service kick off, do this manually


            Timer t1 = new Timer();
            t1.Interval = (1000 * 60 * 60); // 20 minutes...
            t1.Elapsed += new ElapsedEventHandler(t1_Elapsed);
            t1.AutoReset = true;
            t1.Start();
        }

        private void t1_Elapsed(object sender, ElapsedEventArgs e)
        {
            DateTime scheduledRun = DateTime.Today.AddHours(8);  // runs today at 8 AM.
            System.IO.FileInfo lastTime = new System.IO.FileInfo(@"C:\lastRunTime.txt");  //store in File or DB
            DateTime lastRan = lastTime.LastWriteTime;
            if (DateTime.Now > scheduledRun)
            {
                TimeSpan sinceLastRun = DateTime.Now - lastRan;
                if (sinceLastRun.Hours > 23)
                {
                    doStuff();
                    {
                        //modify file here with current date here
                    }
                }
            }
        }

        static void doStuff()
        {
            Console.WriteLine("Running the method!");
        }
    }
}
