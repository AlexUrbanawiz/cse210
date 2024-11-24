using System.ComponentModel;
using System.Reflection.Metadata;

class Scripture
{
    private Reference currentScripture;
    private bool activeState;
    private List<Reference> scriptures = new List<Reference>();
    //private bool scriptureHidden;

    public Scripture(List<Reference> scriptures)
    {
        this.scriptures = scriptures;
        activeState = true;
        SelectRandomScripture();
        //scriptureHidden = false;
    }
    public Scripture(Reference scripture)
    {
        scriptures.Add(scripture);
        activeState = true;
        SelectRandomScripture();
        //scriptureHidden = false;
    }
    public Scripture(string reference, string verse)
    {
        AddScripture(reference, verse);
        activeState = true;
        SelectRandomScripture();
    }
    public Scripture(string reference, string verse1, string verse2)
    {
        AddScripture(reference, verse1, verse2);
        activeState = true;
        SelectRandomScripture();
    }
    public void SelectRandomScripture()
    {
        Random random = new Random();
        int randomIndex = random.Next(scriptures.Count);
        currentScripture = scriptures[randomIndex];
    }
    public void AddScripture(string reference, string verse)
    {
        Reference newReference = new Reference(reference, verse);
        scriptures.Add(newReference);
    }
    public void AddScripture(Reference reference)
    {
        scriptures.Add(reference);
    }
    public void AddScripture(string reference, string verse1, string verse2)
    {
        Reference newReference = new Reference(reference, verse1, verse2);
        scriptures.Add(newReference);
    }
    public bool GetActiveState()
    {
        return activeState;
    }
    public void HideWord()
    {
        Console.WriteLine($"The current number of words hidden at a time is {currentScripture.GetWordsToHide()}. Do you want to change this?");
        string response = Console.ReadLine();
        if(response.ToLower() == "yes")
        {
            Console.WriteLine("Enter the new number: ");
            int newNumber = int.Parse(Console.ReadLine());
            currentScripture.SetWordsToHide(newNumber);
        }
        currentScripture.HideRandomWord();
    }
    public void Quit()
    {
        Console.WriteLine("Quitting");
        activeState = false;
    }
    public void Reset()
    {
        foreach(Reference reference in scriptures)
        {
            reference.ResetWords();
        }
        Console.WriteLine("All scriptures are reset!");
    }

    public void Display()
    {
        Console.WriteLine(currentScripture.Display());
        Console.WriteLine("Type enter to continue, quit to quit, random for a random scripture, or reset to reset all scriptures.");
        string answer = Console.ReadLine();
        if(answer.ToLower() == "enter")
        {
            if(currentScripture.GetNumWordsHidden() < currentScripture.GetNumWordsInScripture())
            {
                HideWord();
            }
            // else if(currentScripture.GetNumWordsHidden() == currentScripture.GetNumWordsInScripture() && !scriptureHidden)
            // {
            //     currentScripture.Display();
            //     scriptureHidden = true;
            // }
            else
            {
                currentScripture.Display();
                Console.WriteLine("All words are hidden, ending the program.");
                Quit();
            }

        }
        else if(answer.ToLower() == "quit")
        {
            Quit();
        }
        else if(answer.ToLower() == "random")
        {
            SelectRandomScripture();
        }
        else if(answer.ToLower() == "reset")
        {
            Reset();
        }
        else
        {
            Console.WriteLine("Not a valid input, try agin");
            Display();
        }
    }
}