using System;

/*
A factory class helps us to centralize the creation of classes and types.    
*/



namespace DesignPattern.Creational.Factory
{
    public interface IInvoice
    {
        void Print();
    }

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
    }


    public class InvoiceWithHeader : IInvoice
    {
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
        }
    }
}
