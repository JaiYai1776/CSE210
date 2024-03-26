// Base class for all activities
class Activity
{
    protected int duration;

    public Activity(int duration)
    {
        this.duration = duration;
    }

    // Method to display starting message
    public virtual void StartActivity()
    {
        
      
        Console.WriteLine("Starting activity...");
        // Spinning animation for 5 seconds
        Console.WriteLine("Get ready...");
        SpinAnimation(5);
        Console.WriteLine("Start!");
        // Clear screen
        Console.Clear();


    }

    // Method to display ending message
    public virtual void EndActivity()
    {
        Console.WriteLine("Well done!");
        // Spinning animation for 5 seconds
        SpinAnimation(5);
        Console.WriteLine($"You've completed the activity in {duration} seconds.");
         SpinAnimation(5);
        // Update activity duration in the txt file
        UpdateActivityDuration(this.GetType().Name, duration);
    }
     // Method to display countdown timer
    private void CountdownTimer(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine($"Time left: {i} seconds");
            Thread.Sleep(1000);
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }
    }
  
    
    // Method to create spinning animation
    protected void SpinAnimation(int durationInSeconds)
    {
        DateTime endTime = DateTime.Now.AddSeconds(durationInSeconds);
        string[] spinChars = { "|", "/", "-", "\\" };
        int spinIndex = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write($"\r{spinChars[spinIndex]}");
            spinIndex = (spinIndex + 1) % spinChars.Length;
            Thread.Sleep(200);
        }
        Console.WriteLine();
    }
  // Method to update activity duration in a txt file
  protected void UpdateActivityDuration(string activityName, int duration)
  {
      string filename = "activity_stats.txt";
      // Get the current date and time
      DateTime currentDate = DateTime.Now;
      // Format the date as desired
      string formattedDate = currentDate.ToString("yyyy-MM-dd HH:mm:ss");

      // Write the activity name, duration, and date to the file
      using (StreamWriter sw = File.AppendText(filename))
      {
          sw.WriteLine($"{formattedDate} - {activityName}: {TimeSpan.FromSeconds(duration)}");
      }
  }
}
