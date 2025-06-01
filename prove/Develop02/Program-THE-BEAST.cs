using System;

class Program
{
    static void Main()
    {
        Journal myJournal = new Journal();
        JournalPrompt promptGen = new JournalPrompt();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nJournal Menu: Please choose an option");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display all entries");
            Console.WriteLine("3. Save entries to a file");
            Console.WriteLine("4. Load entries from a file");
            Console.WriteLine("5. Exit");
            
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGen.GetPrompt();
                    Console.WriteLine($"\nPrompt: {prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();
                    myJournal.AddEntry(prompt, response);
                    break;

                case "2":
                    myJournal.DisplayEntries();
                    break;

                case "3":
                    Console.Write("\nEnter filename to save: ");
                    string saveFile = Console.ReadLine();
                    myJournal.SaveToFile(saveFile);
                    break;

                case "4":
                    Console.Write("\nEnter filename to load: ");
                    string loadFile = Console.ReadLine();
                    myJournal.LoadFromFile(loadFile);
                    break;

                case "5":
                    running = false;
                    Console.WriteLine("\nGoodbye!");
                    break;

                default:
                    Console.WriteLine("\nInvalid choice, please try again.");
                    break;
            }
        }
    }
}