using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = LoadScripturesFromFile("scriptures.txt");

        if (scriptures.Count == 0)
        {
            Console.WriteLine("No scriptures found in the file.");
            return;
        }

        Random random = new Random();
        Scripture randomScripture = scriptures[random.Next(scriptures.Count)];

        while (!randomScripture.AllWordsHidden())
        {
            Console.Clear();
            Console.WriteLine(randomScripture.Display());
            Console.WriteLine("Press Enter to hide another 3 words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                return;

            randomScripture.HideRandomWords(3);
        }

        Console.Clear();
        Console.WriteLine("All words in the scripture are hidden.");
    }

    static List<Scripture> LoadScripturesFromFile(string filePath)
    {
        List<Scripture> scriptures = new List<Scripture>();

        try
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split(new char[] { ' ' }, 2);
                if (parts.Length == 2)
                {
                    string reference = parts[0];
                    string text = parts[1];
                    scriptures.Add(new Scripture(new ScriptureReference(reference), text));
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading scriptures from file: {ex.Message}");
        }

        return scriptures;
    }
}
