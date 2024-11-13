using System.ComponentModel;
using System.Runtime.Intrinsics.X86;
using System.Security;
using System.Text.RegularExpressions;

class Journal
{
    private List<Entry> entries = new List<Entry>();
    private List<string> prompts = new List<string>();
    private bool activeState;

    public Journal(List<string> prompts)
    {
        activeState = true;
        foreach(var prompt in prompts)
        {
            this.prompts.Add(prompt);
        }
    }
    public Journal(string prompt)
    {
        activeState = true;
        prompts.Add(prompt);
    }

    public string GetPrompt()
    {
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Count)];
        return prompt;
    }

    public string GetResponse()
    {
        string response = Console.ReadLine();
        return response;
    }
    public string GetDate()
    {
        DateTime currentDate = DateTime.Now;
        string date = currentDate.ToShortDateString();
        return date;
    }
    public void SaveEntryToList(string date, string prompt, string response)
    {
        Entry newEntry = new Entry(date, prompt, response);
        entries.Add(newEntry); 
    }
    public void WriteEntry()
    {
        string prompt = GetPrompt();
        string date = GetDate();
        Console.WriteLine($"{date}: {prompt}");
        string response = GetResponse();
        SaveEntryToList(date, prompt, response);
    }
    public void DisplayEntries()
    {
        Console.WriteLine("Displaying Entries:");
        foreach(Entry entry in entries)
        {
            entry.Display();
            Console.WriteLine();
        }
    }

    public void AddPrompt(string prompt)
    {
        prompts.Add(prompt);
    }
    public void AddPrompt(List<string> prompts)
    {
        foreach(string prompt in prompts)
        {
            this.prompts.Add(prompt);
        }
    }
    public List<string> GetPrompts()
    {
        return prompts;
    }

    public void SetActiveState(bool state)
    {
        activeState = state;
    }
    public bool GetActiveState()
    {
        return activeState;
    }

    public string GetFileName()
    {
        string fileName = Console.ReadLine();
        return fileName;
    }
}