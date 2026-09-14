using System;

/*
 * =============================================
 *  W02 Project: Journal Program
 * =============================================
 *
 * CREATIVITY & EXCEEDING CORE REQUIREMENTS
 * -----------------------------------------
 * 1. Mood tracking – every entry can optionally record the user's mood.
 * 2. Gratitude counter – users can record how many things they are
 *    grateful for that day (encourages positive reflection).
 * 3. Search functionality – users can search past entries by keyword.
 * 4. Journal statistics – shows total entries, total gratitude items,
 *    and mood distribution.
 * 5. Dedicated PromptGenerator class – clean separation of concerns
 *    (more than the required two classes beyond Program).
 * 6. Robust file handling with a rare separator (~|~) and backward-
 *    compatible loading.
 * 7. Friendly error messages and empty-journal checks.
 * 8. Extra original prompts beyond the five required examples.
 */

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        Console.WriteLine("Welcome to the Journal Program!");
        Console.WriteLine("This program helps you build a consistent journaling habit.\n");

        bool running = true;
        while (running)
        {
            DisplayMenu();
            Console.Write("What would you like to do? ");
            string choice = Console.ReadLine()?.Trim() ?? "";

            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal, promptGenerator);
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                    SaveJournal(journal);
                    break;
                case "4":
                    LoadJournal(journal);
                    break;
                case "5":
                    SearchJournal(journal);
                    break;
                case "6":
                    journal.DisplayStats();
                    break;
                case "7":
                    promptGenerator.DisplayAllPrompts();
                    break;
                case "8":
                    running = false;
                    Console.WriteLine("Thank you for journaling today. Keep the habit going!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please enter a number from 1 to 8.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("Please select one of the following choices:");
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display the journal");
        Console.WriteLine("3. Save the journal to a file");
        Console.WriteLine("4. Load the journal from a file");
        Console.WriteLine("5. Search entries by keyword");
        Console.WriteLine("6. Show journal statistics");
        Console.WriteLine("7. List all available prompts");
        Console.WriteLine("8. Quit");
    }

    static void WriteNewEntry(Journal journal, PromptGenerator promptGenerator)
    {
        string prompt = promptGenerator.GetRandomPrompt();
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.Write("> ");
        string response = Console.ReadLine() ?? "";

        Console.Write("How are you feeling today? (e.g., Happy, Grateful, Tired, Anxious) [optional]: ");
        string mood = Console.ReadLine()?.Trim();
        if (string.IsNullOrWhiteSpace(mood))
        {
            mood = "Neutral";
        }

        Console.Write("How many things are you grateful for today? (number, or press Enter for 0): ");
        string gratitudeInput = Console.ReadLine()?.Trim() ?? "0";
        int gratitudeCount = 0;
        int.TryParse(gratitudeInput, out gratitudeCount);
        if (gratitudeCount < 0) gratitudeCount = 0;

        string date = DateTime.Now.ToShortDateString();
        Entry newEntry = new Entry(date, prompt, response, mood, gratitudeCount);
        journal.AddEntry(newEntry);

        Console.WriteLine("Entry added successfully!");
    }

    static void SaveJournal(Journal journal)
    {
        Console.Write("Enter the filename to save (e.g., myJournal.txt): ");
        string filename = Console.ReadLine()?.Trim() ?? "journal.txt";
        if (string.IsNullOrWhiteSpace(filename))
        {
            filename = "journal.txt";
        }
        journal.SaveToFile(filename);
    }

    static void LoadJournal(Journal journal)
    {
        Console.Write("Enter the filename to load: ");
        string filename = Console.ReadLine()?.Trim() ?? "";
        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("No filename provided.");
            return;
        }
        journal.LoadFromFile(filename);
    }

    static void SearchJournal(Journal journal)
    {
        Console.Write("Enter a keyword to search for: ");
        string keyword = Console.ReadLine()?.Trim() ?? "";
        journal.SearchEntries(keyword);
    }
}