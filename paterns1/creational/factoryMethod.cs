using System;

namespace paterns1.creational
{
    abstract class Pastry
    {
        public abstract void Bake();
    }
    class Cupcake : Pastry
    {
        public override void Bake()
        {
            Console.WriteLine("The cupcake is baked...");
        }
    }
    class Croissant : Pastry
    {
        public override void Bake()
        {
            Console.WriteLine("The croissant is baked...");
        }
    }
    abstract class Bakery
    {
        public abstract Pastry CreatePastry();
    }
    class CakeBakery : Bakery
    {
        public override Pastry CreatePastry()
        {
            return new Cupcake();
        }
    }
    class CroissantBakery : Bakery
    {
        public override Pastry CreatePastry()
        {
            return new Croissant();
        }
    }
}