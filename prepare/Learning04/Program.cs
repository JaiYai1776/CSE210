using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a base "Assignment" object
        Assignment multiplicationAssignment = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(multiplicationAssignment.GetSummary());

        // Now create the derived class assignments
        MathAssignment fractionsAssignment = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(fractionsAssignment.GetSummary());
        Console.WriteLine(fractionsAssignment.GetHomeworkList());

        WritingAssignment historyAssignment = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(historyAssignment.GetSummary());
        Console.WriteLine(historyAssignment.GetWritingInformation());
    }
}
