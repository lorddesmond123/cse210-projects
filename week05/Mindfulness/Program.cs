using System;

class Program
{
    static void Main(string[] args)
    {
        // Creativity:
        // I added random prompts and questions to make each activity
        // different each time the user runs it.
        //
        // I also created reusable spinner and countdown methods in the
        // Activity class so I do not have to repeat the same animation
        // code in every activity.
        //
        // The program also keeps the three activities organized using
        // inheritance.

        while (true)
        {
            Console.Clear();

            Console.WriteLine("Mindfulness Program");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflection activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.WriteLine();

            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity activity = new BreathingActivity();
                activity.Run();
            }
            else if (choice == "2")
            {
                ReflectionActivity activity = new ReflectionActivity();
                activity.Run();
            }
            else if (choice == "3")
            {
                ListingActivity activity = new ListingActivity();
                activity.Run();
            }
            else if (choice == "4")
            {
                Console.WriteLine("Thank you for using the Mindfulness Program.");
                break;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Invalid choice. Please choose 1, 2, 3, or 4.");
                Console.WriteLine();
                Console.Write("Press Enter to continue...");
                Console.ReadLine();
            }
        }
    }
}