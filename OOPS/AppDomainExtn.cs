using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.AppDomainExtn
{
    /*
        Application domain is a logical isolated container inside a process. 
        In this logical isolation you can load and run .NET code in an isolated manner. 
        Below are the benefits of application domain: -

                - You can load and unload DLL inside these logical containers with out one container affecting the other. 
                  So if there are issues in one application domain you can unload that application domain and the other application domain work with out issues.
                - If you have a third party DLL and from some reason you do not trust that third party code. You can run that DLL in an isolated app domain with 
                  less privelges. For example you can say that the DLL cannot access your "c:" drive. And other DLLs which you trust you can run with full 
                  privilege in a different app domain.
                - You can run different versions of DLL in every application domain. 


    */

    public class BasicsOne
    {
        public BasicsOne()
        {
        }

        public void Do()
        {
        }
    }

    public class BasicsTwo
    {
        public BasicsTwo()
        {
        }

        public void Do()
        {
        }
    }

    [Serializable]
    public class ThirdParty
    {
        public ThirdParty()
        {
            Console.WriteLine("Thrid party loaded");
            System.IO.File.Create(@"C:\Sample.txt");
            Console.WriteLine("Third party unloaded");
        }
    }

    public class Client
    {
        public void Execute()
        {
            Type thirdParty = typeof(ThirdParty);

            //create permission set
            var permission = new PermissionSet(PermissionState.None);
            permission.AddPermission(new SecurityPermission(SecurityPermissionFlag.Execution));
            permission.AddPermission(new FileIOPermission(FileIOPermissionAccess.NoAccess, @"C:\"));

            //create AppDomain setup
            var setup = new AppDomainSetup();
            setup.ApplicationBase = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;


            AppDomain securedDomain = AppDomain.CreateDomain("securedDomain", null, setup);

            try
            {
                securedDomain.CreateInstanceFromAndUnwrap(thirdParty.Assembly.FullName, thirdParty.FullName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error =>" + ex.Message);
                AppDomain.Unload(securedDomain);
            }



            BasicsOne b1 = new BasicsOne();
            BasicsTwo b2 = new BasicsTwo();
        }
    }

}
