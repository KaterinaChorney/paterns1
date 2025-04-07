using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paterns1.structural
{
    interface IOrderAccess
    {
        void ShowOrder();
    }

    class RealOrder : IOrderAccess
    {
        public void ShowOrder()
        {
            Console.WriteLine("Your regular order: Tiramisu cake and coffee ");
        }
    }

    class OrderProxy : IOrderAccess
    {
        private RealOrder _realOrder;
        private string _clientName;

        public OrderProxy(string clientName)
        {
            _clientName = clientName;
        }

        public void ShowOrder()
        {
            if (IsRegularClient())
            {
                Console.WriteLine($"Client {_clientName}, it's nice to see you again!");
                _realOrder = new RealOrder();
                _realOrder.ShowOrder();
            }
            else
            {
                Console.WriteLine($"Client {_clientName} is not permanent");
            }
        }

        private bool IsRegularClient()
        {
            var regulars = new List<string> { "Kate", "Sasha", "Liza" };
            return regulars.Contains(_clientName);
        }
    }
}
