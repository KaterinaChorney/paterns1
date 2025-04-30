using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paterns1.behavioral
{
    interface ICustomer
    {
        void Update(string dessertName);
    }

    interface IBakeryNotifier
    {
        void Subscribe(ICustomer customer);
        void Unsubscribe(ICustomer customer);
        void Notify(string dessertName);
    }

    class Bakery : IBakeryNotifier
    {
        private List<ICustomer> _customers = new List<ICustomer>();

        public void Subscribe(ICustomer customer)
        {
            _customers.Add(customer);
        }

        public void Unsubscribe(ICustomer customer)
        {
            _customers.Remove(customer);
        }

        public void Notify(string dessertName)
        {
            foreach (var customer in _customers)
            {
                customer.Update(dessertName);
            }
        }

        public void AddNewDessert(string name)
        {
            Console.WriteLine($"[Bakery] New dessert: {name}!");
            Notify(name);
        }
    }

    class RegularCustomer : ICustomer
    {
        private string _name;

        public RegularCustomer(string name)
        {
            _name = name;
        }

        public void Update(string dessertName)
        {
            Console.WriteLine($"{_name} received a notification about the new product: {dessertName}");
        }
    }
}