using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a scripture reference and a scripture
        ScriptureReference reference = new ScriptureReference("John", 3, 16);
        Scripture scripture = new Scripture(reference, "For God so loved the world that he gave his only begotten Son");

        // Display the reference and the text
        Console.WriteLine(scripture.GetReference());
        Console.WriteLine(scripture);

        // Hide a few words and display the result
        scripture.HideRandomWords(3);
        Console.WriteLine("\nAfter hiding words:");
        Console.WriteLine(scripture);
    }
}