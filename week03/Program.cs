using System;
using System.Collections.Generic;

// EXCEEDING REQUIREMENTS:
// 1. Added a library of multiple scriptures. The program randomly selects one for the user to practice.
// 2. Upgraded the HideRandomWords logic in Scripture.cs to only select from words that are not already hidden.

class Program
{
    static void Main(string[] args)
    {
        // Setup a library of scriptures to choose from
        List<Scripture> scriptureLibrary = new List<Scripture>
        {
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart and lean not unto thine own understanding; In all thy ways acknowledge him, and he shall direct thy paths."),
            new Scripture(new Reference("John", 3, 16), "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
            new Scripture(new Reference("Moses", 1, 39), "For behold, this is my work and my glory—to bring to pass the immortality and eternal life of man.")
        };

        // Select a random scripture from the library
        Random random = new Random();
        int index = random.Next(scriptureLibrary.Count);
        Scripture currentScripture = scriptureLibrary[index];

        string userInput = "";

        // Main game loop
        while (userInput != "quit" && !currentScripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(currentScripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press enter to continue or type 'quit' to finish:");
            
            userInput = Console.ReadLine();

            if (userInput != "quit")
            {
                // Hide 3 words per enter press
                currentScripture.HideRandomWords(3);
            }
        }

        // Final output if the user successfully clears the entire board
        if (currentScripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(currentScripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("You successfully memorized it!");
        }
    }
}