using System;

namespace paterns1.behavioral
{
    public interface IMediator
    {
        void Send(string message, IColleague sender);
    }

    public interface IColleague
    {
        void SetMediator(IMediator mediator);
        void Send(string message);
        void Receive(string message);
    }

    public class OrderMediator : IMediator
    {
        public Client Client { get; set; }
        public Waiter Waiter { get; set; }
        public Chef Chef { get; set; }

        public void Send(string message, IColleague sender)
        {
            if (sender == Client)
            {
                Waiter?.Receive("Client placed an order:" + message);
                Chef?.Receive("Waiter forwards the order: " + message);
            }
            else if (sender == Chef)
            {
                Waiter?.Receive("Chef prepared the order:" + message );
                Client?.Receive("Waiter serves the order: " + message);
            }
        }
    }

    public class Client : IColleague
    {
        private IMediator mediator;
        public void SetMediator(IMediator mediator) => this.mediator = mediator;

        public void Send(string message) => mediator.Send(message, this);
        public void Receive(string message)
        {
            Console.WriteLine($"[Client] Message received: \"{message}\"");
        }
    }

    public class Waiter : IColleague
    {
        private IMediator mediator;
        public void SetMediator(IMediator mediator) => this.mediator = mediator;

        public void Send(string message) => mediator.Send(message, this);
        public void Receive(string message)
        {
            Console.WriteLine($"[Waiter] Message received: \"{message}\"");
        }
    }

    public class Chef : IColleague
    {
        private IMediator mediator;
        public void SetMediator(IMediator mediator) => this.mediator = mediator;

        public void Send(string message) => mediator.Send(message, this);
        public void Receive(string message)
        {
            Console.WriteLine($"[Chef] Message received: \"{message}\"");
        }
    }
}
