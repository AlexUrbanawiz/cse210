using System;

class Program
{
    static void Main(string[] args)
    {
        Person bob = new Person("Bob", "Billy", 37);
        Doctor doctorBob = new Doctor("Doc. Bob", "Billy", 37, "Hack saw");
        Police policemanBob = new Police("Officer Bob", "Billy", 37, "Rocket Launcher");
        Console.WriteLine(bob.GetPersonInfo());
        Console.WriteLine(doctorBob.GetDoctorInfo());
        
        Console.WriteLine(policemanBob.GetPersonInfo());
        Console.WriteLine(policemanBob.GetPoliceInfo());

    }
}