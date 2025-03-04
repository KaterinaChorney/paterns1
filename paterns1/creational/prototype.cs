using System;

namespace paterns1.creational
{
    public interface ICookiesPrototype
    {
        ICookiesPrototype Clone();
        void Show();
    }
    public class Cookies : ICookiesPrototype
    {
        public string Name { get; set; }
        public string Layers { get; set; }
        public string Filling { get; set; }
        public string Decoration { get; set; }

        public Cookies(string name, string layers, string filling, string decoration)
        {
            Name = name;
            Layers = layers;
            Filling = filling;
            Decoration = decoration;
        }
        public ICookiesPrototype Clone()
        {
            return new Cookies(Name, Layers, Filling, Decoration);
        }
        public void Show()
        {
            Console.WriteLine($"Cookies \"{Name}\": {Layers}, {Filling}, {Decoration}");
        }
    }
}