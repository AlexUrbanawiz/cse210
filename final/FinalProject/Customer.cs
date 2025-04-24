class Customer : Person
{
    private int moneyBase;
    public Customer(string name, int pointsForServing, int easiness, int timeBase, int moneyBase, Item favoriteItem) : base(name, pointsForServing, "Customer", easiness, timeBase, favoriteItem)
    {
        this.moneyBase = moneyBase;
    }
    public override void Action(Tavern tavern)
    {
        base.Action(tavern);
        tavern.incrementCustomersServed();
        tavern.AddMoney(moneyBase*2);
    }
    public override void PityAction(Tavern tavern)
    {
        tavern.incrementCustomersServed();
        tavern.AddMoney(moneyBase-1);
    }
    public int GetMoneyBase()
    {
        return moneyBase;
    }
}