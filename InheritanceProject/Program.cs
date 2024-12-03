using System;

class Program
{
    public static void SetPersonFirstName(Person person, string firstName)
    {
        person.SetFirstName(firstName);
    }
    static void Main(string[] args)
    {
        // Person bob = new Person("Bob", "Billy", 37);
        Doctor doctorBob = new Doctor("Doc. Bob", "Billy", 37, "Hack saw");
        Police policemanBob = new Police("Officer Bob", "Billy", 37, "Rocket Launcher");
        // Console.WriteLine(bob.GetPersonInfo());
        // Console.WriteLine(doctorBob.GetDoctorInfo());
        
        // Console.WriteLine(policemanBob.GetPersonInfo());
        SetPersonFirstName(policemanBob, "Bob the Second");
        // SetPersonFirstName(bob, "Bob the test");
        // Console.WriteLine(bob.GetPersonInfo());
        // Console.WriteLine(policemanBob.GetPoliceInfo());

        List<Person> people = new List<Person>();
        // people.Add(bob);
        people.Add(doctorBob);
        people.Add(policemanBob);
        foreach(Person person in people)
        {
            Console.WriteLine(person.GetPersonInfo());
        }

    }
}