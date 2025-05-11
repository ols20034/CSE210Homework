using System;

public class JournalPrompt
{
    private List<string> prompts = new List<string>
    {
        "What made you smile today?",
        "Describe a moment you felt proud.",
        "What was the biggest challenge you faced today?",
        "What is something you’re grateful for?",
        "Reflect on a decision you made today.",
        "Describe a moment that you helped someone.",
    };

    public string GetPrompt()
    {
        Random rand = new Random();
        return prompts[rand.Next(prompts.Count)];
    }
}