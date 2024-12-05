using System;


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
    RecordEvent
    RunGoal-Activate a goal and give points, for simple it also completes, for eternal it just gives the points, for checklist it gives small points and increments the counter, checks if counter has reached the bonus Threshold

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
                    menu.DisplaySubMenu();
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
                    menu.DisplaySubMenu();
                    break;
                case 6:
                    active = false;
                    break;
            }
        }
    }
}