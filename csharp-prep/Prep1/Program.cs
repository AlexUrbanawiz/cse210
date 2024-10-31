using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your first name? ");
        string first_name = Console.ReadLine();
        Console.Write("What is your last name? ");
        string last_name = Console.ReadLine();
        Console.WriteLine($"Your name is JOHN CENA!!! {last_name}, {first_name} {last_name}.");
    }
}