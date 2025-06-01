using System;

class ScriptureReference
{
    public string Book { get; }
    public int Chapter { get; }
    public int StartVerse { get; }
    public int? EndVerse { get; }

    // constructor to accept a string reference (e.g., "John 3:16")
    public ScriptureReference(string reference)
{
    var parts = reference.Split(new[] { ' ', ':', '-' }, StringSplitOptions.RemoveEmptyEntries);
    if (parts.Length < 3)
    {
        throw new ArgumentException($"Invalid scripture reference format: {reference}");
    }

    // Extract the book name dynamically
    Book = string.Join(" ", parts.Take(parts.Length - 2)); // All but last two parts
    Chapter = int.Parse(parts[parts.Length - 2]); // Second-to-last part
    StartVerse = int.Parse(parts[parts.Length - 1]); // Last part
    EndVerse = parts.Length == 4 ? int.Parse(parts[parts.Length - 1]) : (int?)null;
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