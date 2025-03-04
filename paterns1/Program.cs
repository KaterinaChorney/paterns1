using System;
using paterns1.creational;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("      Singleton Pattern      ");
        BakeryManager manager1 = BakeryManager.GetInstance();
        BakeryManager manager2 = BakeryManager.GetInstance();
        manager1.ManageBakery();
        if (manager1 == manager2)
        {
            Console.WriteLine("Singleton works: both variables contain the same instance.");
        }
        else
        {
            Console.WriteLine("Singleton does not work: variables contain different instances.");
        }
        Console.WriteLine("\n      Factory Method Pattern      ");
        Bakery cakeFactory = new CakeBakery();
        Pastry cake = cakeFactory.CreatePastry();
        cake.Bake();
        Bakery croissantFactory = new CroissantBakery();
        Pastry croissant = croissantFactory.CreatePastry();
        croissant.Bake();
        Console.WriteLine("\n      Abstract Factory Pattern      ");
        IBakeryFactory chocolateFactory = new ChocolateBakeryFactory();
        Pie chocolatePie = chocolateFactory.CreatePie();
        Drink coffee = chocolateFactory.CreateDrink();
        chocolatePie.Bake();
        coffee.Prepare();
        IBakeryFactory vanillaFactory = new VanillaBakeryFactory();
        Pie vanillaPie = vanillaFactory.CreatePie();
        Drink tea = vanillaFactory.CreateDrink();
        vanillaPie.Bake();
        tea.Prepare();
        Console.WriteLine("\n      Builder Pattern      ");
        Baker baker = new Baker();
        CakeBuilder chocolateBuilder = new ChocolateCakeBuilder();
        Cake chocolateCake = baker.MakeCake(chocolateBuilder);
        chocolateCake.Show();
        CakeBuilder vanillaBuilder = new VanillaCakeBuilder();
        Cake vanillaCake = baker.MakeCake(vanillaBuilder);
        vanillaCake.Show();
        Console.WriteLine("\n      Prototype Pattern      ");
        Cookies originalCookies = new Cookies("Chocolate cookies", "2 layers", "caramel", "nuts");
        originalCookies.Show();
        Cookies clonedCookies = (Cookies)originalCookies.Clone();
        clonedCookies.Name = "Copy of chocolate cookies";
        clonedCookies.Show();
    }
}