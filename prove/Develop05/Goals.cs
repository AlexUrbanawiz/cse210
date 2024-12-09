using System.IO;
using System.Reflection.Metadata;


class Goals
{

    private List<Goal> goalList;
    private Dictionary<string, Goal> goalDictionary = new Dictionary<string, Goal>();
    private int totalPoints;
    private int level;
    private double[] xpScaling;
    private const int XINDEX = 0;
    private const int YINDEX = 1;
    private string filename;
    public Goals(List<Goal> goals, double x, double y)
    {
        goalList = goals;
        totalPoints = 0;
        ConstructGoalDictionary();
        xpScaling = new double[]{x,y};
    }
    public Goals(double x, double y)
    {
        goalList = new List<Goal>();
        totalPoints = 0;
        ConstructGoalDictionary();
        xpScaling = new double[]{x,y};
    }
    private void CalculateLevel()
    {
        level = (int)Math.Floor((xpScaling[XINDEX] * Math.Pow(totalPoints, Math.Pow(xpScaling[YINDEX], -1))));
    }
    private int CalculateXPNeededForNextLevel()
    {
        int xp = (int)Math.Pow(((level+1)/xpScaling[XINDEX]),xpScaling[YINDEX]);
        int difference = xp-totalPoints;
        return difference;
    }
    public int GetLevel()
    {
        return level;
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
        Console.WriteLine("Here are the goals: ");
        int i = 0;
        foreach(Goal goal in goalList)
        {
            i++;
            Console.WriteLine($"{i}. {goal.ToString()}");
            
        }
        Console.WriteLine($"You have {totalPoints} points");
        Console.WriteLine($"You are level {level}, and need {CalculateXPNeededForNextLevel()} points to reach the next level");
        Console.WriteLine($"Your next color is {GetCurrentColor(level+1)}");
    }
    public ConsoleColor GetCurrentColor(int level)
    {
        ConsoleColor[] consoleColors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
        consoleColors.Reverse();
        if(level >= consoleColors.Count())
        {
            return consoleColors[level % consoleColors.Count()];
        }
        else
        {
            return consoleColors[level];
        }
    }
    public void SaveGoals()
    {
        AskForFileName();
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine($"{totalPoints}");
            foreach(Goal goal in goalList)
            {
                outputFile.WriteLine(goal.GetSaveFormat());
            }
        }
    }
    public void LoadGoals()
    {
        AskForFileName();
        string[] lines = System.IO.File.ReadAllLines(filename);
        AddPoints(int.Parse(lines[0]));
        foreach (string line in lines)
        {
            if(line != lines[0])
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
        ConstructGoalDictionary();
    }
    public List<string> DisplayGoalNames()
    {
        List<string> goalNames = new List<string>{};
        foreach(Goal goal in goalList)
        {
            if(!goal.GetCompletion())
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
        goalDictionary.Add(goal.GetName(), goal);
    }
    private void AskForFileName()
    {
        Console.Write("Please enter the filename: ");
        filename = Console.ReadLine();
    }
    public void AddPoints(int pointsToAdd)
    {
        totalPoints += pointsToAdd;
        CalculateLevel();
    }

}