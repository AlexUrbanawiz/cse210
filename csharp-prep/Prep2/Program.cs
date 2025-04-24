using System;

class Program
{
    static void Main(string[] args)
    {
        //Homework 2
        
        Console.Write("What is your grade(%) ");
        int grade = int.Parse(Console.ReadLine());
        string letter_grade;
        if(grade < 60)
        {
            letter_grade = "F";
        }
        else if(grade < 80)
        {
            letter_grade = "C";
        }
        else if(grade< 90)
        {
            letter_grade = "B";
        }
        else
        {
            letter_grade = "A";
        }

        if(letter_grade != "F")
        {
            if(grade%10 <=3)
            {
                letter_grade = letter_grade + "-";
            }
            else if(letter_grade != "A" && grade%10 >=7)
            {
                letter_grade = letter_grade + "+";
            }
        }

        if(grade >= 70)
        {
            Console.WriteLine("You passed! Congrats.");
        }
        else
        {
            Console.WriteLine("You didnt pass. Better luck next time.");
        }

        Console.WriteLine($"Your letter grade is {letter_grade}");
    }
}