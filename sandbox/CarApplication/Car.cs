class Car
{

    private Tire tires;

    public Car()
    {
        tires = new Tire(205, 16, 55);
    }



    public void Display()
    {
        Console.WriteLine("This is a car");
        tires.Display();
    }

}

