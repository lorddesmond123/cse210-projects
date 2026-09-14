using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is one thing I learned about myself today?",
        "Who did I help or serve today, and how did it make me feel?",
        "What challenge did I face and how did I respond?",
        "What am I looking forward to tomorrow?",
        "What small moment brought me joy today?",
        "How did I take care of my physical or mental health today?",
        "What is one thing I am proud of accomplishing today?"
    };

    private Random _random = new Random();

    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }

    public void DisplayAllPrompts()
    {
        Console.WriteLine("\nAvailable prompts:");
        for (int i = 0; i < _prompts.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_prompts[i]}");
        }
        Console.WriteLine();
    }
}