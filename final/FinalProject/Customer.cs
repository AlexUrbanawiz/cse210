class Customer : Person
{
    private int moneyBase;
    private int moneyReward;


    public Customer(string name, int pointsForServing, int easiness, int timeBase, int moneyBase) : base(name, pointsForServing, "Customer", easiness, timeBase)
    {
        this.moneyBase = moneyBase;
    }
}