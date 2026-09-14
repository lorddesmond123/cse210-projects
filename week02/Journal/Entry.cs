using System;

public class Entry
{
    private string _date;
    private string _promptText;
    private string _entryText;
    private string _mood;
    private int _gratitudeCount;

    public Entry(string date, string promptText, string entryText, string mood = "Neutral", int gratitudeCount = 0)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
        _mood = mood;
        _gratitudeCount = gratitudeCount;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Mood: {_mood}");
        if (_gratitudeCount > 0)
        {
            Console.WriteLine($"Things I am grateful for today: {_gratitudeCount}");
        }
        Console.WriteLine($"Response: {_entryText}");
        Console.WriteLine("--------------------------------------------------");
    }

    public string GetSaveString()
    {
        string safePrompt = _promptText.Replace("~|~", " ");
        string safeEntry = _entryText.Replace("~|~", " ");
        string safeMood = _mood.Replace("~|~", " ");

        return $"{_date}~|~{safePrompt}~|~{safeEntry}~|~{safeMood}~|~{_gratitudeCount}";
    }

    public static Entry CreateFromSaveString(string line)
    {
        string[] parts = line.Split(new string[] { "~|~" }, StringSplitOptions.None);

        if (parts.Length >= 5)
        {
            string date = parts[0];
            string prompt = parts[1];
            string entryText = parts[2];
            string mood = parts[3];
            int gratitude = 0;
            int.TryParse(parts[4], out gratitude);

            return new Entry(date, prompt, entryText, mood, gratitude);
        }
        else if (parts.Length >= 3)
        {
            return new Entry(parts[0], parts[1], parts[2]);
        }

        return new Entry(DateTime.Now.ToShortDateString(), "Unknown prompt", line);
    }

    public string GetGetDate() => _date;
    public string GetPrompt() => _promptText;
    public string GetEntryText() => _entryText;
    public string GetMood() => _mood;
    public int GetGratitudeCount() => _gratitudeCount;
}