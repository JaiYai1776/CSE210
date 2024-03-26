// Listing Activity class inheriting from Activity
class ListingActivity : Activity
{
    private string[] listingPrompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(int duration) : base(duration)
    {
    }

    public override void StartActivity()
    {
        base.StartActivity();
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        Console.WriteLine("Let's begin:");
        SpinAnimation(5);
        Random rand = new Random();
        string prompt = listingPrompts[rand.Next(listingPrompts.Length)];
        Console.WriteLine(prompt);
        Thread.Sleep(2000);
        Console.WriteLine("Start listing...");

        // List items for the specified duration
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        int count = 0;
        while (DateTime.Now < endTime)
        {
            string item = Console.ReadLine();
            if (!string.IsNullOrEmpty(item))
                count++;
        }

        Console.WriteLine($"You've listed {count} items in {duration} seconds.");
        Thread.Sleep(2000);
        EndActivity();
    }
}
