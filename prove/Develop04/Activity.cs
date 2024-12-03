using System.Data;

class Activity
{
    private string activityName;
    private string activityDescription;
    private int activityDuration;
    private int bufferDuration;
    private List<string> prompts;
    private List<string> usedPrompts = new List<string>();
    private int countdownDuration;
    public Activity(string activityName, string activityDescription, int bufferDuration)
    {
        this.activityName = activityName;
        this.activityDescription = activityDescription;
        this.bufferDuration = bufferDuration;
    }
    public Activity(string activityName, string activityDescription, int bufferDuration, int countdownDuration)
    {
        this.activityName = activityName;
        this.activityDescription = activityDescription;
        this.bufferDuration = bufferDuration;
        this.countdownDuration = countdownDuration;
    }
    public Activity(string activityName, string activityDescription, int bufferDuration, List<string> prompts)
    {
        this.activityName = activityName;
        this.activityDescription = activityDescription;
        this.bufferDuration = bufferDuration;
        this.prompts = prompts;
    }
    public Activity(string activityName, string activityDescription, int bufferDuration, int countdownDuration, List<string> prompts)
    {
        this.activityName = activityName;
        this.activityDescription = activityDescription;
        this.bufferDuration = bufferDuration;
        this.countdownDuration = countdownDuration;
        this.prompts = prompts;
    }

    public string GetStartingMessage()
    {
        return $"{activityName} - {activityDescription}";
    }
    public void AskForDuration()
    {
        Console.Write("Please input the duration of the activity: ");
        int input = int.Parse(Console.ReadLine());
        activityDuration = input;
    }
    public void PrintEndMessage()
    {
        Console.WriteLine("You have done a good job!");
        Spinner(bufferDuration);
        Console.WriteLine($"You did the {activityName} activity for {activityDuration} seconds.");

    }
    public int GetActivityDuration()
    {
        return activityDuration;
    }
    public void Spinner(int duration)
    {
        for(int i = 0; i < duration; i++)
        {
            Console.Write("|");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("/");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("-");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("\\");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("|");
            Console.Write("\b \b");
        }
    }
    public void CountDown()
    {
        for(int i = countdownDuration; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
    public int GetCountDownDuration()
    {
        return countdownDuration;
    }
    public string SelectRandomString()
    {
        int promptsInUsedPrompts = 0;
        foreach(string prompt in prompts)
        {
            if(usedPrompts.Contains(prompt))
            {
                promptsInUsedPrompts ++;
            }
        }
        if(promptsInUsedPrompts == prompts.Count)
        {
            usedPrompts.Clear();
            promptsInUsedPrompts =0;
        }
        Random random = new Random();
        int randomIndex = 0;
        string selectedString = "aaaa";
        do
        {
            randomIndex = random.Next(prompts.Count);
            selectedString = prompts[randomIndex];
        }
        while(usedPrompts.Contains(selectedString));
        usedPrompts.Add(selectedString);
        return selectedString;

    }
    public int GetBufferDuration()
    {
        return bufferDuration;
    }
    public string DisplayPrompt()
    {
        string prompt = SelectRandomString();
        return prompt;
    }
    public int AskForRating()
    {
        Console.WriteLine("How would you rate the previous activity out of 10? ");
        int input = int.Parse(Console.ReadLine());
        return input;
    }
    public string GetName()
    {
        return activityName;
    }
}
