// Activity Program class to manage activities
class ActivityProgram
{
    public void Start()
    {
        // Clear screen
        Console.Clear();
        Console.WriteLine("Welcome to the Activity Program!");
        while (true)
        {
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. See Stats");
            Console.WriteLine("5. Exit");
          
            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        StartBreathingActivity();
                        break;
                    case 2:
                        StartReflectionActivity();
                        break;
                    case 3:
                        StartListingActivity();
                        break;
                    case 4:
                        SeeStats();
                        break;
                    case 5:
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Please enter a number between 1 and 5.");
                        break;
                }
            }
            else
            {

                Console.WriteLine("Invalid input! Please enter a number between 1 and 5.");
            }
        }
    }

  private void StartBreathingActivity()
  {
      Console.WriteLine("Enter duration in seconds:");
      int duration;
      if (int.TryParse(Console.ReadLine(), out duration))
      {
          BreathingActivity activity = new BreathingActivity(duration);
          activity.StartActivity();
          Console.WriteLine($"You have completed another {duration} seconds of the Breathing Activity.");
          // Spinning animation for 5 seconds
          SpinAnimation(5);
      }
      else
      {
          Console.WriteLine("Invalid input! Please enter a number.");
      }
      Console.Clear(); // Clear the screen after activity
  }

  private void StartReflectionActivity()
  {
      Console.WriteLine("Enter duration in seconds:");
      int duration;
      if (int.TryParse(Console.ReadLine(), out duration))
      {
          ReflectionActivity activity = new ReflectionActivity(duration);
          activity.StartActivity();
          Console.WriteLine($"You have completed another {duration} seconds of the Reflection Activity.");
          // Spinning animation for 5 seconds
          SpinAnimation(5);
      }
      else
      {
          Console.WriteLine("Invalid input! Please enter a number.");
      }
      Console.Clear(); // Clear the screen after activity
  }

  private void StartListingActivity()
  {
      Console.WriteLine("Enter duration in seconds:");
      int duration;
      if (int.TryParse(Console.ReadLine(), out duration))
      {
          ListingActivity activity = new ListingActivity(duration);
          activity.StartActivity();
          Console.WriteLine($"You have completed another {duration} seconds of the Listing Activity.");
          // Spinning animation for 5 seconds
          SpinAnimation(5);
      }
      else
      {
          Console.WriteLine("Invalid input! Please enter a number.");
      }
      Console.Clear(); // Clear the screen after activity
  }

  private void SeeStats()
  {
      string filename = "activity_stats.txt";
      if (File.Exists(filename))
      {
          Console.WriteLine("Activity Statistics:");
          string[] lines = File.ReadAllLines(filename);
          foreach (var line in lines)
          {
              Console.WriteLine(line);
          }
      }
      else
      {
          Console.WriteLine("No activity statistics available.");
      }
      // Wait for user to acknowledge before clearing screen
      Console.WriteLine("Press any key to continue...");
      Console.ReadKey();
      Console.Clear();
  }

        // Method to create spinning animation
        private void SpinAnimation(int durationInSeconds)
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
        }

