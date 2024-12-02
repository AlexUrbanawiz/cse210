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
        /*Breathing Script
        Breathing breathing = new Breathing(3, 5);
        Console.WriteLine(breathing.GetStartingMessage());
        breathing.AskForDuration();
        breathing.Breathe();
        breathing.PrintEndMessage();
        */
        List<string> prompts = new List<string>{"Think of a time when you stood up for someone else.", "Think of a time when you did something really difficult.", "Think of a time when you helped someone in need.", "Think of a time when you did something truly selfless."};
        List<string> questions = new List<string>{
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"};
        Reflection reflection = new Reflection(10, prompts, questions);
        Console.WriteLine(reflection.GetStartingMessage());
        reflection.AskForDuration();
        reflection.Reflect();
        reflection.PrintEndMessage();
    }
}