using System.IO; 
class Goals
{
    private List<Goal> goalList;
    private Dictionary<string, Goal> goalDictionary;
    private int totalPoints;
    private string filename;
    public Goals(List<Goal> goals)
    {
        goalList = goals;
        totalPoints = 0;
        ConstructGoalDictionary();
    }
    private void ConstructGoalDictionary()
    {
        foreach(Goal goal in goalList)
        {
            goalDictionary.Add(goal.GetName(), goal);
        }
    }
    public void ListGoals()
    {
        Console.WriteLine("Here are the goals");
    }
    public void SaveGoals()
    {
        AskForFileName();
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine($"Points:{totalPoints}");
            foreach(Goal goal in goalList)
            {
                Console.WriteLine(goal.GetSaveFormat());
            }
        }
    }
    public void LoadGoals()
    {
        AskForFileName();
        string[] lines = System.IO.File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split(",");
            string goalType = parts[0];
            string name = parts[1];
            string description = parts[2];
            bool complete = bool.Parse(parts[3]);
            int points = int.Parse(parts[4]);
            if(goalType == "SimpleGoal")
            {
                SimpleGoal simpleGoal = new SimpleGoal(name, description, points, complete);
                goalList.Add(simpleGoal);
            }
            else if(goalType == "ChecklistGoal")
            {
                int bonusThreshold = int.Parse(parts[5]);
                int timesCompleted = int.Parse(parts[6]);
                int bonusPoints = int.Parse(parts[7]);
                ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, complete, bonusThreshold, bonusPoints, timesCompleted);
                goalList.Add(checklistGoal);
            }
            else if(goalType == "EternalGoal")
            {
                EternalGoal eternalGoal = new EternalGoal(name, description, points);
                goalList.Add(eternalGoal);
            }
        }
    }
    public List<string> DisplayGoalNames()
    {
        List<string> goalNames = new List<string>{};
        foreach(Goal goal in goalList)
        {
            if(!goal.GetCompleation())
            {
                goalNames.Add(goal.GetName());
            }
        }


        return goalNames;
    }
    public Goal GetGoal(int index)
    {
        return goalList[index];
    }
    public Goal GetGoal(string key)
    {
        return goalDictionary[key];
    }

    public void AddGoal(Goal goal)
    {
        goalList.Add(goal);
    }
    private void AskForFileName()
    {
        Console.Write("Please enter the filename: ");
        filename = Console.ReadLine();
    }
}