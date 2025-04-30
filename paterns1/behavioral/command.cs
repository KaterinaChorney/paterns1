using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paterns1.behavioral
{
    interface ICommand
    {
        void Execute();
    }

    class Kitchen
    {
        public void MakeCake(string type)
        {
            Console.WriteLine($"Kitchen: Cooking a cake {type}");
        }

        public void MakeCroissant(string filling)
        {
            Console.WriteLine($"Kitchen: We are making a croissant with {filling}");
        }
    }

    class CakeOrderCommand : ICommand
    {
        private Kitchen _kitchen;
        private string _cakeType;

        public CakeOrderCommand(Kitchen kitchen, string cakeType)
        {
            _kitchen = kitchen;
            _cakeType = cakeType;
        }

        public void Execute()
        {
            _kitchen.MakeCake(_cakeType);
        }
    }

    class CroissantOrderCommand : ICommand
    {
        private Kitchen _kitchen;
        private string _filling;

        public CroissantOrderCommand(Kitchen kitchen, string filling)
        {
            _kitchen = kitchen;
            _filling = filling;
        }

        public void Execute()
        {
            _kitchen.MakeCroissant(_filling);
        }
    }

    class Waiter
    {
        private List<ICommand> _orders = new List<ICommand>();

        public void TakeOrder(ICommand command)
        {
            _orders.Add(command);
            Console.WriteLine("The waiter took the order.");
        }

        public void PlaceOrders()
        {
            Console.WriteLine("\nThe waiter passes the order to the kitchen:");
            foreach (var command in _orders)
            {
                command.Execute();
            }
            _orders.Clear();
        }
    }
}