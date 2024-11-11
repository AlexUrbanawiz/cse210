class Job
{
        public string company;
        public string jobTitle;
        public int startYear;
        public int endYear;

        public Job(string company, string jobTitle, int startYear, int endYear)
        {
            this.company = company;
            this.jobTitle = jobTitle;
            this.startYear = startYear;
            this.endYear = endYear;
        }
        public void Display()
        {
            Console.WriteLine($"{jobTitle} ({company}) {startYear}-{endYear}");
        }
}