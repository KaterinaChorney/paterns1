using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paterns1.structural
{
    interface ICustomerOrder
    {
        void PlaceOrder(string dessert);
    }

    class Kitchen
    {
        public void PrepareDessert(string dessert)
        {
            Console.WriteLine($"{dessert} is being prepared...");
        }
    }

    class Waiter : ICustomerOrder
    {
        private readonly Kitchen _kitchen;

        public Waiter(Kitchen kitchen)
        {
            _kitchen = kitchen;
        }

        public void PlaceOrder(string dessert)
        {
            Console.WriteLine($"Waiter passes order from customer to kitchen: {dessert}");
            _kitchen.PrepareDessert(dessert);
        }
    }
}