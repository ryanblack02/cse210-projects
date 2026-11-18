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

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Your score is {_score} points.");

        if (_score >= 5000)
        {
            Console.WriteLine("Achievement: Eternal Champion!");
        }
        else if (_score >= 2000)
        {
            Console.WriteLine("Achievement: Master of Discipline!");
        }
        else if (_score >= 1000)
        {
            Console.WriteLine("Achievement: Dedicated Adventurer!");
        }
        else if (_score >= 500)
        {
            Console.WriteLine("Achievement: First Steps!");
        }
        else
        {
            Console.WriteLine("Achievement: Just Getting Started!");
        }
    }

    public void DisplayGoals()
    {
        Console.WriteLine("The goals are:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }


    public void RecordEvent(int goalNumber)
    {
        if (goalNumber < 1 || goalNumber > _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        Goal goal = _goals[goalNumber - 1];

        if (goal.IsComplete())
        {
            Console.WriteLine("This goal has already been completed.");
            return;
        }

        goal.RecordEvent();

        _score += goal.GetPoints();

        Console.WriteLine($"You earned {goal.GetPoints()} points!");

        if (goal is ChecklistGoal)
        {
            ChecklistGoal checklist = (ChecklistGoal)goal;

            if (checklist.IsComplete())
            {
                _score += checklist.GetBonus();

                Console.WriteLine($"Congratulations! You earned an additional {checklist.GetBonus()} bonus points!");
            }
        }
    }


    public void SaveGoals(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine($"Score|{_score}");

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetSaveString());
            }
        }

        Console.WriteLine("Goals saved successfully!");
    }


    public void LoadGoals(string filename)
    {
        string[] lines = File.ReadAllLines(filename);

        _goals.Clear();

        foreach (string line in lines)
        {
            string[] parts = line.Split("|");

            if (parts[0] == "Score")
            {
                _score = int.Parse(parts[1]);
            }
            else if (parts[0] == "SimpleGoal")
            {
                SimpleGoal goal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));

                goal.SetComplete(bool.Parse(parts[4]));

                _goals.Add(goal);
            }
            else if (parts[0] == "EternalGoal")
            {
                EternalGoal goal = new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));

                _goals.Add(goal);
            }
            else if (parts[0] == "ChecklistGoal")
            {
                ChecklistGoal goal = new ChecklistGoal(
                    parts[1],
                    parts[2],
                    int.Parse(parts[3]),
                    int.Parse(parts[5]),
                    int.Parse(parts[6])
                );

                goal.SetAmountCompleted(int.Parse(parts[4]));

                _goals.Add(goal);
            }
        }

        Console.WriteLine("Goals loaded successfully!");
    }
}