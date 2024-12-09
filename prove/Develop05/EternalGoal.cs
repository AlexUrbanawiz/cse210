class EternalGoal : Goal
{

    public EternalGoal(string name, string description, int numberOfPoints) : base(name, description, numberOfPoints, "eternal")
    {

    }
    public override int RecordEvent()
    {
        return GetPoints();
    }
    public override string GetSaveFormat()
    {
        return $"EternalGoal,{base.GetSaveFormat()}";
    }
    public override string ToString()
    {
        return base.ToString();
    }
}