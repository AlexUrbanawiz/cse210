using System;

class Program
{
    static void Main(string[] args)
    {

        Circle myCircle = new Circle();
        Console.WriteLine(myCircle.GetArea().ToString("0.00"));

        Circle myCircle2 = new Circle(2);
        Console.WriteLine(myCircle2.GetArea().ToString("0.00"));

        Console.WriteLine(myCircle.GetCircumfrence());
        Console.WriteLine(myCircle2.GetCircumfrence());

        Console.WriteLine(myCircle.GetDiameter());
        Console.WriteLine(myCircle2.GetDiameter());
        
        myCircle.Display();
        myCircle2.Display();

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