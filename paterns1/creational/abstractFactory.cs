using System;

namespace paterns1.creational
{
    abstract class Pie
    {
        public abstract void Bake();
    }
    abstract class Drink
    {
        public abstract void Prepare();
    }
    class ChocolatePie : Pie
    {
        public override void Bake()
        {
            Console.WriteLine("Chocolate pie is baked...");
        }
    }
    class VanillaPie : Pie
    {
        public override void Bake()
        {
            Console.WriteLine("Vanilla pie is baked......");
        }
    }
    class Coffee : Drink
    {
        public override void Prepare()
        {
            Console.WriteLine("Coffee is being prepared...");
        }
    }
    class Tea : Drink
    {
        public override void Prepare()
        {
            Console.WriteLine("Tea is being prepared...");
        }
    }
    interface IBakeryFactory
    {
        Pie CreatePie();
        Drink CreateDrink();
    }
    class ChocolateBakeryFactory : IBakeryFactory
    {
        public Pie CreatePie()
        {
            return new ChocolatePie();
        }
        public Drink CreateDrink()
        {
            return new Coffee();
        }
    }
    class VanillaBakeryFactory : IBakeryFactory
    {
        public Pie CreatePie()
        {
            return new VanillaPie();
        }
        public Drink CreateDrink()
        {
            return new Tea();
        }
    }
}