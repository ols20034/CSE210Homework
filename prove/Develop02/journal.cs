using System;

public class Journal
{
    public List<JournalEntry> Entries { get; set; } = new List<JournalEntry>();

    public void AddEntry(string prompt, string response)
    {
        string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        Entries.Add(new JournalEntry(date, prompt, response));
    }

    public void DisplayEntries()
    {
        Console.WriteLine("\nJournal Entries:");
        foreach (var entry in Entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in Entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
        Console.WriteLine("\nJournal saved successfully!");
    }

    public void LoadFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            Entries.Clear();
            foreach (var line in File.ReadLines(filename))
            {
                var parts = line.Split('|');
                if (parts.Length == 3)
                {
                    Entries.Add(new JournalEntry(parts[0], parts[1], parts[2]));
                }
            }
            Console.WriteLine("\nJournal loaded successfully!");
        }
        else
        {
            Console.WriteLine("\nFile not found.");
        }
    }
}