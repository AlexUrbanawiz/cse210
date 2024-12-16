class Till
{
    private int currentMoney;
    private int lifetimeEarnings;
    private int expenses;
    private int profit;

    public Till()
    {
        currentMoney = 0;
        lifetimeEarnings = 0;
        expenses = 0;
        profit = 0;
    }

    public int DisplayCurrentMoney()
    {
        return currentMoney;
    }
    public int DisplayLifetimeEarnings()
    {
        return lifetimeEarnings;
    }
    private void CalculateProfit()
    {
        profit = lifetimeEarnings - expenses;
    }
    public int DisplayProfit()
    {
        CalculateProfit();
        return profit;
    }
    public void AddExpense(int expense)
    {
        expenses += expense;
        SubtractMoney(expense);
    }

    public void SubtractMoney(int moneyToRemove)
    {
        currentMoney -= moneyToRemove;
    }
    public void AddMoney(int moneyToAdd)
    {
        currentMoney += moneyToAdd;
        lifetimeEarnings += moneyToAdd;
    }
    public void SetMoney(int money)
    {
        currentMoney = money;
    }
}