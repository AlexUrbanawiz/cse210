class Word
{
    private string baseWord;
    private string displayWord;
    private bool hidden;

    public Word(string word)
    {
        baseWord = word;
        displayWord = baseWord;
        hidden = false;
    }

    public void ConvertToUnderscore()
    {
        displayWord = "";
        for(int i = 0; i < baseWord.Length; i++)
        {
            displayWord += "_";
        }
        hidden = true;
    }
    public void RevertFromUnderscore()
    {
        displayWord = baseWord;
        hidden = false;
    }
    public bool GetHidden()
    {
        return hidden;
    }
    public string Display()
    {
        return displayWord;
    }
}