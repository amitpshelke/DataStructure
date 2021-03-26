using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Creational.Factory_V2
{
    public abstract class Car
    {
        public string Model { get; set; } = "Unknown";
    }

    public class Audi : Car
    {
        public Audi()
        {
        }
    }

    public class BMW : Car
    {
        public BMW()
        {
        }
    }


    /*
      The ‘factoryMethod’ is stored at the end of ‘RegisterCar’. This allows us to configure the factory from somewhere else, e.g. at application startup.
      Then, we have two ways of creating a car. Either by using the Indexer on the factory object, or, by using the CreateCar method. 
      Both are equally valid options.
    */
    public class CarFactory
    {
        private readonly Dictionary<string, Func<Car>> cars;

        public CarFactory()
        {
            cars = new Dictionary<string, Func<Car>>();
        }

        public Car this[string carType]=> CreateCar(carType);   //indexder

        public Car CreateCar(string carType) => cars[carType]();

        public void RegisterCar(string carType, Func<Car> factoryMethod)
        {
            if (string.IsNullOrEmpty(carType)) return;

            if (factoryMethod == null) return;

            cars[carType] = factoryMethod;
        }
    }

    /*     **** We can also use reflection ****
            
    My approach will still require you to manually go register a new Car type with our factory object. 
    If you want to avoid this, you’ll need to do some reflection work.
    Reflection is a great tool when you want your code to be extremely flexible and extensible. 

    *** I would never use reflection to implement Factory design pattern, unless there was a special case.


    */


    public class Client
    {
        public static void Execute()
        {
            CarFactory carFactory = new CarFactory();
            carFactory.RegisterCar("Audi", ()=> new Audi { Model = "A2"});
            carFactory.RegisterCar("BMW", () => new Audi { Model = "X5" });

            Console.WriteLine(carFactory["BMW"].Model);
            Console.WriteLine(carFactory["Audi"].Model);

            Car bmw = carFactory["BMW"];

        }
    }
}
