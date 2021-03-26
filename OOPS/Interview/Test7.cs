using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Test : CDK Global

namespace OOPS.Test7
{
    public class Client
    {
        public static void Execute()
        {
            Console.WriteLine("CDK Global Test Run....");

            Console.WriteLine("Customer Type : Regular  ||  Billing Amount : 5000");
            Billing b1 = new Billing(5000, CustomerType.Regular);
            double FinalBill = b1.Calculate();
            Console.WriteLine("Bill Amount After Discount : " + FinalBill);

            Console.WriteLine("Customer Type : Regular  ||  Billing Amount : 10000");
            Billing b2 = new Billing(10000, CustomerType.Regular);
            FinalBill = b2.Calculate();
            Console.WriteLine("Bill Amount After Discount : " + FinalBill);

            Console.WriteLine("Customer Type : Regular  ||  Billing Amount : 15000");
            Billing b3 = new Billing(15000, CustomerType.Regular);
            FinalBill = b3.Calculate();
            Console.WriteLine("Bill Amount After Discount : " + FinalBill);

            Console.WriteLine("-----------------------------------------------------------------------------");


            Console.WriteLine("Customer Type : Premium  ||  Billing Amount : 4000");
            Billing b4 = new Billing(4000, CustomerType.Premium);
            FinalBill = b4.Calculate();
            Console.WriteLine("Bill Amount After Discount : " + FinalBill);

            Console.WriteLine("Customer Type : Regular  ||  Billing Amount : 8000");
            Billing b5 = new Billing(8000, CustomerType.Premium);
            FinalBill = b5.Calculate();
            Console.WriteLine("Bill Amount After Discount : " + FinalBill);

            Console.WriteLine("Customer Type : Regular  ||  Billing Amount : 12000");
            Billing b6 = new Billing(12000, CustomerType.Premium);
            FinalBill = b6.Calculate();
            Console.WriteLine("Bill Amount After Discount : " + FinalBill);

            Console.WriteLine("Customer Type : Regular  ||  Billing Amount : 20000");
            Billing b7 = new Billing(20000, CustomerType.Premium);
            FinalBill = b7.Calculate();
            Console.WriteLine("Bill Amount After Discount : " + FinalBill);


        }
    }

    public enum CustomerType
    {
        Regular = 0,
        Premium = 1
    }

    public class DiscountSlab
    {
        public CustomerType CustomerType { get; set; }
        public double AmountFrom { get; set; }
        public double Discount { get; set; }
    }


    internal class Billing
    {
        private double _billAmtBeforeDisc = 0;
        private CustomerType _customerType = CustomerType.Regular;

        List<DiscountSlab> discountSlabs = new List<DiscountSlab>();

        public Billing(int billAmtBeforeDisc, CustomerType customerType)
        {
            _billAmtBeforeDisc = billAmtBeforeDisc;
            _customerType = customerType;
            DiscountTable();
        }


        //Add discount slabs here.
        private void DiscountTable()
        {
            discountSlabs.Add(new DiscountSlab() { CustomerType = CustomerType.Regular, AmountFrom = 0, Discount = 0 });
            discountSlabs.Add(new DiscountSlab() { CustomerType = CustomerType.Regular, AmountFrom = 5000, Discount = 10 });
            discountSlabs.Add(new DiscountSlab() { CustomerType = CustomerType.Regular, AmountFrom = 10000, Discount = 20 });
            discountSlabs.Add(new DiscountSlab() { CustomerType = CustomerType.Premium, AmountFrom = 0, Discount = 10 });
            discountSlabs.Add(new DiscountSlab() { CustomerType = CustomerType.Premium, AmountFrom = 4000, Discount = 15 });
            discountSlabs.Add(new DiscountSlab() { CustomerType = CustomerType.Premium, AmountFrom = 8000, Discount = 20 });
            discountSlabs.Add(new DiscountSlab() { CustomerType = CustomerType.Premium, AmountFrom = 12000, Discount = 30 });

            discountSlabs = discountSlabs.FindAll(d => d.CustomerType == _customerType);
            discountSlabs.Reverse();
        }

        internal double Calculate()
        {
            double disAmount = 0;
            double tempBillAmt, FinalBillAmount = 0;

            tempBillAmt = _billAmtBeforeDisc;

            foreach (var disc in discountSlabs)
            {
                if (disc.AmountFrom <= tempBillAmt)
                {
                    disAmount += (tempBillAmt - disc.AmountFrom) * (disc.Discount / 100);
                    tempBillAmt = tempBillAmt - (tempBillAmt - disc.AmountFrom);
                }
            }

            return FinalBillAmount = (_billAmtBeforeDisc - disAmount);
        }

    }
}