class Item
{
    private string name;
    private int cost;
    private string type;

    public Item(string name, int cost, string type)
    {
        this.name = name;
        this.cost = cost;
        this.type = type;
    }
    public int GetCost()
    {
        return cost;
    }
    public string GetName()
    {
        return name;
    }
    public override string ToString()
    {
        return $"{name}";
    }
    public string GetForm()
    {
        return type;
    }
}