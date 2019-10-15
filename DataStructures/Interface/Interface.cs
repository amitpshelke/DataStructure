using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/************************************************************

WHY DO WE USE INTERFACE?

1. Extensibility - We can easily extend the interfaces to create new classes.
2. Implementation Hiding
3. Accessing object through interfaces
4. Loose Coupling 

•create loosely coupled software
•support design by contract (an implementor must provide the entire interface)
•allow for pluggable software
•allow different objects to interact easily
•hide implementation details of classes from each other
•facilitate reuse of software 


- Enforce Rules
- Decoupling
- Abstraction
- Signature
- Standardization
- Versioning
- Multiple Inheritance


     
************************************************************/



namespace DataStructures.Interface
{
    public interface IDriver
    {
        int YearsOfExperience { get; set; }
        void Drive();
    }

    public class NormalDriver : IDriver
    {
        private int yearsOfExp;

        public NormalDriver(int yearsOfExp)
        {
            this.YearsOfExperience = yearsOfExp;
        }

        public int YearsOfExperience
        {
            get { return yearsOfExp; }
            set { yearsOfExp = value; }
        }

        public void Drive()
        {
            Console.WriteLine(" Can drive the Normal car");
        }
    }

    public class RaceDriver : IDriver
    {
        private int yearsOfExp;
        public RaceDriver(int yearsOfExp)
        {
            this.YearsOfExperience = yearsOfExp;
        }

        public int YearsOfExperience
        {
            get
            { return yearsOfExp; }
            set
            { yearsOfExp = value; }
        }

        public void Drive()
        {
            Console.WriteLine("Can drive a Race car");
        }
    }



    public interface ICar
    {
        string ModelName { get; set; }
        void DriveCar(IDriver driver);
    }

    public class NormalCar : ICar
    {
        private string modelName = string.Empty;
        
        //ctor
        public NormalCar(string modelName)
        {
            ModelName = modelName;
        }

        public string ModelName
        {
            get { return modelName; }
            set { modelName = value; }
        }

        public void DriveCar(IDriver driver)
        {
            if (driver.YearsOfExperience > 10)
                driver.Drive();
        }
    }

    public class RaceCar : ICar
    {
        private string modelName = string.Empty;

        //ctor
        public RaceCar(string modelName)
        {
            ModelName = modelName;
        }

        public string ModelName
        {
            get
            { return modelName; }
            set{ modelName = value; }
        }

        public void DriveCar(IDriver driver)
        {
            if (driver.YearsOfExperience > 20)
                driver.Drive();
        }
    }

    public class VintageCar : ICar
    {
        private string modelName = string.Empty;

        //ctor
        public VintageCar(string modelName)
        {
            ModelName = modelName;
        }

        public string ModelName
        {
            get
            { return modelName; }
            set { modelName = value; }
        }

        public void DriveCar(IDriver driver)
        {
            if (driver.YearsOfExperience == 30)
                driver.Drive();
        }
    }


    public static class Factory
    {
        public static ICar CreateNormalCar(string modelName)
        {
            return new NormalCar(modelName);
        }

        public static ICar CreateRaceCar(string modelName)
        {
            return new RaceCar(modelName);
        }

        public static IDriver CreateNormalDriver(int yearsOfExp)
        {
            return new NormalDriver(yearsOfExp);
        }

        public static IDriver CreateRaceDriver(int yearsOfExp)
        {
            return new RaceDriver(yearsOfExp);
        }
    }



    public class ExecuteCase
    {
        public static void Execute()
        {
            IDriver normalDriver = Factory.CreateNormalDriver(12);
            ICar normalCar = Factory.CreateNormalCar("Toyota");
            normalCar.DriveCar(normalDriver);


            IDriver raceDriver = Factory.CreateRaceDriver(24);
            ICar raceCar = Factory.CreateRaceCar("Ferrari");
            raceCar.DriveCar(raceDriver);


            normalCar.DriveCar(raceDriver);
            raceCar.DriveCar(normalDriver);

        }
    }

}
