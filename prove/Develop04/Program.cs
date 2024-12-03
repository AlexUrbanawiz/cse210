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
        List<ActivityLog> activitiesDone = new List<ActivityLog>();
        Breathing breathing = new Breathing(3, 5);

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
        Reflection reflection = new Reflection(5, prompts, questions);

        List<string> listingPrompts = new List<string>{"Think of a time when you stood up for someone else.", "Think of a time when you did something really difficult.", "Think of a time when you helped someone in need.", "Think of a time when you did something truly selfless."};
        Listing listing = new Listing(4, listingPrompts);

        bool done = false;
        int rating = 0;
        while(!done)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Menue! Please Select an activity");
            Console.WriteLine("1. Breathing\n2. Reflection\n3. Listing\n4. View Activity Log\n5. Quit");
            int input = int.Parse(Console.ReadLine());
            Console.Clear();
            switch(input)
            {
                case 1:
                    Console.WriteLine(breathing.GetStartingMessage());
                    breathing.AskForDuration();
                    breathing.Breathe();
                    breathing.PrintEndMessage();
                    rating = breathing.AskForRating();
                    activitiesDone.Add(new ActivityLog(breathing.GetName(), breathing.GetActivityDuration(), rating));
                    break;
                case 2:
                    Console.WriteLine(reflection.GetStartingMessage());
                    reflection.AskForDuration();
                    reflection.Reflect();
                    reflection.PrintEndMessage();
                    rating = reflection.AskForRating();
                    activitiesDone.Add(new ActivityLog(reflection.GetName(), reflection.GetActivityDuration(), rating));
                    break;
                case 3:
                    Console.WriteLine(listing.GetStartingMessage());
                    listing.AskForDuration();
                    listing.List();
                    listing.PrintEndMessage();
                    rating = listing.AskForRating();
                    activitiesDone.Add(new ActivityLog(listing.GetName(), listing.GetActivityDuration(), rating));
                    break;
                case 4:
                    Console.WriteLine("Viewing Activity Logs:");
                    foreach(ActivityLog activity in activitiesDone)
                    {
                        activity.Display();
                    }
                    Console.WriteLine($"You performed {activitiesDone.Count} activities this session.");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    break;
                case 5:
                    Console.WriteLine("Quitting.");
                    done = true;
                    break;
                

            }
            
        }
        


    }
}