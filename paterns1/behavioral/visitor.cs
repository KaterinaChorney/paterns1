using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paterns1.behavioral
{
    interface IDessert
    {
        void Accept(IDessertVisitor visitor);
    }

    class Cupcake : IDessert
    {
        public string Filling { get; } = "strawberry jam";
        public int Calories { get; } = 305;

        public void Accept(IDessertVisitor visitor)
        {
            visitor.VisitCupcake(this);
        }
    }

    class Eclair : IDessert
    {
        public string Cream { get; } = "custard";
        public int Calories { get; } = 262;

        public void Accept(IDessertVisitor visitor)
        {
            visitor.VisitEclair(this);
        }
    }

    interface IDessertVisitor
    {
        void VisitCupcake(Cupcake cupcake);
        void VisitEclair(Eclair eclair);
    }

    class DescriptionVisitor : IDessertVisitor
    {
        public void VisitCupcake(Cupcake cupcake)
        {
            Console.WriteLine($"Cupcake with {cupcake.Filling} filling");
        }

        public void VisitEclair(Eclair eclair)
        {
            Console.WriteLine($"Eclair with {eclair.Cream} cream");
        }
    }

    class CalorieCounterVisitor : IDessertVisitor
    {
        public void VisitCupcake(Cupcake cupcake)
        {
            Console.WriteLine($"An cupcake contains {cupcake.Calories} calories");
        }

        public void VisitEclair(Eclair eclair)
        {
            Console.WriteLine($"An eclair contains {eclair.Calories} calories");
        }
    }
}
