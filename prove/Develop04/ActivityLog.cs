class ActivityLog
{
    private string activityName;
    private int activityDuration;
    private int activityRating;
    public ActivityLog(string activityName, int activityDuration, int activityRating)
    {
        this.activityName = activityName;
        this.activityDuration = activityDuration;
        this.activityRating = activityRating;
    }
    public void Display()
    {
        Console.WriteLine($"The activity {activityName} was performed for {activityDuration} seconds, with a rating of {activityRating}/10.");
    }
}
