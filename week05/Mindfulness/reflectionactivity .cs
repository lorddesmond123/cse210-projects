using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private Random _random;

    public ReflectionActivity()
        : base(
            "Reflection Activity",
            "This activity will help you reflect on times in your life when you have shown strength and resilience."
        )
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you overcame a challenge.",
            "Think of a time when you accomplished something important."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "What did you learn from this experience?",
            "How did you feel when it happened?",
            "What made this experience difficult?",
            "Who helped you during this experience?",
            "How did you show strength?",
            "What would you do differently next time?",
            "How has this experience changed you?",
            "What did you learn about yourself?",
            "How can you use what you learned in the future?"
        };

        _random = new Random();
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();

        int promptNumber = _random.Next(_prompts.Count);
        Console.WriteLine($"--- {_prompts[promptNumber]} ---");

        Console.WriteLine();
        Console.WriteLine("When you are ready, think about the prompt.");
        ShowSpinner(5);

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            int questionNumber = _random.Next(_questions.Count);

            Console.WriteLine();
            Console.WriteLine($"> {_questions[questionNumber]}");

            ShowSpinner(5);
        }

        DisplayEndingMessage();
    }
}