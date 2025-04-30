using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paterns1.behavioral
{
    using System;
    using System.Collections.Generic;

    // Originator — клас, стан якого ми хочемо зберігати
    class Order
    {
        private List<string> _items = new List<string>();

        public void AddItem(string item)
        {
            _items.Add(item);
            Console.WriteLine($"Додано до замовлення: {item}");
        }

        public void ShowItems()
        {
            Console.WriteLine("Поточне замовлення:");
            foreach (var item in _items)
            {
                Console.WriteLine($"- {item}");
            }
        }

        // Створює знімок
        public OrderMemento Save()
        {
            return new OrderMemento(new List<string>(_items));
        }

        // Відновлює стан із знімка
        public void Restore(OrderMemento memento)
        {
            _items = memento.GetItems();
            Console.WriteLine("Замовлення відновлено.");
        }
    }

    // Memento — зберігає стан
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

    // Caretaker — зберігає знімки
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
                Console.WriteLine("Немає попередніх станів.");
            }
        }
    }

    // Тестування
    class Program
    {
        static void Main()
        {
            Order order = new Order();
            OrderHistory history = new OrderHistory();

            order.AddItem("Торт Наполеон");
            order.AddItem("Круасан з мигдалем");
            history.Save(order); // зберегли стан

            order.AddItem("Тістечко Еклер");
            order.ShowItems();

            Console.WriteLine("\n— Відкат замовлення —");
            history.Undo(order); // відновлюємо попередній стан
            order.ShowItems();
        }
    }

}
