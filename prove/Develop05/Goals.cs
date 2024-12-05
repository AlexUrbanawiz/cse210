class Goals
{
    private List<Goal> goalList;
    private int totalPoints;
    public Goals(List<Goal> goals)
    {
        goalList = goals;
        totalPoints = 0;
    }

    public void ListGoals()
    {
        Console.WriteLine("Here are the goals");
    }
    public void SaveGoals()
    {

    }
    public void LoadGoals()
    {

    }
    public List<string> DisplayGoalNames()
    {
        return new List<string>{};
    }
    public Goal GetGoal(int index)
    {
        return goalList[index];
    }

}