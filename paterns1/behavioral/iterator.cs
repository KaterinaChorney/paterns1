using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paterns1.behavioral
{
    interface IDessertIterator
    {
        bool HasNext();            
        Dessert Next();            
        void Reset();             
    }

    interface IDessertCollection
    {
        IDessertIterator CreateIterator();  
    }

    class Dessert
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Dessert(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public void Display()
        {
            Console.WriteLine($"{Name} - {Price} UAH");
        }
    }

    class DessertMenuCustom : IDessertCollection
    {
        private List<Dessert> _desserts = new List<Dessert>();

        public void AddDessert(Dessert dessert)
        {
            _desserts.Add(dessert);
        }

        public IDessertIterator CreateIterator()
        {
            return new DessertMenuIterator(this);
        }

        public List<Dessert> GetDesserts()
        {
            return _desserts;
        }
    }

    class DessertMenuIterator : IDessertIterator
    {
        private DessertMenuCustom _menu;
        private int _position;

        public DessertMenuIterator(DessertMenuCustom menu)
        {
            _menu = menu;
            _position = 0;
        }

        public bool HasNext()
        {
            return _position < _menu.GetDesserts().Count;
        }

        public Dessert Next()
        {
            return _menu.GetDesserts()[_position++];
        }

        public void Reset()
        {
            _position = 0;
        }
    }
}