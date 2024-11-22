using System;

/*
Requirements:

Store a scripture, including both the reference (for example "John 3:16") and the text of the scripture.
Accommodate scriptures with multiple verses, such as "Proverbs 3:5-6".
Clear the console screen and display the complete scripture, including the reference and the text.
Prompt the user to press the enter key or type quit.
If the user types quit, the program should end.
If the user presses the enter key (without typing quit), the program should hide a few random words in the scripture, clear the console screen, and display the scripture again.
The program should continue prompting the user and hiding more words until all words in the scripture are hidden.
When all words in the scripture are hidden, the program should end.
When selecting the random words to hide, for the core requirements, you can select any word at random, 
even if the word was already hidden. 
(As a stretch challenge, try to randomly select from only those words that are not already hidden.)


Scripture memorizer thoughts

store the scripture as a list of strings, can randomly select a word from the scripture and turn it into underscores






Classes:
Scripture - Manages the navigation, displays the output
    Methods:
        HideWord
        Quit
        Display Scripture
        SelectRandomScripture
    Attributes:
        Refernace currentScripture
        bool activeState
        dictionary<string, Referance> scriptures


Referance - Holds a string () , list of words
    Methods:
        HideRandomWord  
        Display
        SplitString
    Attributes:
        int numWordsToHide
        string refrence
        string verse
        list<word> visibleWords
        list<word> allWords

Word - A string, can turn it from underscores to back
    Methods:
        ConvertToUnderscore
        Display
        GetHidden
    Attributes:
        string baseWord
        string displayWord
        bool hidden

*/

class Program
{
    static void Main(string[] args)
    {
        Reference alma28 = new Reference("Alma 28:13","And thus we see how great the inequality of man is because of sin and transgression, and the power of the devil, which comes by the cunning plans which he hath devised to ensnare the hearts of men");
        Reference threeNephi6 = new Reference("3 Nephi 6:7-8", "And it came to pass that there were many cities built anew, and there were many old cities repaired.", "And there were many highways cast up, and many roads made, which led from city to city, and from land to land, and from place to place.");
        //Scripture myScripture = new Scripture("Alma 30:25", "Ye say that this people is a guilty and a fallen people, because of the transgression of a parent. Behold, I say that a child is not guilty because of its parents.");
        // myScripture.AddScripture(alma28);
        // myScripture.AddScripture(threeNephi6);
        Scripture myScripture = new Scripture(threeNephi6);
        while(myScripture.GetActiveState())
        {
            myScripture.Display();
        }
    }

}