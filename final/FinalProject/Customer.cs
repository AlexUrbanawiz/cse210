class Customer : Person
{
    private int moneyBase;
    private int moneyReward;

    private Item favoriteItems;

    public Customer(string name, int pointsForServing, int easiness, int timeBase, int moneyBase, Item favoriteItem) : base(name, pointsForServing, "Customer", easiness, timeBase)
    {
        this.moneyBase = moneyBase;
        this.favoriteItem = favoriteItem;
    }
}