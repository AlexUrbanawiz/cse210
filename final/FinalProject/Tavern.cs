class Tavern
{
    private Dictionary<Item, int> inventory = new Dictionary<Item, int>();
    private int score = 0;
    private int customerServed;
    private int inspectorServed;
    private int daySurvived;
    private int drinksServed;
    private int foodServed;
    private bool failed = false;
    private Till till;

    public Tavern(Till till)
    {
        this.till = till;
    }
    public Tavern(Till till, int startingMoney)
    {
        this.till = till;
        till.SetMoney(startingMoney);
    }
    public int GetScore()
    {
        return score;
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
    public void AddItemToInventory(Item item, int quantity=1)
    {
        for(int i = 0; i < quantity; i++)
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
    }
    public void SubtractFromInventory(Item item)
    {
        inventory[item]--;
    }
    public void DisplayInventory()
    {
        int counter = 1;
        foreach(Item key in inventory.Keys)
        {
            Console.Write($"{counter}. ");
            if(inventory[key]>1)
            {
                Console.WriteLine($"{inventory[key]} {key.GetName()}s");
            }
            else
            {
                Console.WriteLine($"{inventory[key]} {key.GetName()}");
            }
            counter ++;
            
        }
    }
    public Dictionary<Item, int> GetInventory()
    {
        return inventory;
    }
    public void DisplayFinances()
    {
        Console.WriteLine($"Current Money: {till.DisplayCurrentMoney()}");
        Console.WriteLine($"Life Time Earnings: {till.DisplayLifetimeEarnings()}");
        Console.WriteLine($"Profit: {till.DisplayProfit()}");

    }
    public void Failed()
    {
        failed = true;
    }
    public bool GetFailure()
    {
        return failed;
    }
    public void AddMoney(int money)
    {
        till.AddMoney(money);
    }
    public void SubtractMoney(int money)
    {
        till.AddExpense(money);
    }
    public int GetMoney()
    {
        return till.DisplayCurrentMoney();
    }
}