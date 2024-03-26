// Reflection Activity class inheriting from Activity
class ReflectionActivity : Activity
{
    private string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless.",
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity(int duration) : base(duration)
    {
    }

    public override void StartActivity()
    {
        base.StartActivity();
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        Console.WriteLine("Let's begin:");
        SpinAnimation(5);
        DateTime startTime = DateTime.Now;

        TimeSpan promptDuration = TimeSpan.FromSeconds(10); // Duration for prompts

        // Keep track of elapsed time
        TimeSpan elapsedTime = TimeSpan.Zero;


        Random rand = new Random();

        while (elapsedTime < TimeSpan.FromSeconds(duration))
        {
            //Shuffle prompt array
            Shuffle(prompts,rand);
          
            // Display prompts
            foreach (string prompt in prompts)
            {
                Console.WriteLine(prompt);
                Thread.Sleep(promptDuration);
                // Update elapsed time
                elapsedTime = DateTime.Now - startTime;
                // Check if time has run out
                if (elapsedTime >= TimeSpan.FromSeconds(duration))
                    break; // Exit the loop if time has run out
            }
        }

        EndActivity();
    }
    // Method to shuffle an array
    private void Shuffle<T>(T[] array, Random rand)
    {
        int n = array.Length;
        while (n > 1)
        {
            n--;
            int k = rand.Next(n + 1);
            T value = array[k];
            array[k] = array[n];
            array[n] = value;
        }
    }
}
