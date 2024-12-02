using System;


/*
Classes for Mindfulness Program

Activity Class
Attributes:
    string activityName
    string activityDescription
    float activityDuration
    float bufferDuration
    List<string> prompts
    List<string> usedPrompts
    float countdownDuration
Methods:
    string GetStartingMessege
    void AskForDuration
    void Begin
    void Spinner
    string GetEndMessege
    float GetActivityDuration
    void Pause
    private string SelectRandomString(list<string> strings, list<string> usedStrings)
    void DisplayPrompt
    int CountDown

Breathing Activity Class
Attributes:
    
Methods:
    void Breathe



Reflection Activity Class
Attributes:
    
    List<string> questions
    List<string> usedQuestions

Methods:
    void DisplayQuestion


Listing Activity Class
Attributes:
    List<string> items

Methods:
    string RecciveItems
    List<string> SplitItems
    private int CountItems(List<string> items)
    void DisplayItems

*/
class Program
{
    static void Main(string[] args)
    {
        Breathing breathing = new Breathing(3, 5);
        Console.WriteLine(breathing.GetStartingMessage());
        breathing.AskForDuration();
        breathing.Breathe();
        breathing.PrintEndMessage();

    }
}