using System;

class Program
{
    static void Main(string[] args)
    {
        // Creativity: The program provides a library of three scriptures.
        // The user can choose a passage before beginning memorization.

        Console.WriteLine("Welcome to Scripture Memorizer!");
        Console.WriteLine();
        Console.WriteLine("Choose a scripture to memorize:");
        Console.WriteLine("1. Proverbs 3:5-6 - Trust in the Lord");
        Console.WriteLine("2. John 3:16 - God's love for the world");
        Console.WriteLine("3. Alma 37:6 - Great things from small means");
        Console.WriteLine();
        Console.Write("Enter your choice (1-3): ");

        string choice = Console.ReadLine();

        Reference reference;
        string text;

        if (choice == "1")
        {
            reference = new Reference("Proverbs", 3, 5, 6);
            text = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";
        }
        else if (choice == "2")
        {
            reference = new Reference("John", 3, 16);
            text = "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";
        }
        else if (choice == "3")
        {
            reference = new Reference("Alma", 37, 6);
            text = "Now ye may suppose that this is foolishness in me; but behold I say unto you, that by small and simple things are great things brought to pass; and small means in many instances doth confound the wise.";
        }
        else
        {
            Console.WriteLine("Invalid choice. Please run the program again and select 1, 2, or 3.");
            return;
        }

        Scripture scripture = new Scripture(reference, text);

        string input = "";

        while (input != "quit" && !scripture.AllWordsHidden())
        {
            Console.Clear();

            Console.WriteLine(scripture.GetDisplayText());

            Console.WriteLine();
            Console.WriteLine("Press Enter to hide more words, or type 'quit' to exit.");

            input = Console.ReadLine();

            if (input != "quit" && !scripture.AllWordsHidden())
            {
                scripture.HideRandomWords(3);
            }
        }

        Console.Clear();
        Console.WriteLine("Good job practicing your scripture!");
    }
}
