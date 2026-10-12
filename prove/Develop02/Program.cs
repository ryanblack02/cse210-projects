using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        string choice = "";

        while (choice != "6")
        {
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Statistics");
            Console.WriteLine("6. Quit");
            Console.Write("What would you like to do? ");

            choice = Console.ReadLine();

            if (choice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();

                Console.WriteLine(prompt);
                Console.Write("> ");
                string response = Console.ReadLine();

                string date = DateTime.Now.ToShortDateString();

                Entry entry = new Entry(date, prompt, response);
                journal.AddEntry(entry);

                Console.WriteLine("Entry added!");
                Console.WriteLine();
            }
            else if (choice == "2")
            {
                journal.Display();
            }
            else if (choice == "3")
            {
                Console.Write("Enter the filename: ");
                string filename = Console.ReadLine();

                journal.SaveToFile(filename);

                Console.WriteLine("Journal saved successfully!");
            }
            else if (choice == "4")
            {
                Console.Write("Enter the filename: ");
                string filename = Console.ReadLine();

                journal.LoadFromFile(filename);

                Console.WriteLine("Journal loaded successfully!");
                Console.WriteLine();
            }
            else if (choice == "5")
            {
                // Creativity enhancement: Journal Statistics displays the total number of entries.
                Console.WriteLine($"Total journal entries: {journal.GetEntryCount()}");
                Console.WriteLine();
            }
            else if (choice == "6")
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                // Creativity enhancement: Helps users recover from invalid menu choices.
                Console.WriteLine("Invalid choice. Please try again.");
                Console.WriteLine();
            }
        }
    }
}