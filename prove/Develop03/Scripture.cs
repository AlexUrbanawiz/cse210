using System.Reflection.Metadata;

class Scripture
{
    private Reference currentScripture;
    private bool activeState;
    private List<Reference> scriptures;

    public Scripture(List<Reference> scriptures)
    {
        this.scriptures = scriptures;
        activeState = true;
        SelectRandomScripture();
    }
    public Scripture(Reference scripture)
    {
        scriptures.Add(scripture);
        activeState = true;
        SelectRandomScripture();
    }
    public Scripture(string reference, string verse)
    {
        AddScripture(reference, verse);
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
}