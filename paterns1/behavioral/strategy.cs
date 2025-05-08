using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paterns1.behavioral
{
    interface IDeliveryStrategy
    {
        void Deliver(string order);
    }

    class StandardDelivery : IDeliveryStrategy
    {
        public void Deliver(string order)
        {
            Console.WriteLine($"Order \'{order}\' will be delivered via standard delivery (2-3 days)");
        }
    }

    class ExpressDelivery : IDeliveryStrategy
    {
        public void Deliver(string order)
        {
            Console.WriteLine($"Order \'{order}\' will be delivered via express delivery (today)");
        }
    }

    class Pickup : IDeliveryStrategy
    {
        public void Deliver(string order)
        {
            Console.WriteLine($"Order \'{order}\' is available for pickup");
        }
    }

    class OrderContext
    {
        private IDeliveryStrategy _strategy;

        public void SetStrategy(IDeliveryStrategy strategy)
        {
            _strategy = strategy;
        }

        public void ProcessOrder(string order)
        {
            _strategy.Deliver(order);
        }
    }
}