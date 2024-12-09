class ChecklistGoal : Goal
{
    private int bonusThreshold;
    private int timesCompleted;
    private int bonusPoints;

    public ChecklistGoal(string name, string description, int numberOfPoints, int bonusThreshold, int bonusPoints) : base(name, description, numberOfPoints, "checklist")
    {
        this.bonusThreshold = bonusThreshold;
        timesCompleted = 0;
        this.bonusPoints = bonusPoints;
    }
    public ChecklistGoal(string name, string description, int numberOfPoints, bool complete, int bonusThreshold, int bonusPoints, int timesCompleted) : base(name, description, numberOfPoints, complete, "checklist")
    {
        this.bonusThreshold = bonusThreshold;
        this.timesCompleted = timesCompleted;
        this.bonusPoints = bonusPoints;

    }
    private int GetThreshold()
    {
        return bonusThreshold;
    }
    private int GetBonusPoints()
    {
        return bonusPoints;
    }
    private int GetTimesCompleted()
    {
        return timesCompleted;
    }
    public override int RecordEvent()
    {
        int pointSum = 0;
        timesCompleted++;
        pointSum += base.GetPoints();
        if(timesCompleted == bonusThreshold)
        {
            pointSum += bonusPoints;
            MarkComplete();
        }
        return pointSum;
    }
    public override string GetSaveFormat()
    {
        string output = $"ChecklistGoal,{base.GetSaveFormat},{bonusThreshold},{timesCompleted},{bonusPoints}";
        return output;
    }
    public override string ToString()
    {
        return $"[{timesCompleted}/{bonusThreshold}] {base.ToString()}";
    }
}