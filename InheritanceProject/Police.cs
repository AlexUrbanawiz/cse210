class Police : Person
{
    private string weapons;
    public Police(string firstName, string lastName, int age, string weapons) : base(firstName, lastName, age)
    {
        this.weapons = weapons;
    }
    public string GetPoliceInfo()
    {
        return $"{weapons}, {GetPersonInfo()}";
    }
}