using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(0,100);
        bool correct = false;
        while(!correct)
        {
            Console.Write("Guesss: ");
            int guess = int.Parse(Console.ReadLine());
            if(guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if(guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You got it");
                correct = true;
            }
        }
    }
}