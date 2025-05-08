using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paterns1.behavioral
{
    class Order
    {
        private List<string> _items = new List<string>();

        public void AddItem(string item)
        {
            _items.Add(item);
            Console.WriteLine($"{item} added to order");
        }

        public void ShowItems()
        {
            Console.WriteLine("Current order:");
            foreach (var item in _items)
            {
                Console.WriteLine($"- {item}");
            }
        }

        public OrderMemento Save()
        {
            return new OrderMemento(new List<string>(_items));
        }

        public void Restore(OrderMemento memento)
        {
            _items = memento.GetItems();
            Console.WriteLine("Order restored!");
        }
    }

    class OrderMemento
    {
        private readonly List<string> _items;

        public OrderMemento(List<string> items)
        {
            _items = items;
        }

        public List<string> GetItems()
        {
            return new List<string>(_items);
        }
    }

    class OrderHistory
    {
        private Stack<OrderMemento> _history = new Stack<OrderMemento>();

        public void Save(Order order)
        {
            _history.Push(order.Save());
        }

        public void Undo(Order order)
        {
            if (_history.Count > 0)
            {
                var memento = _history.Pop();
                order.Restore(memento);
            }
            else
            {
                Console.WriteLine("No previous states");
            }
        }
    }
}
