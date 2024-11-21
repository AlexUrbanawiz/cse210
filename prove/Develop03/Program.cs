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
        Reference referenceTest = new Reference("John 3:5", "This is a test of my program. I really hope it works. Da da da bo bo bo");
        referenceTest.HideRandomWord();
        Console.WriteLine(referenceTest.Display());
        referenceTest.HideRandomWord();
        Console.WriteLine(referenceTest.Display());
    }
}