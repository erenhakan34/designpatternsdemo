using System;

namespace DesignPatternPlayGround.Patterns
{
    public static class TemplatePattern
    {
        public static void Run() 
        {
            Console.WriteLine("Template Pattern\n-----------------\n");

            CarShopping carShopping = new CarShopping();
            carShopping.Go();

            FruitShopping fruitShopping = new FruitShopping();
            fruitShopping.Go();
        }
    }

    public abstract class Shopping 
    {
        private void Start() => Console.WriteLine("Shopping is started");
        private void Finish() => Console.WriteLine("Shopping is finished");

        protected abstract void Pay();

        public void Go() 
        {
            Start();
            Pay();
            Finish();
        }
    }

    public class CarShopping : Shopping
    {
        protected override void Pay()
        {
            Console.WriteLine("Payment is done by credit");
        }
    }

    public class FruitShopping : Shopping
    {
        protected override void Pay()
        {
            Console.WriteLine("Payment is done by cash");
        }
    }
}
