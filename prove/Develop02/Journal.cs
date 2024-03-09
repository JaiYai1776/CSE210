using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

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

    public void SaveJournalToJson(string filename)
    {
        try
        {
            string json = JsonConvert.SerializeObject(entries, Formatting.Indented);
            File.WriteAllText(filename, json);
            Console.WriteLine("Journal saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal: {ex.Message}");
        }
    }

    public void LoadJournalFromJson(string filename)
    {
        try
        {
            string json = File.ReadAllText(filename);
            entries = JsonConvert.DeserializeObject<List<Entry>>(json);
            Console.WriteLine("Journal loaded successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal: {ex.Message}");
        }
    }
}
