using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.IO;

namespace DataProcessorService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        private readonly ServiceProcessInstaller processInstaller;
        private readonly System.ServiceProcess.ServiceInstaller serviceInstaller;

        public ProjectInstaller()
        {
            InitializeComponent();
            processInstaller = new ServiceProcessInstaller();
            serviceInstaller = new System.ServiceProcess.ServiceInstaller();

            // Service will run under system account
            processInstaller.Account = ServiceAccount.LocalSystem;

            // Service will have Start Type of Manual
            serviceInstaller.StartType = ServiceStartMode.Automatic;

            serviceInstaller.ServiceName = "DataProcessorService";

            Installers.Add(serviceInstaller);
            Installers.Add(processInstaller);

            serviceInstaller.AfterInstall += new InstallEventHandler(ServiceInstaller_AfterInstall);
        }

        void ServiceInstaller_AfterInstall(object sender, InstallEventArgs e)
        {
            try
            {
                using (ServiceController sc = new ServiceController(serviceInstaller.ServiceName))
                {
                    sc.Start();
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter sw = new StreamWriter(@"D:\DataProcessorService.txt", true))
                {
                    sw.WriteLine(ex.Message);
                }
            }
        }
    }
}
