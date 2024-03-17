using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> _scriptures = LoadScripturesFromFile("scriptures.txt");

        if (_scriptures.Count == 0)
        {
            Console.WriteLine("No scriptures found in the file.");
            return;
        }

        Random _random = new Random();
        Scripture _randomScripture = _scriptures[_random.Next(_scriptures.Count)];

        while (!_randomScripture.AllWordsHidden())
        {
            Console.Clear();
            Console.WriteLine(_randomScripture.Display());
            Console.WriteLine("Press Enter to hide another 3 words or type 'quit' to exit.");
            string _input = Console.ReadLine();

            if (_input.ToLower() == "quit")
                return;

            _randomScripture.HideRandomWords(3);
        }

        Console.Clear();
        Console.WriteLine("All words in the scripture are hidden.");
    }

    static List<Scripture> LoadScripturesFromFile(string filePath)
    {
        List<Scripture> _scriptures = new List<Scripture>();

        try
        {
            string[] _lines = File.ReadAllLines(filePath);

            foreach (string _line in _lines)
            {
                string[] _parts = _line.Split(new char[] { ' ' }, 2);
                if (_parts.Length == 2)
                {
                    string _reference = _parts[0];
                    string _text = _parts[1];
                    _scriptures.Add(new Scripture(new ScriptureReference(_reference), _text));
                }
            }
        }
        catch (Exception _ex)
        {
            Console.WriteLine($"Error loading scriptures from file: {_ex.Message}");
        }

        return _scriptures;
    }
}
