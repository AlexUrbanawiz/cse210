using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

class Reference
{
    private int numWordsToHide;
    private int numWordsHidden;
    private string reference;
    //Verse is the actual scripture, while reference is somemthing like John 3:5
    private string verse;
    private string verse2;
    private List<Word> verse1Words = new List<Word>();
    private List<Word> verse2Words = new List<Word>();

    public Reference(string Reference, string Verse)
    {
        this.reference = Reference;
        this.verse = Verse;
        verse1Words = SplitString(verse);
        numWordsToHide = 3;
    }
    public Reference(string reference, string verse1, string verse2)
    {
        this.reference = reference;
        verse = verse1;
        this.verse2 = verse2;
        verse1Words = SplitString(verse);
        verse2Words = SplitString(verse2);
        numWordsToHide = 3;
    }
    public Reference(string reference, string verse, int numWordsToHide)
    {
        this.reference = reference;
        this.verse = verse;
        verse1Words = SplitString(verse);
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

        if((numWordsHidden + numWordsToHide) <= (verse1Words.Count + verse2Words.Count))
        {
            for(int i = 0; i < numWordsToHide; i++)
            {
                Word randomWord = null;
                if(verse2Words.Count == 0)
                {
                    do
                    {   
                    Random random = new Random();
                    int randomIndex = random.Next(verse1Words.Count);
                    randomWord = verse1Words[randomIndex];
                    }
                    while(randomWord.GetHidden());
                    randomWord.ConvertToUnderscore();
                    numWordsHidden++;
                }
                else
                {
                    do
                    {   
                    Random random = new Random();
                    int randomList = random.Next(2);
                    if(randomList == 0)
                    {
                        int randomIndex = random.Next(verse1Words.Count);
                        randomWord = verse1Words[randomIndex];
                    }
                    else
                    {
                        int randomIndex = random.Next(verse2Words.Count);
                        randomWord = verse2Words[randomIndex];
                    }
                    
                    }
                    while(randomWord.GetHidden());
                    randomWord.ConvertToUnderscore();
                    numWordsHidden++;
                }
            }
        
            
        }
        else if(numWordsHidden < (verse1Words.Count + verse2Words.Count))
        {
            while(numWordsHidden < (verse1Words.Count + verse2Words.Count))
            {
                Word randomWord = null;
                if(verse2Words.Count == 0)
                {
                    do
                    {   
                    Random random = new Random();
                    int randomIndex = random.Next(verse1Words.Count);
                    randomWord = verse1Words[randomIndex];
                    }
                    while(randomWord.GetHidden());
                    randomWord.ConvertToUnderscore();
                    numWordsHidden++;
                }
                else
                {
                    do
                    {   
                    Random random = new Random();
                    int randomList = random.Next(2);
                    if(randomList == 0)
                    {
                        int randomIndex = random.Next(verse1Words.Count);
                        randomWord = verse1Words[randomIndex];
                    }
                    else
                    {
                        int randomIndex = random.Next(verse2Words.Count);
                        randomWord = verse2Words[randomIndex];
                    }
                    
                    }
                    while(randomWord.GetHidden());
                    randomWord.ConvertToUnderscore();
                    numWordsHidden++;
                }
            }
        }
    }
    public int GetNumWordsHidden()
    {
        return numWordsHidden;
    }
    public int GetNumWordsInScripture()
    {
        int numWords = 0;
        foreach(Word word in verse1Words)
        {
            numWords++;
        }
        foreach(Word word2 in verse2Words)
        {
            numWords++;
        }
        return numWords;
    }

    public string Display()
    {
        string displayString = $"{reference}\n";
        
        foreach(Word word in verse1Words)
        {
            string stringToAdd = word.Display();
            displayString += stringToAdd;
            displayString += " ";
        }
        if(verse2Words.Count > 0)
        {
            displayString += "\n";
            foreach(Word word in verse2Words)
            {
            string stringToAdd = word.Display();
            displayString += stringToAdd;
            displayString += " ";
            }
        }
        return displayString;
    }
}
