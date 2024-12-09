class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int numberOfPoints) : base(name, description, numberOfPoints, "simple")
    {
    
    }
    public SimpleGoal(string name, string description, int numberOfPoints, bool complete) : base(name, description, numberOfPoints, complete, "simple")
    {
    
    }

    public override int RecordEvent()
    {
        MarkComplete();
        return GetPoints();
    }
    public override string GetSaveFormat()
    {
        return $"SimpleGoal,{base.GetSaveFormat()}";
    }
    public override string ToString()
    {
        string completed = "";
        if(GetCompletion())
        {
            completed = "x";
        }
        else
        {
            completed = " ";
        }
        return $"[{completed}] {base.ToString()} ";
    }
}