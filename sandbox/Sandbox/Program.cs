using System;

class Program
{
    static double AddNumber(double a, double b)
    {
        return a+b;
    }
    static void Main(string[] args)
    {
        int x = 0;
        int y = x++;
        //int x = 0;
        //int y = x;
        //x ++;

        y = ++x;
        //x ++;
        //y = x;
        Console.WriteLine(AddNumber(1222.333, 122.33));
    }

}


// class Circle
// {
//     private double radius;

//     public Circle(double radius)
//     {
//         this.radius = radius;
//     }

//     public Circle()
//     {
//         radius = 10;
//     }

//     public double GetRadius()
//     {
//         return radius;
//     }
//     public void SetRadius(double radius)
//     {
//         this.radius = radius;
//     }

//     public double GetArea()
//     {
//         return Math.PI * radius * radius;
//     }

//     public double GetDiameter()
//     {
//         return radius * 2;
//     }

//     public double GetCircumfrence()
//     {
//         return 2* Math.PI * radius;
//     }

//     public void Display()
//     {
//         Console.WriteLine($"Radius is {radius}\nArea is {GetArea()}\nDiameter is {GetDiameter()}\nCircumfrence is {GetCircumfrence()}");
//     }
// }