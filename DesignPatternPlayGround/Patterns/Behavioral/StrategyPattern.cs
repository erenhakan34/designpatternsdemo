using System;

namespace DesignPatternPlayGround.Patterns
{
    public static class StrategyPattern
    {
        public static void Run()
        {
            Console.WriteLine("Strategy Pattern\n-----------------");

            PaymentOperation paymentOperation = new PaymentOperation(new CreditCardPaymentStrategy());
            paymentOperation.Pay();

            paymentOperation = new PaymentOperation(new CashPaymentStrategy());
            paymentOperation.Pay();
        }
    }

    //Strategy
    public interface IPaymentStrategy
    {
        void Pay();
    }

    //Concrete strategy
    public class CreditCardPaymentStrategy : IPaymentStrategy
    {
        public void Pay()
        {
            Console.WriteLine("Credit card payment");
        }
    }

    //Concrete strategy
    public class CashPaymentStrategy : IPaymentStrategy
    {
        public void Pay()
        {
            Console.WriteLine("Cash payment");
        }
    }

    //Context class
    public class PaymentOperation 
    {
        private readonly IPaymentStrategy _paymentStrategy;

        public PaymentOperation(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }

        public void Pay() 
        {
            _paymentStrategy.Pay();
        }
    }
}
