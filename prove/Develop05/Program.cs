using System;
using System.IO; 


/*
Goal:




Attributes
    string name
    string description
    int numberOfPoints
    bool status
    string goalType
Methods
    Get Name
    Get Description
    Set Description
    Get Points
    Set Points
    GetStatus
    Mark Complete
    List Goal
    ToString
    GetGoalType
    RecordEvent -Activate a goal and give points, for simple it also completes, for eternal it just gives the points, for checklist it gives small points and increments the counter, checks if counter has reached the bonus Threshold

Simple Goal


Eternal Goal


Checklist Goal
    bonusThreshold
    bonusPoints



Goals Class
Attributes
    List<goals> goalList
    int score
    string filename
Methods
    ListGoals
    GetGoalNames
    GetGoal[int index]
    AddGoal
    AskForFileName
    Save
    Load

Menu
DisplayBaseMenu->int
DisplaySubMenu->int

*/
class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        Goals goals = new Goals(new List<Goal>{});
        bool active = true;
        while(active)
        {
            int input = menu.DisplayBaseMenu();
            switch(input)
            {
                case 1:
                    int goalNumber = menu.DisplaySubMenu();
                    Console.Write("Enter the goal name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter a short description: ");
                    string description = Console.ReadLine();
                    Console.Write("How many points is it worth: ");
                    int points = int.Parse(Console.ReadLine());
                    switch(goalNumber)
                    {
                        case 1:
                            SimpleGoal simpleGoal = new SimpleGoal(name, description, points);
                            goals.AddGoal(simpleGoal);
                            break;
                        case 2:
                            EternalGoal eternalGoal = new EternalGoal(name, description, points);
                            goals.AddGoal(eternalGoal);
                            break;
                        case 3:
                            Console.Write()
                    }
                    break;
                case 2:
                    goals.ListGoals();
                    break;
                case 3:
                    goals.SaveGoals();
                    break;
                case 4:
                    goals.LoadGoals();
                    break;
                case 5:
                    Console.WriteLine("The goals are:");
                    List<string> goalNames = goals.DisplayGoalNames();
                    for(int i = 0; i < goalNames.Count(); i++)
                    {
                        Console.WriteLine($"{i+1}. {goalNames[i]}");
                    }
                    string goalSelected = goalNames[int.Parse(Console.ReadLine())+1];
                    Goal selectedGoal = goals.GetGoal(goalSelected);
                    selectedGoal.RecordEvent();
                    break;
                case 6:
                    active = false;
                    break;
            }
        }
    }
}