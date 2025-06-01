using System;

class ScriptureReference
{
    public string Book { get; }
    public int Chapter { get; }
    public int StartVerse { get; }
    public int? EndVerse { get; }

    // Overloaded constructor to accept a string reference (e.g., "John 3:16")
    public ScriptureReference(string reference)
    {
        var parts = reference.Split(new[] { ' ', ':', '-' }, StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length >= 3)
        {
            Book = parts[0];
            Chapter = int.Parse(parts[1]);
            StartVerse = int.Parse(parts[2]);
            EndVerse = parts.Length == 4 ? int.Parse(parts[3]) : (int?)null;
        }
        else
        {
            throw new ArgumentException("Invalid scripture reference format.");
        }
    }

    // Standard constructor for explicit reference creation
    public ScriptureReference(string book, int chapter, int startVerse, int? endVerse = null)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }

    public override string ToString()
    {
        return EndVerse.HasValue 
            ? $"{Book} {Chapter}:{StartVerse}-{EndVerse}" 
            : $"{Book} {Chapter}:{StartVerse}";
    }
}