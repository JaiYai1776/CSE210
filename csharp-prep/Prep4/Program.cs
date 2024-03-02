using System;
using System.Collections.Generic; // Need to import List<T>

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>(); // Changed 'number' to 'int'
        Console.WriteLine("Enter a list of numbers, type 0 when finished");
        while (true)
        {
            int number = int.Parse(Console.ReadLine());
            if (number == 0)
            {
                break;
            }
            numbers.Add(number);
        }
        Console.WriteLine("The sum of the numbers is: " + Sum(numbers));
        Console.WriteLine("The average of the numbers is: " + Average(numbers));
        Console.WriteLine("The largest number is: " + Max(numbers));
        Console.WriteLine("The smallest positive number is: " + Min(numbers));
        Console.WriteLine("The sorted list of numbers is: " + Sort(numbers));
    }

    // Method to calculate sum
    static int Sum(List<int> numbers)
    {
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }
        return sum;
    }

    // Method to calculate average
    static double Average(List<int> numbers)
    {
        return (double)Sum(numbers) / numbers.Count;
    }

    // Method to find the maximum number
    static int Max(List<int> numbers)
    {
        return numbers.Count > 0 ? numbers.Max() : 0;
    }

    // Method to find the minimum positive number
    static int Min(List<int> numbers)
    {
        int min = int.MaxValue;
        foreach (int num in numbers)
        {
            if (num > 0 && num < min)
            {
                min = num;
            }
        }
        return min == int.MaxValue ? 0 : min;
    }

    // Method to sort the list
    static string Sort(List<int> numbers)
    {
        numbers.Sort();
        return string.Join(", ", numbers);
    }
}
