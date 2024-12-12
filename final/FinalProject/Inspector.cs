class Inspector : Person
{



    public Inspector(string name, int pointsForServing, int easiness, double timeBase) : base(name, pointsForServing, "Inspector", easiness, timeBase)
    {
    }


    public override void Action()
    {
        CheckForSpeedyService();
        
    }


}