using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts;
    private Random _random;

    public ListingActivity()
        : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can."
        )
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are things you are grateful for?",
            "What are personal strengths you have?",
            "What are things that make you happy?",
            "What are good memories you have?",
            "What are things you enjoy doing?"
        };

        _random = new Random();
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();

        int promptNumber = _random.Next(_prompts.Count);
        Console.WriteLine($"--- {_prompts[promptNumber]} ---");

        Console.WriteLine();
        Console.WriteLine("You have 5 seconds to get ready.");
        ShowCountDown(5);

        Console.WriteLine();
        Console.WriteLine("Start listing your answers.");

        int count = 0;
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string answer = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(answer))
            {
                count++;
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {count} items.");

        DisplayEndingMessage();
    }
}