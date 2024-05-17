using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoraterZadaca
{
    public interface ICoffee
    {
        double GetCost();
        String GetDescription();
    }

    public class Espresso : ICoffee
    {

        public double GetCost()
        {
            return 1.99;
        }

        public String GetDescription()
        {
            return "Espresso";
        }
    }

    public abstract class CoffeeDecorator : ICoffee
    {
        protected ICoffee coffee;

        public CoffeeDecorator(ICoffee coffee)
        {
            this.coffee = coffee;
        }
        public virtual double GetCost()
        {
            return coffee.GetCost();
        }
        public virtual String GetDescription()
        {
            return coffee.GetDescription();
        }
    }

    public class Milk : CoffeeDecorator
    {

        public Milk(ICoffee coffee) : base(coffee) { }
        public override double GetCost()
        {
            return coffee.GetCost() + 0.20;
        }
        public override String GetDescription()
        {
            return coffee.GetDescription() + " with Milk";
        }
    }
    public class Client
    {
        public static void Main()
        {
            ICoffee CoffeeWithMilk = new Milk(new Espresso());
            Console.WriteLine("Description: " + CoffeeWithMilk.GetDescription());
            Console.WriteLine("Price: " + CoffeeWithMilk.GetCost());
            ICoffee espresso = new Espresso();
            Console.WriteLine("Description: " + espresso.GetDescription());
            Console.WriteLine("Price: " + espresso.GetCost());
        }
    }
}
