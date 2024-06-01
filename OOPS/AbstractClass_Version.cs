using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.AbstractClass_Version
{
    public abstract class Version1
    {
        public Version1()
        {
            Console.WriteLine("Version1.ctor");
        }
        public virtual void Launch()
        {
            Console.WriteLine("Version1.Launch");
        }
        public abstract void Perform();
    }

    public abstract class Version2 : Version1
    {
        public Version2():base()
        {
            Console.WriteLine("Version2.ctor");
        }
        public virtual void Launch2()
        {
            Console.WriteLine("Version2.Launch2");
        }
        public override abstract void Perform();
    }

    public class SubVersion1 : Version1
    {
        public SubVersion1():base()
        {
            Console.WriteLine("SubVersion1.ctor");
        }
        public override void Perform()
        {
            Console.WriteLine("SubVersion1.Perform");
        }
    }

    public class SubVersion2 : Version2
    {
        public SubVersion2() : base()
        {
            Console.WriteLine("SubVersion2.ctor");
        }
        public override void Perform()
        {
            Console.WriteLine("SubVersion2.Perform");
        }
    }

    public class Client
    {
        public static void Execute()
        {
            Version1 v1 = new SubVersion1();
            v1.Launch();
            v1.Perform();

            Console.WriteLine("******************************************************************************");

            Version2 v2 = new SubVersion2();
            v2.Launch();
            v2.Launch2();
            v2.Perform();
        }
    }
}
