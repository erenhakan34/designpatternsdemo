using System;

namespace DesignPatternPlayGround.Patterns
{
    public static class BuilderPattern
    {
        public static void Run()
        {
            Console.WriteLine("Builder Pattern\n-----------------\n");

            CarService carService = new CarService();

            var opelCar = carService.BuildCar(new OpelCarBuilder());
            Console.WriteLine($"Opel car > { opelCar.Brand}");

            var toyotaCar = carService.BuildCar(new ToyotaCarBuilder());
            Console.WriteLine($"Toyota car > { toyotaCar.Brand}");
        }
    }

    public class Car1
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public Gear Gear { get; set; }
        public string Color { get; set; }
    }

    public enum Gear
    {
        Manual,
        Automatic
    }

    public class CarService
    {
        public Car1 BuildCar(ICarBuilder carBuilder)
        {
            carBuilder.SetBrand();
            carBuilder.SetModel();
            carBuilder.SetGear();
            carBuilder.SetYear();
            carBuilder.SetColor();
            return carBuilder.Build();
        }
    }

    public interface ICarBuilder
    {
        void SetBrand();
        void SetModel();
        void SetYear();
        void SetGear();
        void SetColor();
        Car1 Build();
    }

    public class OpelCarBuilder : ICarBuilder
    {
        private Car1 Car;

        public OpelCarBuilder()
        {
            Car = new Car1();
        }

        public Car1 Build()
        {
            return Car;
        }

        public void SetBrand()
        {
            Car.Brand = "Opel";
        }

        public void SetColor()
        {
            Car.Color = "Black";
        }

        public void SetGear()
        {
            Car.Gear = Gear.Automatic;
        }

        public void SetModel()
        {
            Car.Model = "Astra";
        }

        public void SetYear()
        {
            Car.Year = 2021;
        }
    }

    public class ToyotaCarBuilder : ICarBuilder
    {
        private Car1 Car;

        public ToyotaCarBuilder()
        {
            Car = new Car1();
        }

        public Car1 Build()
        {
            return Car;
        }

        public void SetBrand()
        {
            Car.Brand = "Toyota";
        }

        public void SetColor()
        {
            Car.Color = "White";
        }

        public void SetGear()
        {
            Car.Gear = Gear.Manual;
        }

        public void SetModel()
        {
            Car.Model = "Corolla";
        }

        public void SetYear()
        {
            Car.Year = 2020;
        }
    }
}
