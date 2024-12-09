using System.ComponentModel.Design;

abstract class Goal
{
    private string name;
    private bool complete;
    private string description;
    private int numberOfPoints;
    private string goalType;



    public Goal(string name, string description, int numberOfPoints, string goalType)
    {
        this.name = name;
        complete = false;
        this.description = description;
        this.numberOfPoints = numberOfPoints;
        this.goalType = goalType;
    }
    public Goal(string name, string description, int numberOfPoints, bool complete, string goalType)
    {
        this.name = name;
        this.complete = complete;
        this.description = description;
        this.numberOfPoints = numberOfPoints;
        this.goalType = goalType;
    }



    public string GetName()
    {
        return name;
    }
    public bool GetCompleation()
    {
        return complete;
    }

    public virtual string GetSaveFormat()
    {
        return $"{name},{description},{complete},{numberOfPoints}";
    }
    public int GetPoints()
    {
        return numberOfPoints;
    }
    public void SetPoints(int points)
    {
        numberOfPoints = points;
    }
    public virtual void MarkComplete()
    {
        complete = true;
    }
    public string GetGoalType()
    {
        return goalType;
    }
    public abstract int RecordEvent();



}