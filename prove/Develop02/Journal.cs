using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public int GetEntryCount()
    {
        return _entries.Count;
    }

    public void Display()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
            Console.WriteLine();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry.GetDate()}|{entry.GetPrompt()}|{entry.GetResponse()}");
            }
        }
    }
    
    public void LoadFromFile(string filename)
    {
        _entries.Clear();

        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');

            string date = parts[0];
            string prompt = parts[1];
            string response = parts[2];

            Entry entry = new Entry(date, prompt, response);
            _entries.Add(entry);
        }
    }
}