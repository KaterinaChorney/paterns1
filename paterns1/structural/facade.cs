using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paterns1.structural
{
    class DoughMaker
    {
        public void PrepareDough()
        {
            Console.WriteLine("Preparing the cake batter...");
        }
    }

    class Oven
    {
        public void Preheat()
        {
            Console.WriteLine("The oven is preheated to 180°C...");
        }

        public void Bake()
        {
            Console.WriteLine("The sponge cake is baked in the oven...");
        }
    }

    class CreamMaker
    {
        public void MakeCream()
        {
            Console.WriteLine("Whip the vanilla cream...");
        }
    }

    class CakeAssembler
    {
        public void AssembleLayers()
        {
            Console.WriteLine("The layers of sponge cake are smeared with cream and folded...");
        }
    }

    class Decorator
    {
        public void Decorate()
        {
            Console.WriteLine("The cake is being decorated...");
        }
    }

    internal class BakeryFacade
    {
        private DoughMaker _dough = new DoughMaker();
        private Oven _oven = new Oven();
        private CreamMaker _cream = new CreamMaker();
        private CakeAssembler _assembler = new CakeAssembler();
        private Decorator _decorator = new Decorator();

        public void MakeCake()
        {
            Console.WriteLine(" Starting to make the cake ");
            _dough.PrepareDough();
            _oven.Preheat();
            _oven.Bake();
            _cream.MakeCream();
            _assembler.AssembleLayers();
            _decorator.Decorate();
            Console.WriteLine(" The cake is ready to serve! ");
        }
    }
}
