using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paterns1.structural
{
    public interface IDessert
    {
        string GetDescription();
        decimal GetPrice();
    }

    public class SpongeCake : IDessert
    {
        public string GetDescription() => "Sponge Cake";
        public decimal GetPrice() => 200m;
    }

    public abstract class DessertDecorator : IDessert
    {
        protected IDessert _dessert;

        protected DessertDecorator(IDessert dessert)
        {
            _dessert = dessert;
        }

        public virtual string GetDescription() => _dessert.GetDescription();
        public virtual decimal GetPrice() => _dessert.GetPrice();
    }

    public class IcingDecorator : DessertDecorator
    {
        public IcingDecorator(IDessert dessert) : base(dessert) { }

        public override string GetDescription() => _dessert.GetDescription() + " + Icing";
        public override decimal GetPrice() => _dessert.GetPrice() + 20m;
    }

    public class SprinklesDecorator : DessertDecorator
    {
        public SprinklesDecorator(IDessert dessert) : base(dessert) { }

        public override string GetDescription() => _dessert.GetDescription() + " + Sprinkles";
        public override decimal GetPrice() => _dessert.GetPrice() + 30m;
    }
    public class TextDecorator : DessertDecorator
    {
        public TextDecorator(IDessert dessert) : base(dessert) { }

        public override string GetDescription() => _dessert.GetDescription() + " + Custom Text";
        public override decimal GetPrice() => _dessert.GetPrice() + 50m;
    }
}