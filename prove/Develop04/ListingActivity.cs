using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {

    }

    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "What experiences have helped you feel the Holy Ghost recently?",
        "Who are some of your personal heroes?"
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();

        int index = random.Next(_prompts.Count);

        return _prompts[index];
    }

    public void Run()
    {
        StartMessage();

        Console.WriteLine();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();
        Console.WriteLine(GetRandomPrompt());

        Console.WriteLine();
        Console.WriteLine("You may begin in:");
        ShowCountDown(5);

        Console.WriteLine();
        Console.WriteLine("Start listing items below.");

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        int count = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(response))
            {
                count++;
            }
        }

        Console.WriteLine();
        Console.WriteLine("You listed " + count + " items.");

        EndMessage();
    }
}