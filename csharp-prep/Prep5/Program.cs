using System;

class Program
{
    static void Main()
    {
        // Call DisplayWelcome function
        DisplayWelcome();

        // Call PromptUserName function
        string userName = PromptUserName();

        // Call PromptUserNumber function
        int userNumber = PromptUserNumber();

        // Call SquareNumber function
        int squaredNumber = SquareNumber(userNumber);

        // Call DisplayResult function
        DisplayResult(userName, squaredNumber);
    }

    // Function to display a welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    // Function to prompt the user for their name and return it
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    // Function to prompt the user for their favorite number and return it
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    // Function to square a given number and return the result
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // Function to display the result
    static void DisplayResult(string userName, int squaredNumber)
    {
        Console.WriteLine("Hello, " + userName + "! Your favorite number squared is: " + squaredNumber);
    }
}
