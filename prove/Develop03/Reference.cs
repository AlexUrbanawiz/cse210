class Reference
{
    private int numWordsToHide;
    private string reference;
    //Verse is the actual scripture, while reference is somemthing like John 3:5
    private string verse;
    List<Word> allWords = new List<Word>();
    public Reference(string reference, string verse)
    {
        this.reference = reference;
        this.verse = verse;
        allWords = SplitString(verse);
        numWordsToHide = 3;
    }
    public Reference(string reference, string verse, int numWordsToHide)
    {
        this.reference = reference;
        this.verse = verse;
        allWords = SplitString(verse);
        this.numWordsToHide = numWordsToHide;
    }
    public void SetWordsToHide(int numWordsToHide)
    {
        this.numWordsToHide = numWordsToHide;
    }
    public int GetWordsToHide()
    {
        return numWordsToHide;
    }
    public List<Word> SplitString(string text)
    {
        List<Word> wordList = new List<Word>();
        string[] stringList = text.Split(" ");
        
        foreach(string word in stringList)
        {
            Word newWord = new Word(word);
            wordList.Add(newWord);
        }
        return wordList;
    }
    public void HideRandomWord()
    {
        
        for(int i = 0; i < numWordsToHide; i++)
        {
            Word randomWord = null;
            do
            {
                Random random = new Random();
                int randomIndex = random.Next(allWords.Count);
                randomWord = allWords[randomIndex];
            }
            while(randomWord.GetHidden());
            randomWord.ConvertToUnderscore();
        }
    }

    public string Display()
    {
        string displayString = $"{reference}\n";
        
        foreach(Word word in allWords)
        {
            string stringToAdd = word.Display();
            displayString += stringToAdd;
            displayString += " ";
        }
        return displayString;
    }

}