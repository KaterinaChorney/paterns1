using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paterns1.behavioral
{
    interface IMediator
    {
        void Send(string message, Participant sender);
        void Register(Participant participant);
    }

    abstract class Participant
    {
        protected IMediator mediator;
        public string Name { get; }

        public Participant(string name)
        {
            Name = name;
        }

        public void SetMediator(IMediator mediator)
        {
            this.mediator = mediator;
            mediator.Register(this);
        }

        public abstract void Receive(string message);
    }

    class Client : Participant
    {
        public Client(string name) : base(name) { }

        public void MakeOrder(string order)
        {
            Console.WriteLine($"{Name} (Клієнт): Я хочу {order}");
            mediator.Send(order, this);
        }

        public override void Receive(string message)
        {
            Console.WriteLine($"{Name} (Клієнт) отримує: {message}");
        }
    }

    class Waiter : Participant
    {
        public Waiter(string name) : base(name) { }

        public override void Receive(string message)
        {
            Console.WriteLine($"{Name} (Офіціант) отримує замовлення: {message}");
            mediator.Send($"Передаю на кухню: {message}", this);
        }
    }

    class Chef : Participant
    {
        public Chef(string name) : base(name) { }

        public override void Receive(string message)
        {
            Console.WriteLine($"{Name} (Кухар) отримує: {message}");
            Console.WriteLine($"{Name} (Кухар): Готую {message.Replace("Передаю на кухню: ", "")}");
            mediator.Send($"Замовлення '{message.Replace("Передаю на кухню: ", "")}' готове!", this);
        }
    }

    class OrderMediator : IMediator
    {
        private List<Participant> participants = new List<Participant>();

        public void Register(Participant participant)
        {
            if (!participants.Contains(participant))
            {
                participants.Add(participant);
            }
        }

        public void Send(string message, Participant sender)
        {
            foreach (var participant in participants)
            {
                if (participant != sender)
                {
                    participant.Receive(message);
                }
            }
        }
    }
}