using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Creativity: I added an Achievement Milestone system.
        // Players earn different achievement titles as their score increases.
        // This gives players extra motivation to continue completing goals.
        GoalManager manager = new GoalManager();

        string filename = "goals.txt";

        bool running = true;

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("Eternal Quest Program");
            Console.WriteLine("---------------------");
            Console.WriteLine("1. Create Simple Goal");
            Console.WriteLine("2. Create Eternal Goal");
            Console.WriteLine("3. Create Checklist Goal");
            Console.WriteLine("4. Display Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Display Score");
            Console.WriteLine("7. Save Goals");
            Console.WriteLine("8. Load Goals");
            Console.WriteLine("9. Quit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    CreateSimpleGoal(manager);
                    break;

                case "2":
                    CreateEternalGoal(manager);
                    break;

                case "3":
                    CreateChecklistGoal(manager);
                    break;

                case "4":
                    manager.DisplayGoals();
                    break;

                case "5":
                    manager.DisplayGoals();

                    Console.Write("Which goal did you accomplish? ");
                    int goalNumber = int.Parse(Console.ReadLine());

                    manager.RecordEvent(goalNumber);
                    break;

                case "6":
                    manager.DisplayScore();
                    break;

                case "7":
                    manager.SaveGoals(filename);
                    break;

                case "8":
                    if (File.Exists(filename))
                    {
                        manager.LoadGoals(filename);
                    }
                    else
                    {
                        Console.WriteLine("No saved goals were found.");
                    }
                    break;

                case "9":
                    running = false;
                    Console.WriteLine("Good luck on your Eternal Quest!");
                    break;

                default:
                    Console.WriteLine("Please enter a valid menu option.");
                    break;
            }
        }
    }

    static void CreateSimpleGoal(GoalManager manager)
    {
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description? ");
        string description = Console.ReadLine();

        Console.Write("How many points is this goal worth? ");
        int points = int.Parse(Console.ReadLine());

        SimpleGoal goal = new SimpleGoal(name, description, points);

        manager.AddGoal(goal);

        Console.WriteLine("Simple goal created successfully!");
    }

    static void CreateEternalGoal(GoalManager manager)
    {
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description? ");
        string description = Console.ReadLine();

        Console.Write("How many points is this goal worth? ");
        int points = int.Parse(Console.ReadLine());

        EternalGoal goal = new EternalGoal(name, description, points);

        manager.AddGoal(goal);

        Console.WriteLine("Eternal goal created successfully!");
    }

    static void CreateChecklistGoal(GoalManager manager)
    {
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description? ");
        string description = Console.ReadLine();

        Console.Write("How many points is this goal worth? ");
        int points = int.Parse(Console.ReadLine());

        Console.Write("How many times must you complete this goal? ");
        int target = int.Parse(Console.ReadLine());

        Console.Write("How many bonus points will you receive? ");
        int bonus = int.Parse(Console.ReadLine());

        ChecklistGoal goal = new ChecklistGoal(
            name,
            description,
            points,
            target,
            bonus
        );

        manager.AddGoal(goal);

        Console.WriteLine("Checklist goal created successfully!");
    }
}
