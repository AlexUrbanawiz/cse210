class Tavern
{
    private Dictionary<Item, int> inventory = new Dictionary<Item, int>();
    private int score;
    private int customerServed;
    private int inspectorServed;
    private int daySurvived;
    private int drinksServed;
    private int foodServed;

    private Till till;

    public Tavern(Till till)
    {
        this.till = till;
    }

    public void incrementScore(int increase)
    {
        score += increase;
    }
    public void incrementCustomersServed()
    {
        customerServed ++;
    }
    public void incrementInspectorsServed()
    {
        inspectorServed++;
    }
    public void incrementDaysSurvived()
    {
        daySurvived++;
    }
    public void incrementFoodServed()
    {
        foodServed++;
    }
    public void incrementDrinksServed()
    {
        drinksServed++;
    }
    public void AddItemToInventory(Item item)
    {
        if(inventory.ContainsKey(item))
        {
            inventory[item] += 1;
        }
        else
        {
            inventory.Add(item, 1);
        }
        till.AddExpense(item.GetCost());
    }
    public void DisplayInventory()
    {
        foreach(Item key in inventory.Keys)
        {
            if(inventory[key]>1)
            {
                Console.WriteLine($"{inventory[key]} {key.GetName()}s");
            }
            else
            {
                Console.WriteLine($"{inventory[key]} {key.GetName()}");
            }
            
        }
    }
    public void DisplayFinances()
    {
        Console.WriteLine($"Current Money: {till.DisplayCurrentMoney()}");
        Console.WriteLine($"Life Time Earnings: {till.DisplayLifetimeEarnings()}");
        Console.WriteLine($"Profit: {till.DisplayProfit()}");

    }

}