using System;

namespace DesignPatternPlayGround.Patterns
{
    public static class FacadePattern
    {
        public static void Run()
        {
            Console.WriteLine("Facade Pattern\n-----------------\n");
            CarFacade carFacade = new CarFacade();
            carFacade.MakeCar();
        }
    }

    public class Car
    {
        public Car(Engine engine, Accessory accessory, CarBody body)
        {
            Engine = engine;
            Accessory = accessory;
            Body = body;

            Console.WriteLine($"Car Details\n------------- \n Engine = { Engine } Accessory = { Accessory} Body = { Body}");
        }

        public Engine Engine { get; set; }
        public Accessory Accessory { get; set; }
        public CarBody Body { get; set; }
    }

    public class Engine
    {
        public string Fuel { get; set; }
        public int Torque { get; set; }

        public override string ToString()
        {
            return $"Fuel={Fuel}-Torque={Torque}\n";
        }
    }

    public class Accessory
    {
        public bool HillHolder { get; set; }

        public bool CruiseControl { get; set; }
        public bool StartStop { get; set; }

        public override string ToString()
        {
            return $"HillHolder={HillHolder}-CruiseControl={CruiseControl}-StartStop={StartStop}\n";
        }
    }

    public class CarBody
    {
        public string OuterColor { get; set; }
        public bool LeatherSeat { get; set; }

        public override string ToString()
        {
            return $"OuterColor={OuterColor}-LeatherSeat={LeatherSeat}\n";
        }
    }

    public class CarFacade
    {
        public Car MakeCar()
        {
            Engine engine = new Engine() { Fuel = "Gas", Torque = 260 };
            Accessory accessory = new Accessory() { StartStop = false, HillHolder = false, CruiseControl = true };
            CarBody body = new CarBody() { LeatherSeat = true, OuterColor = "White" };

            Car car = new Car(engine, accessory, body);
            return car;
        }
    }
}
