class Listing : Activity
{
    private List<string> items;
    public Listing(int bufferDuration, List<string> prompts) : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", bufferDuration, prompts)
    {
        items  = new List<string>();
    }
    public void List()
    {
        Console.WriteLine(DisplayPrompt());
        Console.WriteLine("After the pause, start writing, hitting enter after each item!");
        Spinner(GetBufferDuration());
        DateTime endTime = DateTime.Now.AddSeconds(Convert.ToDouble(GetActivityDuration()));
        while(DateTime.Now < endTime)
        {
            items.Add(Console.ReadLine());
        }
        Console.WriteLine($"You finished! You wrote {items.Count} items!");
    }
}