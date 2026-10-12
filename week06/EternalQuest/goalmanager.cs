using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool running = true;

        while (running)
        {
            DisplayPlayerStatus();

            Console.WriteLine();
            Console.WriteLine("Menu Options");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");

            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;

                case "2":
                    ListGoalNames();
                    break;

                case "3":
                    SaveGoals();
                    break;

                case "4":
                    LoadGoals();
                    break;

                case "5":
                    RecordEvent();
                    break;

                case "6":
                    running = false;
                    Console.WriteLine("Thank you for using Eternal Quest!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private void DisplayPlayerStatus()
    {
        Console.WriteLine("------------------------------------------");
        Console.WriteLine($"Your current score is: {_score}");
        Console.WriteLine($"Quest Level: {GetLevel()}");
        Console.WriteLine("------------------------------------------");
    }

    private int GetLevel()
    {
        return (_score / 500) + 1;
    }

    private void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");

        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = GetIntegerInput();

        if (type == "1")
        {
            SimpleGoal goal =
                new SimpleGoal(name, description, points);

            _goals.Add(goal);

            Console.WriteLine("Simple goal created successfully!");
        }
        else if (type == "2")
        {
            EternalGoal goal =
                new EternalGoal(name, description, points);

            _goals.Add(goal);

            Console.WriteLine("Eternal goal created successfully!");
        }
        else if (type == "3")
        {
            Console.Write("How many times does this goal need to be completed? ");
            int target = GetIntegerInput();

            Console.Write("What is the bonus for completing it? ");
            int bonus = GetIntegerInput();

            ChecklistGoal goal =
                new ChecklistGoal(
                    name,
                    description,
                    points,
                    target,
                    bonus);

            _goals.Add(goal);

            Console.WriteLine("Checklist goal created successfully!");
        }
        else
        {
            Console.WriteLine("Invalid goal type.");
        }
    }

    private void ListGoalNames()
    {
        Console.WriteLine("The goals are:");

        if (_goals.Count == 0)
        {
            Console.WriteLine("You do not have any goals yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine(
                $"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    private void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You do not have any goals to record.");
            return;
        }

        ListGoalNames();

        Console.Write("Which goal did you accomplish? ");
        int choice = GetIntegerInput();

        if (choice < 1 || choice > _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        Goal selectedGoal = _goals[choice - 1];

        if (selectedGoal is SimpleGoal &&
            selectedGoal.IsComplete())
        {
            Console.WriteLine(
                "That goal has already been completed.");

            return;
        }

        if (selectedGoal is ChecklistGoal &&
            selectedGoal.IsComplete())
        {
            Console.WriteLine(
                "That checklist goal is already complete.");

            return;
        }

        int oldLevel = GetLevel();

        selectedGoal.RecordEvent();

        int earnedPoints = selectedGoal.GetPoints();

        _score += earnedPoints;

        Console.WriteLine();
        Console.WriteLine(
            $"Congratulations! You earned {earnedPoints} points.");

        if (selectedGoal is ChecklistGoal checklistGoal)
        {
            if (checklistGoal.IsComplete())
            {
                _score += checklistGoal.GetBonus();

                Console.WriteLine(
                    "You completed the checklist goal!");

                Console.WriteLine(
                    $"Bonus earned: {checklistGoal.GetBonus()} points.");
            }
        }

        Console.WriteLine($"Your new score is: {_score}");

        int newLevel = GetLevel();

        if (newLevel > oldLevel)
        {
            Console.WriteLine();
            Console.WriteLine(
                $"*** LEVEL UP! You are now Level {newLevel}! ***");

            Console.WriteLine(
                "Keep going on your Eternal Quest!");
        }
    }

    private void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile =
               new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(
                    goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully.");
    }

    private void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        if (lines.Length == 0)
        {
            Console.WriteLine("The file is empty.");
            return;
        }

        _goals.Clear();

        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            Goal goal = CreateGoalFromString(lines[i]);

            if (goal != null)
            {
                _goals.Add(goal);
            }
        }

        Console.WriteLine("Goals loaded successfully.");
    }

    private Goal CreateGoalFromString(string line)
    {
        string[] parts = line.Split('|');

        string type = parts[0];

        if (type == "SimpleGoal")
        {
            string name = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);
            bool isComplete = bool.Parse(parts[4]);

            return new SimpleGoal(
                name,
                description,
                points,
                isComplete);
        }

        if (type == "EternalGoal")
        {
            string name = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);

            return new EternalGoal(
                name,
                description,
                points);
        }

        if (type == "ChecklistGoal")
        {
            string name = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);
            int amountCompleted = int.Parse(parts[4]);
            int target = int.Parse(parts[5]);
            int bonus = int.Parse(parts[6]);

            return new ChecklistGoal(
                name,
                description,
                points,
                amountCompleted,
                target,
                bonus);
        }

        return null;
    }

    private int GetIntegerInput()
    {
        int number;

        while (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.Write("Please enter a valid number: ");
        }

        return number;
    }
}