using System.Collections.Generic;
using System.IO;
using System.ServiceProcess;

namespace DataProcessorService
{
    public partial class FileReader : ServiceBase
    {
        public FileReader()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            DebugLog.Write(LogType.Debug, "FileReader", "OnStart", "Service Started");


            IEnumerable<string> dirs = Directory.EnumerateDirectories(@"D:\Photos");

            foreach (var dir in dirs)
            {
                IEnumerable<string> files = Directory.EnumerateFiles(dir);

                foreach (var file in files)
                {
                    DebugLog.Write(LogType.Debug, "FileReader", "OnStart", file);
                }
            }

        }

        protected override void OnStop()
        {
            using (StreamWriter sw = new StreamWriter(@"D:\Photos\Data.txt", true))
            {
                sw.WriteLine("Service Stopped");
            }
        }
    }
}
