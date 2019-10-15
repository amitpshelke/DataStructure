using System;

namespace DesignPattern.Structural.Decorator
{
    public interface IVehicle
    {
        string Make { get; }

        string Model { get; }

        string Price { get; }
    }

    public class HondaCity : IVehicle
    {
        public string Make { get { return "Honda"; } }
 
        public string Model { get { return "City"; } }

        public string Price { get { return "$ 10,000"; } }

    }


    public abstract class VehicleDecorator : IVehicle
    {
        private IVehicle _iVehicle = null;

        //ctor
        public VehicleDecorator(IVehicle vehicle)
        {
            _iVehicle = vehicle;
        }

        public string Make { get { return _iVehicle.Make; } }

        public string Model { get { return _iVehicle.Model; } }

        public string Price { get { return _iVehicle.Price; } }
    }


    public class SpecialOffer : VehicleDecorator
    {
        //ctor
        public SpecialOffer(IVehicle iVehicle) : base(iVehicle)
        {

        }

        public string Discount { get; set; }

        public string Price
        {
            get
            {
                return "Actual Price = " + " Discount of " + Discount + " on base price of " + base.Price;
            }
        }
    }


    public class Client
    {
        public static void Execute()
        {
            HondaCity hondaCity = new HondaCity();

            SpecialOffer so = new SpecialOffer(hondaCity);
            so.Discount = "25%";

            Console.WriteLine(so.Price);
            Console.ReadKey();
        }
    }
}
