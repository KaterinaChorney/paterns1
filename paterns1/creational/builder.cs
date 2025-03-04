using System;

namespace paterns1.creational
{
    public class Cake
    {
        public string Layers { get; set; }
        public string Filling { get; set; }
        public string Decoration { get; set; }

        public void Show()
        {
            Console.WriteLine($"Cake with {Layers}, {Filling} filling, and {Decoration} decoration.");
        }
    }
    public abstract class CakeBuilder
    {
        protected Cake cake = new Cake();
        public abstract void BuildLayers();
        public abstract void AddFilling();
        public abstract void Decorate();
        public Cake GetCake()
        {
            return cake;
        }
    }
    public class ChocolateCakeBuilder : CakeBuilder
    {
        public override void BuildLayers()
        {
            cake.Layers = "chocolate biscuit";
        }
        public override void AddFilling()
        {
            cake.Filling = "chocolate cream";
        }
        public override void Decorate()
        {
            cake.Decoration = "chocolate chips";
        }
    }
    public class VanillaCakeBuilder : CakeBuilder
    {
        public override void BuildLayers()
        {
            cake.Layers = "vanilla biscuit";
        }
        public override void AddFilling()
        {
            cake.Filling = "vanilla cream";
        }
        public override void Decorate()
        {
            cake.Decoration = "fruits";
        }
    }
    public class Baker
    {
        public Cake MakeCake(CakeBuilder builder)
        {
            builder.BuildLayers();
            builder.AddFilling();
            builder.Decorate();
            return builder.GetCake();
        }
    }
}