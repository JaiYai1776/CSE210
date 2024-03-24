using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        int durationInSeconds = 0;
        int numIterations = 0;

        // Display menu and get user input
        Console.WriteLine("Choose the duration of the timer:");
        Console.WriteLine("0. 5 Seconds (for testing)");
        Console.WriteLine("1. 30 seconds");
        Console.WriteLine("2. 60 seconds");
        Console.WriteLine("3. 90 seconds");
        Console.WriteLine("4. Exit");
        Console.Write("Enter your choice (1, 2, 3 or 4): ");

        string userInput = Console.ReadLine();

        // Set duration and iterations based on user input
        switch (userInput)
        {
            case "0":
                durationInSeconds = 5;
                numIterations = 5;  // Adjust as needed
                break;
            case "1":
                durationInSeconds = 30;
                numIterations = 30;  // Adjust as needed
                break;
            case "2":
                durationInSeconds = 60;
                numIterations = 60;  // Adjust as needed
                break;
            case "3":
                durationInSeconds = 90;
                numIterations = 90;  // Adjust as needed
                break;
            case "4":
                Console.WriteLine("Exiting.");
                return;
            default:
                Console.WriteLine("Invalid choice. Exiting.");
                return;
        }

        // Calculate the duration of each iteration in milliseconds
        int iterationDuration = durationInSeconds * 1000 / numIterations;

        // Loop to update the completion bar
        for (int i = 0; i <= numIterations; i++)
        {
            // Calculate the remaining seconds
            int remainingSeconds = durationInSeconds - (i * durationInSeconds / numIterations);

            // Calculate the number of "#" characters to display
            int numHashes = numIterations - i;

            // Format the completion bar
            string completionBar = "[" + new string('#', numHashes) + new string(' ', i) + "]";

            // Print the remaining seconds and the completion bar
            Console.WriteLine($"Remaining Time: {remainingSeconds} seconds {completionBar}");

            // Delay to wait for the next iteration
            Thread.Sleep(iterationDuration);

            // Clear the console to update the progress
            Console.Clear();
        }

        // Timer completed, start fireworks
        FireworksDisplay fireworksDisplay = new FireworksDisplay();
        fireworksDisplay.Start();
    }
}

class FireworksDisplay
{
    // Method to start the fireworks display
    public void Start()
    {
        Console.CursorVisible = false; // Hide cursor

        // Set the number of fireworks bursts
        int numBursts = 5;

        // Loop to display fireworks bursts
        for (int i = 0; i < numBursts; i++)
        {
            // Generate random coordinates for the fireworks burst
            int centerX = new Random().Next(Console.WindowWidth);
            int centerY = new Random().Next(Console.WindowHeight);

            // Simulate explosion by printing particles
            Explode(centerX, centerY);

            // Delay to create a burst effect
            Thread.Sleep(500);

            // Clear the console
            Console.Clear();
        }

        Console.CursorVisible = true; // Show cursor
    }

    // Method to simulate an explosion
    static void Explode(int centerX, int centerY)
    {
        Random random = new Random();

        // Define the range of explosion
        int explosionRange = 15;

        // Loop to spread particles in a circular pattern
        for (int radius = 1; radius <= explosionRange; radius++)
        {
            // Loop through 360 degrees
            for (int angle = 0; angle < 360; angle += 5)
            {
                // Calculate coordinates for each particle
                int x = centerX + (int)(radius * Math.Cos(angle * Math.PI / 180));
                int y = centerY + (int)(radius * Math.Sin(angle * Math.PI / 180));

                // Check if the calculated coordinates are within the console window bounds
                if (x >= 0 && x < Console.WindowWidth && y >= 0 && y < Console.WindowHeight)
                {
                    // Print a particle at the calculated coordinates
                    Console.SetCursorPosition(x, y);
                    Console.ForegroundColor = GetRandomConsoleColor();
                    Console.Write("*");
                }

                // Delay to create a spread effect
                Thread.Sleep(1);
            }
        }
    }

    // Method to generate a random console color
    static ConsoleColor GetRandomConsoleColor()
    {
        var consoleColors = Enum.GetValues(typeof(ConsoleColor));
        return (ConsoleColor)consoleColors.GetValue(new Random().Next(consoleColors.Length));
    }
}
