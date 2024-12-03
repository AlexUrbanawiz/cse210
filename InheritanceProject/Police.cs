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
    public override void SetFirstName(string name)
    {
        base.SetFirstName($"{name} the cop");
    }
    public override string GetPersonInfo()
    {
        return $"I am a policeman, my weapon is {weapons}, my info is {base.GetBaseInfo()}";
    }
}