class Reflection : Activity
{
    private List<string> questions;

    public Reflection(int bufferDuration, List<string> prompts, List<string> questions) : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", bufferDuration, prompts)
    {
        this.questions = questions;
    }
    public string DisplayPrompt()
    {
        string prompt = SelectRandomString();
        return prompt;
    }
    public string DisplayQuestion()
    {
        Random random = new Random();
        int randomIndex = random.Next(questions.Count);
        string randomQuestion = questions[randomIndex];
        return randomQuestion;
    }
    public void Reflect()
    {
        Console.WriteLine("Please reflect on this prompt with the questions provided.\n");
        Console.WriteLine(DisplayPrompt());
        
        int timePassed = 0;
        while(timePassed < GetActivityDuration())
        {
            Console.WriteLine(DisplayQuestion());
            Spinner(GetBufferDuration());
            timePassed += GetBufferDuration();
        }
    }
}