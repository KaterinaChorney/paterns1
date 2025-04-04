using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paterns1.structural
{
    interface IRecipeImplementation
    {
        void Cook(string name);
    }
    class CakeRecipe : IRecipeImplementation
    {
        public void Cook(string name)
        {
            Console.WriteLine($"Preparing a cake: {name}");
        }
    }
    class RollRecipe : IRecipeImplementation
    {
        public void Cook(string name)
        {
            Console.WriteLine($"Preparing a roll: {name}");
        }
    }

    abstract class Baking
    {
        protected IRecipeImplementation recipe;

        public Baking(IRecipeImplementation recipe)
        {
            this.recipe = recipe;
        }

        public abstract void Make();
    }

    class TiramisuCake : Baking
    {
        public TiramisuCake(IRecipeImplementation recipe) : base(recipe) { }

        public override void Make()
        {
            recipe.Cook(" Made of ladyfinger pastries (savoiardi) dipped in coffee and frosted with fluffy mascarpone cream and topped with a dusting of cocoa powder.");
        }
    }

     class CinnamonRoll : Baking
    {
        public CinnamonRoll(IRecipeImplementation recipe) : base(recipe) { }

        public override void Make()
        {
            recipe.Cook("Made from a rolled sheet of dough sprinkled with a mixture of cinnamon and sugar and covered with a cream cheese frosting.");
        }
    }

}