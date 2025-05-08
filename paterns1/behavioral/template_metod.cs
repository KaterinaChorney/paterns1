using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paterns1.behavioral
{
    abstract class DessertTemplate
    {
        public void MakeDessert()
        {
            PrepareDough();
            AddFilling();
            Bake();
            Decorate();
            Serve();
        }

        protected abstract void PrepareDough();
        protected abstract void AddFilling();
        protected abstract void Bake();
        protected virtual void Decorate()
        {
            Console.WriteLine("The dessert is decorated standardly....");
        }

        protected void Serve()
        {
            Console.WriteLine("Dessert is served to the customer.\n");
        }
    }

    class Cake : DessertTemplate
    {
        protected override void PrepareDough()
        {
            Console.WriteLine("Preparing sponge cake batter...");
        }

        protected override void AddFilling()
        {
            Console.WriteLine("Add chocolate cream...");
        }

        protected override void Bake()
        {
            Console.WriteLine("Bake the cake at 180°C for 30 minutes...");
        }

        protected override void Decorate()
        {
            Console.WriteLine("Decorate the cake with chocolate icing and berries.");
        }
    }

    class Croissant : DessertTemplate
    {
        protected override void PrepareDough()
        {
            Console.WriteLine("Preparing puff pastry for croissants...");
        }

        protected override void AddFilling()
        {
            Console.WriteLine("Add the berry filling...");
        }

        protected override void Bake()
        {
            Console.WriteLine("Bake the croissant at 200°C for 20 minutes...");
        }
    }

    class Cookies: DessertTemplate
    {
        protected override void PrepareDough()
        {
            Console.WriteLine("Preparing cookie dough...");
        }

        protected override void AddFilling()
        {
            Console.WriteLine("Add chocolate chips...");
        }

        protected override void Bake()
        {
            Console.WriteLine("Bake the cookies at 180°C for 20 minutes...");
        }
    }
}