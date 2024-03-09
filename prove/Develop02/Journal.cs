using System;
using System.Collections.Generic;

class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void WriteNewEntry()
    {
        string prompt = PromptGenerator.GenerateRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");
        Console.WriteLine("Enter your response:");
        string response = Console.ReadLine();
        entries.Add(new Entry(DateTime.Now.ToString(), prompt, response));
    }

    public void DisplayJournal()
    {
        foreach (Entry entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date}, Prompt: {entry.Prompt}, Response: {entry.Response}");
        }
    }

    public void SaveJournalToFile()
    {
        Console.WriteLine("Enter filename to save:");
        string filename = Console.ReadLine();
        // Code for saving journal to file
    }

    public void LoadJournalFromFile()
    {
        Console.WriteLine("Enter filename to load:");
        string filename = Console.ReadLine();
        // Code for loading journal from file
    }
}
