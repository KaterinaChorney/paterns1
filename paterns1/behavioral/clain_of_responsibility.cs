using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paterns1.behavioral
{
    abstract class OrderHandler
    {
        protected OrderHandler nextHandler;

        public void SetNext(OrderHandler handler)
        {
            nextHandler = handler;
        }
        public abstract void HandleOrder(string order);
    }

    class WaiterHandler : OrderHandler
    {
        public override void HandleOrder(string order)
        {
            if (order.ToLower().Contains("tea") || order.ToLower().Contains("coffee"))
            {
                Console.WriteLine($"Waiter serves the order himself: {order}");
            }
            else
            {
                Console.WriteLine("The waiter cannot fulfill the order himself, he passes it on to the kitchen...");
                nextHandler?.HandleOrder(order);
            }
        }
    }

    class ChefHandler : OrderHandler
    {
        public override void HandleOrder(string order)
        {
            if (order.ToLower().Contains("cupcake") || order.ToLower().Contains("eclair") || order.ToLower().Contains("croissant"))
            {
                Console.WriteLine($"The chef prepares the order himself: {order}");
            }
            else
            {
                Console.WriteLine("The cook cannot fulfill the order on his own, he passes it on to the manager...");
                nextHandler?.HandleOrder(order);
            }
        }
    }

    class ManagerHandler : OrderHandler
    {
        public override void HandleOrder(string order)
        {
            Console.WriteLine($"The manager resolves the issue with the order: {order}");
        }
    }
}