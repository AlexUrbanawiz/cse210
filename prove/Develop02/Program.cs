using System;

/*
Classes: Journal class, Entry class

Journal:
    Methods:
        X WriteEntry- gives the prompts, gets the response, adds it to the entries
        X AskPrompt- displays a random prompt from the list given
        X GetResponse- returns the response
        Save- Saves entries to a file
        Load- Load entries from a file
        X GetDate- Gets the date
        X GetFileName- Asks the user for a filename and returns it
        X DisplayEntries- Displays the entries
        X SetActiveState- changes the active state
        X GetActiveState- returns the activeState
        DisplayMenu- Displays the menu/enables navigation
        X SaveEntry- Formats and adds the entry to the list
        X AddPrompt- adds a prompt to the prompt list
    Attributes
        X List<Entry> entries
        X List<string> prompts
        X Bool activeState

    WriteEntry: Calls AskPrompt, GetResponse, then CreateEntry

Entry:
    Methods:
        X Display- Displays the entry
        X GetEntry- returns a string of the entry
    Attributes:
        X string Date
        X string prompt
        X string response
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
        while(myJournal.GetActiveState())
        {
            myJournal.DisplayMenu();
            myJournal.ProcessMenu();
        }
    }

    
}