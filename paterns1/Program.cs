using System;
using paterns1.creational;
using paterns1.structural;

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

        Console.WriteLine("\n      Adapter Pattern      ");
        Kitchen kitchen = new Kitchen();
        ICustomerOrder waiter = new Waiter(kitchen);
        waiter.PlaceOrder("Napoleon cake");
        waiter.PlaceOrder("Eclair with custard");

        Console.WriteLine("\n      Bridge Pattern      ");
        Baking TiramisuCake = new TiramisuCake(new CakeRecipe());
        Baking roll = new CinnamonRoll(new RollRecipe());
        TiramisuCake.Make();
        roll.Make();

        Console.WriteLine("\n    Composite     ");
        IDessertItem cupcake = new SingleDessert("Сhocolate cupcake", 90m);
        IDessertItem eclair = new SingleDessert("Eclair with vanilla cream", 70m);
        IDessertItem croissantItem = new SingleDessert("Croissant with jam", 50m);
        DessertBox box = new DessertBox("Sweet set");
        box.Add(cupcake);
        box.Add(eclair);
        box.Add(croissantItem);
        box.GetInformation();

        Console.WriteLine("\n    Decorator    ");
        IDessert sweetcake = new SpongeCake();
        Console.WriteLine($"{sweetcake.GetDescription()} - {sweetcake.GetPrice()}UAH");
        sweetcake = new IcingDecorator(sweetcake);
        sweetcake = new SprinklesDecorator(sweetcake);
        sweetcake = new TextDecorator(sweetcake);
        Console.WriteLine($"{sweetcake.GetDescription()} - {sweetcake.GetPrice()}UAH");
        Console.WriteLine();

        Console.WriteLine("\n    Facade    ");
        BakeryFacade bakery = new BakeryFacade();
        bakery.MakeCake();

        Console.WriteLine("\n    Flyweight    ");
        DonutFactory factory = new DonutFactory();
        var chocoType = factory.GetDonutType( "chocolate", "nut paste");
        var berryType1 = factory.GetDonutType("strawberry", "strawberry jam");
        var berryType2= factory.GetDonutType("bilberry", "bilberry jam");
        var chocoTypeAgain = factory.GetDonutType("chocolate", "nut paste");
        var d1 = new Donut(chocoType, "showcase 1");
        var d2 = new Donut(berryType1, "showcase 2");
        var d3 = new Donut(berryType2, "showcase 3");
        var d4 = new Donut(chocoTypeAgain, "cold room");
        d1.Display();
        d2.Display();
        d3.Display();
        d4.Display();

        Console.WriteLine("\n    Proxy    ");
        IOrderAccess client1 = new OrderProxy("Kate");
        client1.ShowOrder();
        IOrderAccess client2 = new OrderProxy("Ivan");
        client2.ShowOrder();

    }
}