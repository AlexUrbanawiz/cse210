class Person
{
    private string name;
    private int pointsForServing;
    private string role;
    private int easiness;
    private double timeBase;
    private double timeAllowed;
    private int timePassed;
    private Item favoriteItem;
    private int score;

    private DateTime startTime;
    private DateTime endTime;

    private Scaling scaling;
    private bool servedCorrectly;
    private bool servedQuickly;


    public Person(string name, int pointsForServing, string role, int easiness, double timeBase, Item favoriteItem)
    {
        this.name = name;
        this.pointsForServing = pointsForServing;
        this.role = role;
        this.easiness = easiness;
        this.timeBase =  timeBase;
        this.favoriteItem = favoriteItem;
    }

    public void SetScaler(Scaling scaling)
    {
        this.scaling = scaling;
    }
    public void SetScore(int score)
    {
        this.score = score;
    }

    public void Serve(Item item)
    {
        if(item == favoriteItem)
        {
            servedCorrectly = true;
        }
        else
        {
            servedCorrectly = false;
        }
    }
    public bool GetServedCorrectly()
    {
        return servedCorrectly;
    }
    public bool GetServedQuickly()
    {
        return servedQuickly;
    }
    public void ScaleTime()
    {
        timeAllowed = (timeBase * scaling.CalculateTimerScale(score))*((double)easiness/5);
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

    public void CheckForSpeedyService()
    {
        if(timePassed <= timeAllowed)
        {
            servedQuickly = true;
        }
        else
        {
            servedQuickly = false;
        }
        
    }

    public virtual void Action(Tavern tavern)
    {
        tavern.incrementScore(1);
    }
    public virtual void PityAction(Tavern tavern)
    {
    }

    public override string ToString()
    {
        ScaleTime();
        timeAllowed = Math.Ceiling(timeAllowed);
        return $"{name} is a {role}, and has a rating of {easiness}/10. They must be served within {timeAllowed} seconds";
    }

    public void DisplayPersonIntro()
    {
        ScaleTime();
        timeAllowed = Math.Ceiling(timeAllowed);
        if(role == "Inspector")
        {
            var startColor = Console.ForegroundColor;
            Console.Write($"Hi I'm {name}, a ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(role);
            Console.ForegroundColor = startColor;
            Console.WriteLine($". My favorite item is {favoriteItem}, and need to be served in {timeAllowed} seconds");
        } 
        else
        {
            var startColor = Console.ForegroundColor;
            Console.Write($"Hi I'm {name}, a ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(role);
            Console.ForegroundColor = startColor;
            Console.WriteLine($". My favorite item is {favoriteItem}, and need to be served in {timeAllowed} seconds");
        }  
    }
    public double GetTimeAllowed()
    {
        return timeAllowed;
    }
    public double GetTimeBase()
    {
        return timeBase;
    }
    public string GetRole()
    {
        return role;
    }
    public string GetName()
    {
        return name;
    }
}