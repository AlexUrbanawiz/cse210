using System;
using System.Data;



/*
Tavern Keep Sim

Classes
Item-Base
Attributes
    Cost
    Name
    

Food : Item


Drink : Item


Till
Keeps track of money/purchase histroy
Attribute
    int currentMoney
    int lifetimeEarnings
    int expenses
    int profit
Method
    Display Current Money
    Display Lifetime Earnings
    Calculate Profit
    DisplayProfit
    AddExpense
    Subtract Money
    AddMoney

Tavern
Keeps track of inventory, keeps track of customers served

Attributes:
    Dictionary<Item, int> inventroy. The int is the amount of this item available
    int customers served
    int inspectors served
    int daysLasted



Person-Base
Name
Points for serving
Role
Method Action(abstract)

Customer : Person
Favorite Food/Drink
Money given for service
How forgiving they are


Inspector : Person
No money for service
If you dont serve them in time you lose



Scaling class
Keeps track of points, and calculates everything needed for scaling purposes


The game loop is as follows:
A random customer is generated, with a small chance to spawn an inspector that grows as your score increases. When a customer approaches you have to serve them. If you take too long to serve them, or serve them the wrong food/drink then you get a deduction. 
A deduction with customers only reduces the money and score reccived for serving them, but if you take too long or serve an inspector the wrong item then you get a strike. Three strikes and youre out.
You get a break every certain amount of customers to order food/drink, and to mentally prepare for the next day.
As you progress the period between breaks grows larger, so you have to plan further in advance

Need to find a good scaling formula, for the right mix of hard and easy(or just make a hard or easy mode where the only thing that changes is the scaling formula)
*/
class Program
{

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
        easiness = 1;
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
            keys.Add(item);
        }

        Console.WriteLine(person.DisplayPersonIntro());
        person.StartTimer();
        tavern.DisplayInventory();
        Console.Write("Please enter the number associated with the item to serve: ");
        int input = int.Parse(Console.ReadLine());
        person.EndTimer();
        Item itemToServe = keys[input-1];
        tavern.SubtractFromInventory(itemToServe);
        person.Serve(itemToServe);
        person.CheckForSpeedyService();
        if(person.GetServedCorrectly() || person.GetServedQuickly())
        {
            person.Action(tavern);
            Console.WriteLine("Sucessfuly Served");
        }
        else
        {
            person.PityAction(tavern);
            Console.WriteLine("Unsucessfuly Served");
        }

    }

    static void InventoryOrder(Tavern tavern, List<Item> items)
    {
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
                    for(int i = 0; i < items.Count; i++)
                    {
                        Console.WriteLine($"{i+1}. {items[i]} ${items[i].GetCost()}");
                    }
                    Console.Write("Item to order: ");
                    int input2 = int.Parse(Console.ReadLine());
                    Item itemToOrder = items[input2-1];
                    Console.Write("How many items to order: ");
                    int quantity = int.Parse(Console.ReadLine());
                    for(int j = 0; j < quantity; j++)
                    {
                        tavern.AddItemToInventory(itemToOrder);
                    }
                    break;
                case 3:
                    tavern.DisplayFinances();
                    break;
                case 4:
                    done = true;
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
        int startingMoney = random.Next(16, 30);
        Tavern tavern = new Tavern(till);
        tavern.AddMoney(startingMoney);
        foreach(Item item in items)
        {
            tavern.AddItemToInventory(item);
        }
        Scaling scaling = new Scaling();
        while(!tavern.GetFailure())
        {
            InventoryOrder(tavern, items);
            List<Person> persons = new List<Person>();
            persons.Add(CreateRandomPerson(items, scaling, tavern));


            ServeCustomer(persons[0], tavern);

        }
        
    }
}