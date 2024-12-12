class Till
{
    private int currentMoney;
    private int lifetimeEarnings;
    private int expenses;
    private int profit;

    public void DisplayCurrentMoney()
    {
        Console.WriteLine(currentMoney);
    }
    public void DisplayLifetimeEarnings()
    {
        Console.WriteLine(lifetimeEarnings);
    }
    private void CalculateProfit()
    {
        profit = lifetimeEarnings - expenses;
    }
    public void DisplayProfit()
    {
        Console.WriteLine(profit);
    }
    public void AddExpense(int expense)
    {
        expenses += expense;
    }

    public void SubtractMoney(int moneyToRemove)
    {
        currentMoney -= moneyToRemove;
    }
    public void AddMoney(int moneyToAdd)
    {
        currentMoney += moneyToAdd;
    }
}