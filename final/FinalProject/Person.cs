class Person
{
    private string name;
    private int pointsForServing;
    private string role;
    private int easiness;
    private double timeBase;
    private double timeAllowed;
    private int timePassed;

    private int score;

    private DateTime startTime;
    private DateTime endTime;

    private Scaling scaling;


    public Person(string name, int pointsForServing, string role, int easiness, double timeBase)
    {
        this.name = name;
        this.pointsForServing = pointsForServing;
        this.role = role;
        this.easiness = easiness;
        this.timeBase =  timeBase;
    }

    public void SetScaler(Scaling scaling)
    {
        this.scaling = scaling;
    }
    public void SetScore(int score)
    {
        this.score = score;
    }

    public void ScaleTime()
    {
        timeAllowed = (timeBase * scaling.CalculateTimerScale(score))*(easiness/5);
    }

    public void StartTimer()
    {
        startTime = DateTime.Now;
    }
    public void EndTimer()
    {
        endTime = DateTime.Now;
        TimeSpan timeElapsed = endTime-startTime;
        timePassed = timeElapsed.Seconds;
    }

    public bool CheckForSpeedyService()
    {
        if(timePassed <= timeAllowed)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }

    public virtual void Action()
    {
    }

    public override string ToString()
    {
        ScaleTime();
        return $"{name} is a {role}, and has a rating of {easiness}/10. They must be served within {timeAllowed}";
    }


}