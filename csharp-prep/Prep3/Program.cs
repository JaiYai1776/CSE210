using System;

class Program
{
    static void Main()
    {
        // Create a random number generator
        Random random = new Random();
        // Variable to store user's choice to play again
        string playAgain;

        do
        {
            // Generate a random number between 1 and 100
            int magicNumber = random.Next(1, 101);
            // Variables to store user's guess and number of attempts
            int guess;
            int attempts = 0;

            // Welcome message
            Console.WriteLine("Welcome to the Magic Number Game!");
            Console.WriteLine("I've chosen a number between 1 and 100. Try to guess it!");

            do
            {
                // Prompt the user to enter a guess
                Console.Write("Enter your guess: ");
                // Read the user input
                string input = Console.ReadLine();

                // Check if the input can be parsed into an integer
                if (!int.TryParse(input, out guess))
                {
                    // If parsing fails, display an error message and continue the loop
                    Console.WriteLine("Invalid input! Please enter a valid integer.");
                    continue;
                }

                // Increment the number of attempts
                attempts++;

                // Check if the guess is lower than the magic number
                if (guess < magicNumber)
                {
                    Console.WriteLine("Too low! Try guessing higher.");
                }
                // Check if the guess is higher than the magic number
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Too high! Try guessing lower.");
                }
                // If the guess is correct
                else
                {
                    Console.WriteLine("Congratulations! You guessed the magic number {0} in {1} attempts.", magicNumber, attempts);
                }
            } while (guess != magicNumber); // Continue the loop until the correct number is guessed

            // Prompt the user if they want to play again
            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine();
            Console.WriteLine();
        } while (playAgain.ToLower() == "yes"); // Continue the outer loop if the user wants to play again
    }
}
