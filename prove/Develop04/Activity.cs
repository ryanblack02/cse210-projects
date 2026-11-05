using System;
using System.Collections.Generic;
using System.Threading;

public class Activity
{
    private string _activityName;
    private string _description;
    private int _duration;

    public Activity(string activityName, string description)
    {
        _activityName = activityName;
        _description = description;
    }

    public void StartMessage()
    {
        Console.Clear();

        Console.WriteLine($"Welcome to the {_activityName}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    public void ShowSpinner(int seconds)
    {
        List<string> animation = new List<string>();
        animation.Add("|");
        animation.Add("/");
        animation.Add("-");
        animation.Add("\\");

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        int i = 0;

        while (DateTime.Now < endTime)
        {
            string symbol = animation[i];
            Console.Write(symbol);
            Thread.Sleep(250);
            Console.Write("\b \b");

            i++;

            if (i >= animation.Count)
            {
                i = 0;
            }
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public void EndMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Good job!");
        Console.WriteLine("You have completed another " + _duration + " seconds of the " + _activityName + ".");
        ShowSpinner(3);
        Console.WriteLine();
    }

    public int GetDuration()
    {
        return _duration;
    }
}
