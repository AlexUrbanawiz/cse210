using System;

/*
Classes: Journal class, Entry class

Journal:
    Methods:
        WriteEntry- gives the prompts, gets the response, adds it to the entries
        AskPrompt- displays a random prompt from the list given
        GetResponse- returns the response
        Save- Saves entries to a file
        Load- Load entries from a file
        GetDate- Gets the date
        GetFileName- Asks the user for a filename and returns it
        DisplayEntries- Displays the entries
        SetActiveState- changes the active state
        GetActiveState- returns the activeState
        DisplayMenu- Displays the menu/enables navigation
        SaveEntry- Formats and adds the entry to the list
        AddPrompt- adds a prompt to the prompt list
    Attributes
        List<Entry> entries
        List<string> prompts
        Bool activeState

    WriteEntry: Calls AskPrompt, GetResponse, then CreateEntry

Entry:
    Methods:
        Display- Displays the entry
        GetEntry- returns a string of the entry
    Attributes:
        string Date
        string prompt
        string response
*/

class Program
{
    static void WriteEntries(Journal myJournal)
    {
        myJournal.WriteEntry();
        Console.WriteLine();
    }
    static void Main(string[] args)
    {

        List<string> journalPrompts = new List<string>
    {
    "What are three things you are grateful for today, and why?",
    "Describe a recent challenge you faced and how you overcame it.",
    "What are your top three goals for the next month?",
    "Reflect on a moment when you felt truly at peace. What were you doing?",
    "Write about a person who inspires you and explain why.",
    "What lessons did you learn from a recent failure or setback?",
    "How do you envision your ideal day, from morning to night?",
    "What qualities do you admire most in yourself?",
    "What is one thing you can do today to make yourself happier?",
    "Describe a book, movie, or piece of art that has impacted you and why."
    };


        Journal myJournal = new Journal(journalPrompts);
        //WriteEntries(myJournal);
        Console.WriteLine(myJournal.GetPrompts().Count);
        myJournal.AddPrompt("This is a test abc");
        Console.WriteLine(myJournal.GetPrompts().Count);
        List<string> testPrompts = new List<string> {"A", "B", "C"};
        myJournal.AddPrompt(testPrompts);
        Console.WriteLine(myJournal.GetPrompts().Count);
        myJournal.DisplayEntries();
    }

    
}