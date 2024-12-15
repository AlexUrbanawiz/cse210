class Inspector : Person
{



    public Inspector(string name, int pointsForServing, int easiness, int timeBase, Item favoriteItem) : base(name, pointsForServing, "Inspector", easiness, timeBase, favoriteItem)
    {
    }


    public override void Action(Tavern tavern)
    {
        base.Action(tavern);
        tavern.incrementInspectorsServed();
    }
    public override void PityAction(Tavern tavern)
    {
        tavern.Failed();
    }


}