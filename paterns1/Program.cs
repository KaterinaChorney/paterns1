using System;
using System.Net.NetworkInformation;
using paterns1.behavioral;
using paterns1.creational;
using paterns1.structural;
class Program
{
    static void Main(string[] args)
    {
        //creational

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
        paterns1.creational.Bakery cakeFactory = new CakeBakery();
        Pastry cake = cakeFactory.CreatePastry();
        cake.Bake();
        paterns1.creational.Bakery croissantFactory = new CroissantBakery();
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
        paterns1.creational.Cake chocolateCake = baker.MakeCake(chocolateBuilder);
        chocolateCake.Show();
        CakeBuilder vanillaBuilder = new VanillaCakeBuilder();
        paterns1.creational.Cake vanillaCake = baker.MakeCake(vanillaBuilder);
        vanillaCake.Show();

        Console.WriteLine("\n      Prototype Pattern      ");
        paterns1.creational.Cookies originalCookies = new paterns1.creational.Cookies("Chocolate cookies", "2 layers", "caramel", "nuts");
        originalCookies.Show();
        paterns1.creational.Cookies clonedCookies = (paterns1.creational.Cookies)originalCookies.Clone();
        clonedCookies.Name = "Copy of chocolate cookies";
        clonedCookies.Show();

        //structural

        Console.WriteLine("\n      Adapter Pattern      ");
        paterns1.structural.Kitchen kitchen = new paterns1.structural.Kitchen();
        ICustomerOrder waiter = new paterns1.structural.Waiter(kitchen);
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
        paterns1.structural.IDessert sweetcake = new SpongeCake();
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
        var chocoType = factory.GetDonutType("chocolate", "nut paste");
        var berryType1 = factory.GetDonutType("strawberry", "strawberry jam");
        var berryType2 = factory.GetDonutType("bilberry", "bilberry jam");
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

        //behavioral

        Console.WriteLine("\n    Clain of responsibility    ");
        var waiter_clain = new WaiterHandler();
        var chef = new ChefHandler();
        var manager = new ManagerHandler();
        waiter_clain.SetNext(chef);
        chef.SetNext(manager);
        waiter_clain.HandleOrder("coffee");
        Console.WriteLine();
        waiter_clain.HandleOrder("eclair with vanilla cream");
        Console.WriteLine();
        waiter_clain.HandleOrder("5-tier wedding cake with delivery");


        Console.WriteLine("\n   Command    ");
        paterns1.behavioral.Kitchen kitchen_command = new paterns1.behavioral.Kitchen();
        paterns1.behavioral.Waiter_command waiter_command = new paterns1.behavioral.Waiter_command();
        ICommand order1 = new CakeOrderCommand(kitchen_command, "Chocolate");
        ICommand order2 = new CroissantOrderCommand(kitchen_command, "Vanilla cream");
        waiter_command.TakeOrder(order1);
        waiter_command.TakeOrder(order2);
        waiter_command.PlaceOrders();

        Console.WriteLine("\n   Iterator    ");
        DessertMenuCustom menu = new DessertMenuCustom();
        menu.AddDessert(new Dessert("Napoleon", 225));
        menu.AddDessert(new Dessert("Tiramisu", 270));
        menu.AddDessert(new Dessert("Croissant with chocolate", 75));
        menu.AddDessert(new Dessert("Dubai cheesecake", 265));
        menu.AddDessert(new Dessert("Brownie cake", 110));
        menu.AddDessert(new Dessert("Eclair with coconut filling", 90));
        IDessertIterator iterator = menu.CreateIterator();
        Console.WriteLine("Dessert menu:");
        while (iterator.HasNext())
        {
            Dessert d = iterator.Next();
            d.Display();
        }

        Console.WriteLine("\n   Mediator    ");
        var mediator = new OrderMediator();
        var client = new Client();
        var waiter_mediator = new paterns1.behavioral.Waiter();
        var chef_mediator = new Chef();
        client.SetMediator(mediator);
        waiter_mediator.SetMediator(mediator);
        chef_mediator.SetMediator(mediator);
        mediator.Client = client;
        mediator.Waiter = waiter_mediator;
        mediator.Chef = chef_mediator;
        client.Send("'Raffaello cake'");
        chef_mediator.Send("Raffaello cake is ready!");

        Console.WriteLine("\n   Memento    ");
        Order order = new Order();
        OrderHistory history = new OrderHistory();
        order.AddItem("Lemon tart");
        order.AddItem("Croissant with coconut");
        history.Save(order);
        order.AddItem("Profitrol");
        order.ShowItems();
        Console.WriteLine(" X Rollback order X ");
        history.Undo(order);
        order.ShowItems();

        Console.WriteLine("\n   Observer    ");
        paterns1.behavioral.Bakery bakery_observer = new paterns1.behavioral.Bakery();
        ICustomer Kate = new RegularCustomer("Kate");
        ICustomer Ivan = new RegularCustomer("Ivan");
        bakery_observer.Subscribe(Kate);
        bakery_observer.Subscribe(Ivan);
        bakery_observer.AddNewDessert("Raspberry macaroon");
        bakery_observer.AddNewDessert("Blueberry cheesecake");
        bakery_observer.Unsubscribe(Ivan);
        bakery_observer.AddNewDessert("Eclair with pistachio cream");

        Console.WriteLine("\n   State    ");
        Order_state order_state = new Order_state();
        order_state.Proceed(); 
        order_state.Proceed();
        order_state.Cancel();
        order_state.Proceed();
        order_state.Proceed();

        Console.WriteLine("\n   Strategy    ");
        OrderContext context = new OrderContext();
        context.SetStrategy(new StandardDelivery());
        context.ProcessOrder("Strawberry cake");
        context.SetStrategy(new ExpressDelivery());
        context.ProcessOrder("Birthday cake");
        context.SetStrategy(new Pickup());
        context.ProcessOrder("Wedding cake");

        Console.WriteLine("\n   Template metod    ");
        Console.WriteLine("The cake is being prepared:");
        DessertTemplate cake_observer = new paterns1.behavioral.Cake();
        cake_observer.MakeDessert();
        Console.WriteLine("The croissant is being prepared:");
        DessertTemplate croissant_observer = new paterns1.behavioral.Croissant();
        croissant_observer.MakeDessert();
        Console.WriteLine("The cookies is being prepared:");
        DessertTemplate cookies_observer = new paterns1.behavioral.Cookies();
        cookies_observer.MakeDessert();

        Console.WriteLine("\n   Visitor    ");
        List<paterns1.behavioral.IDessert> desserts = new List<paterns1.behavioral.IDessert>
            {
                   new paterns1.behavioral.Cupcake(),
                    new paterns1.behavioral.Eclair()
            };
        Console.WriteLine("Description:");
        var descriptionVisitor = new DescriptionVisitor();
        foreach (var dessert in desserts)
            dessert.Accept(descriptionVisitor);
        Console.WriteLine("Calorie content:");
        var calorieVisitor = new CalorieCounterVisitor();
        foreach (var dessert in desserts)
            dessert.Accept(calorieVisitor);
    }
}