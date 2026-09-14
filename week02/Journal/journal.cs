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

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is empty. Write an entry first!");
            return;
        }

        Console.WriteLine("\n========== YOUR JOURNAL ==========\n");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
        Console.WriteLine($"Total entries: {_entries.Count}\n");
    }

    public void SaveToFile(string filename)
    {
        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    outputFile.WriteLine(entry.GetSaveString());
                }
            }
            Console.WriteLine($"Journal successfully saved to '{filename}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }

    public void LoadFromFile(string filename)
    {
        try
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine($"File '{filename}' does not exist.");
                return;
            }

            string[] lines = File.ReadAllLines(filename);
            _entries.Clear();

            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    Entry entry = Entry.CreateFromSaveString(line);
                    _entries.Add(entry);
                }
            }

            Console.WriteLine($"Journal successfully loaded from '{filename}'. ({_entries.Count} entries)");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
        }
    }

    public void SearchEntries(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
        {
            Console.WriteLine("Please enter a search term.");
            return;
        }

        keyword = keyword.ToLower();
        int found = 0;

        Console.WriteLine($"\n--- Search results for \"{keyword}\" ---\n");
        foreach (Entry entry in _entries)
        {
            if (entry.GetEntryText().ToLower().Contains(keyword) ||
                entry.GetPrompt().ToLower().Contains(keyword))
            {
                entry.Display();
                found++;
            }
        }

        if (found == 0)
        {
            Console.WriteLine("No matching entries found.");
        }
        else
        {
            Console.WriteLine($"Found {found} matching entr{(found == 1 ? "y" : "ies")}.");
        }
    }

    public void DisplayStats()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries yet – stats will appear after you write some!");
            return;
        }

        int totalGratitude = 0;
        Dictionary<string, int> moodCount = new Dictionary<string, int>();

        foreach (Entry e in _entries)
        {
            totalGratitude += e.GetGratitudeCount();

            string mood = e.GetMood();
            if (moodCount.ContainsKey(mood))
                moodCount[mood]++;
            else
                moodCount[mood] = 1;
        }

        Console.WriteLine("\n========== JOURNAL STATS ==========");
        Console.WriteLine($"Total entries        : {_entries.Count}");
        Console.WriteLine($"Total gratitude items: {totalGratitude}");
        Console.WriteLine("Mood distribution:");
        foreach (var pair in moodCount)
        {
            Console.WriteLine($"  {pair.Key}: {pair.Value}");
        }
        Console.WriteLine("===================================\n");
    }

    public int GetEntryCount() => _entries.Count;
}