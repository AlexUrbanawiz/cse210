class Resume
{
    private string name;
    private List<Job> jobs = new List<Job>();

    public Resume(string name)
    {
        this.name = name;

        jobs.Add(new Job("Microsoft", "Software Engineer", 2019, 2022));
        jobs.Add(new Job("Apple", "Manager", 2022, 2023));
    }

    public void Display()
    {
        Console.WriteLine($"Name: {name}\nJobs:");
        jobs[0].Display();
        jobs[1].Display();
    }
}