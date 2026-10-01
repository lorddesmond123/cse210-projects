using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Creativity: I added a library containing multiple scriptures
        // and randomly select one scripture each time the program starts.
        // This gives the user a different scripture to memorize
        // instead of always using the same scripture.

        // Create a list of scriptures
        List<Scripture> scriptureLibrary = new List<Scripture>
        {
            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."
            ),

            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."
            ),

            new Scripture(
                new Reference("Moses", 1, 39),
                "For behold, this is my work and my glory—to bring to pass the immortality and eternal life of man."
            )
        };

        // Creativity feature: Randomly select one scripture from
        // the scripture library each time the program runs.
        Random random = new Random();
        int index = random.Next(scriptureLibrary.Count);

        Scripture currentScripture = scriptureLibrary[index];

        string userInput = "";

        // Main game loop
        while (userInput.ToLower() != "quit" &&
               !currentScripture.IsCompletelyHidden())
        {
            // Display the scripture
            Console.WriteLine(currentScripture.GetDisplayText());

            Console.WriteLine();
            Console.WriteLine("Press Enter to continue or type 'quit' to finish:");

            userInput = Console.ReadLine() ?? "";

            // Hide some words when the user presses Enter
            if (userInput.ToLower() != "quit")
            {
                currentScripture.HideRandomWords(3);
            }

            Console.WriteLine();
        }

        // Final message
        if (currentScripture.IsCompletelyHidden())
        {
            Console.WriteLine("All words have been hidden. Great job!");
        }
        else
        {
            Console.WriteLine("Goodbye!");
        }
    }
}