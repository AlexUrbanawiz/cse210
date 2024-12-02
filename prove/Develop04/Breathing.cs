class Breathing : Activity
{
    public Breathing(int bufferDuration, int countdownDuration) : base("Breathing", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.",bufferDuration, countdownDuration)
    {
    }
    public void Breathe()
    {
        int timePassed = 0;
        int messageCounter = 0;
        while(timePassed < GetActivityDuration())
        {
            if(messageCounter %2 == 0)
            {
                Console.WriteLine("Breathe in....");
                messageCounter ++;
            }
            else
            {
                Console.WriteLine("Breathe out....");
                messageCounter ++;
            }
            CountDown();
            timePassed += GetCountDownDuration();
        }
    }
}