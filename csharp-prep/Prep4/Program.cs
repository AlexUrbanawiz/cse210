using System;

class Program
{
    static void Main(string[] args)
    {
        bool done = false;
        List<int> numberList = new List<int>();
        while(!done)
        {
            Console.Write("Enter a number (0 to end) ");
            int addNumber = int.Parse(Console.ReadLine());
            numberList.Add(addNumber);
        }
        int sum = 0;
        int largestNumber = 0;
        foreach (int number in numberList)
        {
            sum += number;
            if(number > largestNumber)
            {
                largestNumber = number;
            }
        }
        Console.WriteLine($"The sum is {sum}");
        float average = sum / numberList.Count;
        Console.WriteLine($"The average is {average}");
        Console.WriteLine($"The largest number is {largestNumber}");
    }
}