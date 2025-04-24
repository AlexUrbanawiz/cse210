using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to sandbox");
    }
}

class Circle
{
    private double radius;

    public Circle(double radius)
    {
        this.radius = radius;
    }

    public Circle()
    {
        radius = 10;
    }

    public double GetRadius()
    {
        return radius;
    }
    public void SetRadius(double radius)
    {
        this.radius = radius;
    }

    public double GetArea()
    {
        return Math.PI * radius * radius;
    }

    public double GetDiameter()
    {
        return radius * 2;
    }

    public double GetCircumfrence()
    {
        return 2* Math.PI * radius;
    }

    public void Display()
    {
        Console.WriteLine($"Radius is {radius}\nArea is {GetArea()}\nDiameter is {GetDiameter()}\nCircumfrence is {GetCircumfrence()}");
    }
}