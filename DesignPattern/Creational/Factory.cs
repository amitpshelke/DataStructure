﻿using System;

/*
A factory class helps us to centralize the creation of classes and types.    
*/



namespace DesignPattern.Creational.Factory
{
    public interface IInvoice
    {
        void Print();
    }


    /*   IMPORTANT NOTE
    
    The issue with logical statements such as switch and if-else in a factory class is whenever you’re developing some new type 
    it should be able to create, you’ll have to modify the factory itself.
    This clearly violates the Open/Closes principle.
 
     
    */

    public class FactoryInvoice
    {
        public static IInvoice GetInvoice(int InvoiceType)
        {
            IInvoice invoice = null;

            switch (InvoiceType)
            {
                case 1:
                    {
                        invoice = new InvoiceWithHeader();
                        break;
                    }
                case 2:
                    {
                        invoice = new InvoiceWithoutHeader();
                        break;
                    }
                case 3:
                    {
                        invoice = new InvoiceWithFooter();
                        break;
                    }
            }
            return invoice;
        }

        // above method can have this alternative to avoid swtich case 
        public static dynamic GetInvoice(string InputType)
        {
            if (string.IsNullOrEmpty(InputType)) return null;

            var newType = Activator.CreateComInstanceFrom("DesignPattern.exe", InputType);

            if (newType == null) return null;
            else
                return newType.Unwrap();
        }
    }


    public class InvoiceWithHeader : IInvoice
    {
        public delegate void Printer(string message);
        public event Printer PrintEventHandler;

        public void Print()
        {
            Console.WriteLine("InvoiceWithHeader");
        }

        
    }


    public class InvoiceWithoutHeader : IInvoice
    {
        public void Print()
        {
            Console.WriteLine("InvoiceWithoutHeader");
        }
    }

    public class InvoiceWithFooter : IInvoice
    {
        public void Print()
        {
            Console.WriteLine("InvoiceWithFooter");
        }
    }


    public class Client
    {
        public static void Execute()
        {
            IInvoice invoice = FactoryInvoice.GetInvoice(1);
            invoice.Print();

            var invoiceX = FactoryInvoice.GetInvoice("DesignPattern.Creational.Factory.InvoiceWithHeader");
            invoiceX.PrintEventHandler += PrintMe();
            invoiceX.Print();
        }

        private static dynamic PrintMe()
        {
            Console.WriteLine("Amit");
            return "Amit";
        }
    }
}



