using System;
using System.Collections.Generic;

namespace paterns1.structural
{
    interface IDessertItem
    {
        void GetInformation();
        decimal GetPrice(); 
    }

    class SingleDessert : IDessertItem
    {
        private string _name;
        private decimal _price; 

        public SingleDessert(string name, decimal price)
        {
            _name = name;
            _price = price;
        }

        public void GetInformation()
        {
            Console.WriteLine(" Dessert: " + _name + $" (Price: {_price} UAH)");
        }

        public decimal GetPrice()
        {
            return _price;
        }
    }

    class DessertBox : IDessertItem
    {
        private string _boxName;
        private List<IDessertItem> _items = new List<IDessertItem>();

        public DessertBox(string boxName)
        {
            _boxName = boxName;
        }

        public void Add(IDessertItem item)
        {
            _items.Add(item);
        }

        public void GetInformation()
        {
            Console.WriteLine($"Set: {_boxName}");
            foreach (var item in _items)
            {
                item.GetInformation();
            }
            Console.WriteLine($"Total price: {GetPrice()} UAH");
        }

        public decimal GetPrice()
        {
            decimal total = 0m;
            foreach (var item in _items)
            {
                total += item.GetPrice();
            }
            return total;
        }
    }
}