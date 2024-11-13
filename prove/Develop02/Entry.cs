class Entry
{
    private string date;
    private string prompt;
    private string response;

    public Entry(string date, string prompt, string response)
    {
        this.date = date;
        this.prompt = prompt;
        this.response = response;
    }

    public void Display()
    {
        Console.WriteLine(GetEntry());
    }

    public string GetEntry()
    {
        string entry = $"{date}: {prompt} \n{response}";
        return entry;
    }

}