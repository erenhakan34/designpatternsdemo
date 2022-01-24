using System;

namespace DesignPatternPlayGround.Patterns.Behavioral
{
    public static class StatePattern
    {
        public static void Run()
        {
            Console.WriteLine("State Pattern\n-----------------");
            ATMMachine atm = new ATMMachine();
            atm.InsertCard();
            atm.EjectCard();

            Console.WriteLine("******");

            atm.InsertCard();
            atm.InsertPin(123);
            atm.RequestCash(1000);

            Console.WriteLine("******");

            atm.InsertCard();
            atm.RequestCash(500);

            Console.WriteLine("******");

            atm.EjectCard();
        }
    }

    public abstract class ATMState 
    {
        public abstract void InsertCard(ATMMachine context);
        public abstract void EjectCard(ATMMachine context);
        public abstract void InsertPin(int pin, ATMMachine context);
        public abstract void RequestCash(int cashToWithdraw, ATMMachine context);
    }

    public class ATMMachine
    {
        ATMState state = new NoCard();
        public ATMState State { set => state = value; }

        public bool CorrectPinEntered { get; set; } = false;

        public void InsertCard()
        {
            state.InsertCard(this);
        }

        public void EjectCard()
        {
            state.EjectCard(this);
        }

        public void InsertPin(int pin)
        {
            state.InsertPin(pin, this);
        }

        public void RequestCash(int cashToWithdraw)
        {
            state.RequestCash(cashToWithdraw, this);
        }
    }

    public class NoCard : ATMState
    {
        public override void EjectCard(ATMMachine context)
        {
            Console.WriteLine("Please insert card before");
        }

        public override void InsertCard(ATMMachine context)
        {
            Console.WriteLine("Please pin number");
            context.State = new HasCard();
        }

        public override void InsertPin(int pin, ATMMachine context)
        {
            Console.WriteLine("Please insert card before");
        }

        public override void RequestCash(int cashToWithdraw, ATMMachine context)
        {
            Console.WriteLine("Please insert card before");
        }
    }

    public class HasCard : ATMState
    {
        public override void EjectCard(ATMMachine context)
        {
            Console.WriteLine("Card is ejected");
            context.State = new NoCard();
        }

        public override void InsertCard(ATMMachine context)
        {
            Console.WriteLine("No card allowed anymore");
        }

        public override void InsertPin(int pin, ATMMachine context)
        {
            Console.WriteLine("Pin number is validated");
            context.State = new HasPin();
        }

        public override void RequestCash(int cashToWithdraw, ATMMachine context)
        {
            Console.WriteLine("Please insert pin number");
        }
    }

    public class HasPin : ATMState
    {
        public override void EjectCard(ATMMachine context)
        {
            Console.WriteLine("Card is ejected");
            context.State = new NoCard();
        }

        public override void InsertCard(ATMMachine context)
        {
            Console.WriteLine("No card allowed anymore");
        }

        public override void InsertPin(int pin, ATMMachine context)
        {
            Console.WriteLine("Pin number has already been validated");
        }

        public override void RequestCash(int cashToWithdraw, ATMMachine context)
        {
            Console.WriteLine("Money is requested successfully");
            Console.WriteLine("Card is ejected");
            context.State = new NoCard();
        }
    }
}
