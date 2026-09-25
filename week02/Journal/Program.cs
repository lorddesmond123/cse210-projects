using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What is one thing I learned today?"
        };

        int choice = 0;

        while (choice != 6)
        {
            Console.WriteLine("Welcome to the Journal Program!");
            Console.WriteLine($"You currently have {journal._entries.Count} entries.");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Write an entry with your own prompt");
            Console.WriteLine("6. Quit");
            Console.Write("What would you like to do? ");

            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Random random = new Random();
                string prompt = prompts[random.Next(prompts.Count)];
                Console.WriteLine(prompt);

                Console.Write("> ");
                string response = Console.ReadLine();

                string date = DateTime.Now.ToShortDateString();

                Entry entry = new Entry(date, prompt, response);
                journal.AddEntry(entry);
            }
            else if (choice == 2)
            {
                journal.DisplayAll();
            }
            else if (choice == 3)
            {
                Console.Write("Enter a filename: ");
                string filename = Console.ReadLine();

                journal.SaveToFile(filename);
                Console.WriteLine("Journal saved.");
            }
            else if (choice == 4)
            {
                Console.WriteLine("Warning: loading a file will replace your current entries.");
                Console.Write("Enter a filename: ");
                string filename = Console.ReadLine();

                journal.LoadFromFile(filename);
                Console.WriteLine("Journal loaded.");
            }
            else if (choice == 5)
            {
                Console.Write("Enter your own prompt: ");
                string prompt = Console.ReadLine();

                Console.Write("> ");
                string response = Console.ReadLine();

                string date = DateTime.Now.ToShortDateString();

                Entry entry = new Entry(date, prompt, response);
                journal.AddEntry(entry);
            }
        }
    }
}