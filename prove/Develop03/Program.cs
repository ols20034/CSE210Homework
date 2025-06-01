using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Intrinsics.X86;

class Program
{
    static string filePath = "scriptures.csv";

    static void Main()
    {
        Console.WriteLine("Welcome to the Scripture Memorization Program!");
        Console.WriteLine("Please enter menu number of what you want to do: ");

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Add a new scripture to memorize");
            Console.WriteLine("2. Memorize a stored scripture");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option (1-3): ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                AddScripture();
            }
            else if (choice == "2")
            {
                MemorizeScripture();
            }
            else if (choice == "3")
            {
                Console.WriteLine("Goodbye, thanks for using Scripture Memorization Program");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }

    static void AddScripture()
    {
        Console.Write("Enter scripture reference (e.g., Alma 3:15): ");
        string reference = Console.ReadLine();

        Console.Write("Enter scripture text: ");
        string text = Console.ReadLine();

        SaveToCsv(reference, text);
        Console.WriteLine("Scripture saved successfully!");
    }

    static void SaveToCsv(string reference, string text)
    {
        using (StreamWriter writer = new StreamWriter(filePath, append: true))
        {
            writer.WriteLine($"{reference},\"{text}\"");
        }
    }

    static void MemorizeScripture()
    {
        List<Scripture> scriptures = LoadScriptures();

        if (scriptures.Count == 0)
        {
            Console.WriteLine("No scriptures stored. Add some first!");
            return;
        }

        Console.WriteLine("\nStored Scriptures:");
        for (int i = 0; i < scriptures.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {scriptures[i].Reference}");
        }

        Console.Write("Select a scripture to memorize (number): ");
        if (!int.TryParse(Console.ReadLine(), out int selection) || selection < 1 || selection > scriptures.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        Scripture scripture = scriptures[selection - 1];

        // adding difficulty level of 1 - 5 random words disappear.
        Console.Write("\nChoose how many words to hide per step (1-5): ");
        int wordsToHide;
        while (!int.TryParse(Console.ReadLine(), out wordsToHide) || wordsToHide < 1 || wordsToHide > 5)
        {
            Console.Write("Invalid input. Enter a number between 1  and 5: ");
        }

        while (!scripture.AllWordsHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture);
            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");

            string input = Console.ReadLine();
            if (input.ToLower() == "quit") break;

            scripture.HideRandomWords(wordsToHide); // user selected random number of words disappear.

            if (scripture.AllWordsHidden())
            {
                Console.Clear();
                Console.WriteLine("Congratulations! You've memorized this scripture!");
            }
        }

        static List<Scripture> LoadScriptures()
        {
            List<Scripture> scriptures = new List<Scripture>();

            if (File.Exists(filePath))
            {
                foreach (string line in File.ReadLines(filePath))
                {
                    string[] parts = line.Split(new[] { ',' }, 2);
                    if (parts.Length == 2)
                    {
                        ScriptureReference reference = new ScriptureReference(parts[0]);
                        Scripture scripture = new Scripture(reference, parts[1].Trim('"'));
                        scriptures.Add(scripture);
                    }
                }
            }

            return scriptures;
        }
    }
}