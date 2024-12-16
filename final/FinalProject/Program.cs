using System;
using System.Data;


class Program
{




    static public void BuyOneOfAll(List<Item> items, Tavern tavern)
    {
        foreach(Item item in items)
        {
            tavern.AddItemToInventory(item);
        }
    }

    static public Person CreateRandomPerson(List<Item>items, Scaling scale, Tavern tavern)
    {
        Random random = new Random();
        int personType = random.Next(5);
        List<string> medievalNames = new List<string>
        {
            "Aethelred",
            "Beatrice",
            "Cedric",
            "Eleanor",
            "Godfrey",
            "Isolde",
            "Leofric",
            "Matilda",
            "Rowena",
            "Wulfric"
        };
        string name = medievalNames[random.Next(medievalNames.Count)];
        int timeBase = random.Next(20, 30);
        int easiness = random.Next(1, 11);
        //easiness = 1;
        Item item = items[random.Next(items.Count)];
        if(personType == 0)
        {
            Inspector randomInspector = new Inspector(name, 2, easiness, timeBase, item);
            randomInspector.SetScore(tavern.GetScore());
            randomInspector.SetScaler(scale);
            return randomInspector;
        }
        else
        {
            int moneyBase = random.Next(1,4);
            Customer randomCustomer = new Customer(name, 1, easiness, timeBase, moneyBase, item);
            randomCustomer.SetScore(tavern.GetScore());
            randomCustomer.SetScaler(scale);
            return randomCustomer;
        }



    }

    static public void ServeCustomer(Person person, Tavern tavern)
    {
        Dictionary<Item, int> inventory = tavern.GetInventory();
        List<Item> keys = new List<Item>();
        foreach(Item item in inventory.Keys)
        {
            if(inventory[item] > 0)
            {
                keys.Add(item);
            }
            
        }
        Console.WriteLine($"Time Base: {person.GetTimeBase()}");
        person.DisplayPersonIntro();
        person.StartTimer();
        tavern.DisplayPositiveInventory();
        Console.Write("Please enter the number associated with the item to serve: ");
        int input = int.Parse(Console.ReadLine());
        person.EndTimer();
        Item itemToServe = keys[input-1];
        tavern.SubtractFromInventory(itemToServe);
        person.Serve(itemToServe);
        person.CheckForSpeedyService();
        if(itemToServe.GetForm() == "Drink")
        {
            tavern.incrementDrinksServed();
        }
        else
        {
            tavern.incrementFoodServed();
        }
        if(person.GetServedCorrectly() && person.GetServedQuickly())
        {
            int beforeActionBalance = tavern.GetMoney();
            person.Action(tavern);
            if(person.GetRole() == "Customer")
            {
                int postActionBalance = tavern.GetMoney();
                int moneyGiven = postActionBalance-beforeActionBalance;
                Console.WriteLine($"{person.GetName()} paid ${moneyGiven} for your service.");
            }
            else
            {
                Console.WriteLine($"You passed {person.GetName()}'s inspection.");
            }
            
        }
        else
        {
            int beforeActionBalance = tavern.GetMoney();
            person.PityAction(tavern);
            if(person.GetRole() == "Customer")
            {
                int postActionBalance = tavern.GetMoney();
                int moneyGiven = postActionBalance-beforeActionBalance;
                Console.WriteLine($"{person.GetName()} paid ${moneyGiven} for your service.");
            }
            else
            {
                Console.WriteLine($"You failed {person.GetName()}'s inspection, and your tavern license has been revoked.");
            }
            //Console.WriteLine("Unsucessfuly Served");
        }

    }

    static void CountDown(int duration)
    {
        for(int i = duration; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    static void InventoryOrder(Tavern tavern, List<Item> items)
    {
        int CostOfAll = 0;
        foreach(Item item in items)
        {
            CostOfAll += item.GetCost();
        }

        bool done = false;
        while(!done)
        {
            Console.WriteLine("Pages:");
            Console.WriteLine("1. View Inventory\n2. Order Item\n3. View Finances\n4. Start Next Day");
            Console.Write("Enter the page you want to go to: ");
            int input = int.Parse(Console.ReadLine());
            switch(input)
            {
                case 1:
                    tavern.DisplayInventory();
                    break;
                case 2:
                    Console.WriteLine($"Money Available: {tavern.GetMoney()}");
                    Console.WriteLine("Items available:");
                    int i = 0;
                    for(i = 0; i < items.Count; i++)
                    {
                        Console.WriteLine($"{i+1}. {items[i]} ${items[i].GetCost()}");
                    }
                    Console.WriteLine($"{i+1} Buy one of all ${CostOfAll}");
                    Console.Write("Item to order: ");
                    int input2 = int.Parse(Console.ReadLine());
                    if(input2 == (i+1))
                    {
                        if(tavern.GetMoney() < CostOfAll)
                        {
                            Console.WriteLine("You cant afford that, try again.");
                        }
                        else
                        {
                            BuyOneOfAll(items, tavern);
                        }
                    }
                    else
                    {
                        Item itemToOrder = items[input2-1];
                        Console.Write("How many items to order: ");
                        int quantity = int.Parse(Console.ReadLine());
                        if(itemToOrder.GetCost()*quantity > tavern.GetMoney())
                        {
                            Console.WriteLine("You cant afford that, try again.");
                        }
                        else
                        {
                            for(int j = 0; j < quantity; j++)
                            {
                                tavern.AddItemToInventory(itemToOrder);
                            }
                        }
                    }
                    break;
                case 3:
                    tavern.DisplayFinances();
                    break;
                case 4:
                    if(tavern.GetInventory().Count > 0)
                    {
                        done = true;
                    }
                    else
                    {
                        Console.WriteLine("Please buy some foodstuffs to sell");
                    }
                    break;
            }
        }
    }


    static void Main(string[] args)
    {
        List<Item> items = new List<Item>
        {
            new Food("Pottage", 2),
            new Food("Bread", 1),
            new Drink("Ale", 2),
            new Food("Salted Meat", 3),
            new Food("Cheese", 3),
            new Food("Herring", 2),
            new Drink("Mead", 3),
            new Drink("Wine", 2),
            new Drink("Cider", 1),
            new Drink("Wassail", 2),
        };
        Till till = new Till();
        Random random = new Random();
        int startingMoney = random.Next(20, 30);
        Tavern tavern = new Tavern(till);
        tavern.AddMoney(startingMoney);
        //BuyOneOfAll(items, tavern);
        Scaling scaling = new Scaling();
        int peopleToServeBeforeBreak = 0;
        int peopleServed = 0;
        while(!tavern.GetFailure())
        {
            if(peopleServed == peopleToServeBeforeBreak)
            {
                tavern.incrementDaysSurvived();
                InventoryOrder(tavern, items);
                peopleServed = 0;
                peopleToServeBeforeBreak = random.Next(1,5 + (int)MathF.Ceiling(tavern.GetScore()/2));

            }
            
            List<Person> persons = new List<Person>();
            persons.Add(CreateRandomPerson(items, scaling, tavern));


            ServeCustomer(persons[0], tavern);
            peopleServed++;


        }
        tavern.DisplayStats();
        tavern.DisplayFinances();
        
    }
}