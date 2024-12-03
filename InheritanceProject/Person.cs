abstract class Person
{
    private string firstName;
    private string lastName;
    private int age;

    public Person(string firstName, string lastName, int age)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }

    public abstract string GetPersonInfo();
    // {
    //     return $"{firstName}, {lastName}, {age}";
    // }
    public string GetBaseInfo()
    {
        return $"{firstName}, {lastName}, {age}";
    }
    public virtual void SetFirstName(string firstName)
    {
        this.firstName = firstName;
    }
}