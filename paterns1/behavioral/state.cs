using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paterns1.behavioral
{
    class Order_state
    {
        private IOrderState _state;

        public Order_state()
        {
            SetState(new NewOrderState()); 
        }

        public void SetState(IOrderState state)
        {
            _state = state;
            Console.WriteLine($"\n[Status changed to '{_state.GetType().Name}']");
        }

        public void Proceed()
        {
            _state.Next(this);
        }

        public void Cancel()
        {
            _state.Cancel(this);
        }
    }

    interface IOrderState
    {
        void Next(Order_state order);
        void Cancel(Order_state order);
    }

    class NewOrderState : IOrderState
    {
        public void Next(Order_state order)
        {
            Console.WriteLine("The order has been passed on to the kitchen");
            order.SetState(new InProgressState());
        }

        public void Cancel(Order_state order)
        {
            Console.WriteLine("The order has been canceled");
            order.SetState(new CancelledState());
        }
    }

    class InProgressState : IOrderState
    {
        public void Next(Order_state order)
        {
            Console.WriteLine("The order is ready");
            order.SetState(new ReadyState());
        }

        public void Cancel(Order_state order)
        {
            Console.WriteLine("The order cannot be canceled - it is already being prepared");
        }
    }

    class ReadyState : IOrderState
    {
        public void Next(Order_state order)
        {
            Console.WriteLine("The order has been delivered to the customer.");
            order.SetState(new DeliveredState());
        }

        public void Cancel(Order_state order)
        {
            Console.WriteLine("The order is ready. Cancellation is not possible.");
        }
    }

    class DeliveredState : IOrderState
    {
        public void Next(Order_state order)
        {
            Console.WriteLine("Your order has already been delivered. No further action is required.");
        }

        public void Cancel(Order_state order)
        {
            Console.WriteLine("The order has already been delivered. It cannot be canceled");
        }
    }

    class CancelledState : IOrderState
    {
        public void Next(Order_state order)
        {
            Console.WriteLine("Order canceled. No further action will be taken.");
        }

        public void Cancel(Order_state order)
        {
            Console.WriteLine("The order has already been canceled.");
        }
    }
}