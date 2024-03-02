using System;

class Program
{
    static void Main(string[] args)
    {
   // Prompt the user to enter their grade percentage
    Console.WriteLine ("Enter your grade percentage:");
    // Read the grade percentage input from the user
    double gradePercentage = Convert.ToDouble(Console.ReadLine());

    // Declare variables to store the letter grade and sign
    string letter;
    string sign = "";

    // Determine the letter grade based on the grade percentage
    if (gradePercentage >= 90) {
        letter = "A";
    }
    else if (gradePercentage >= 80) {
        letter = "B";
    }
    else if (gradePercentage >= 70) {
        letter = "C";
    }
    else {
        letter = "F";
    }

    // Determine the sign based on the last digit of the grade percentage
    int lastDigit = (int)gradePercentage % 10;
    if (letter != "F") {
        if (lastDigit >= 7) {
            sign = "+";
        }
        else if (lastDigit < 3) {
            sign = "-";
        }
    }

    // Handle exceptional cases for A+ and F
    if (letter == "A" && sign == "+") {
        letter = "A";
        sign = "";
    }
    else if (letter == "F") {
        sign = "";
    }

    // Display the letter grade and sign
    Console.WriteLine($"Your letter grade is: {letter}{sign}");

    // Check if the grade percentage is sufficient to pass the course
    if (gradePercentage >= 70) {
        Console.WriteLine("Congratulations! You passed the course!");
    }
    else {
        Console.WriteLine("Don't worry, keep working hard and you'll do better next time!");
    }
  }
}