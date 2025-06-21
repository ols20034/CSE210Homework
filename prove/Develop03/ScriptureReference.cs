using System;
using System.Linq;

class ScriptureReference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int? _endVerse;

    // Constructor to accept a string reference (e.g., "John 3:16")
    public ScriptureReference(string reference)
    {
        var parts = reference.Split(new[] { ' ', ':', '-' }, StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length < 3)
        {
            throw new ArgumentException($"Invalid scripture reference format: {reference}");
        }

        _book = string.Join(" ", parts.Take(parts.Length - 2));
        _chapter = int.Parse(parts[parts.Length - 2]);
        _startVerse = int.Parse(parts[parts.Length - 1]);
        _endVerse = parts.Length == 4 ? int.Parse(parts[parts.Length - 1]) : (int?)null;
    }

    // Constructor for explicit values
    public ScriptureReference(string book, int chapter, int startVerse, int? endVerse = null)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    // Public getter methods (used only if needed)
    public string GetBook() => _book;
    public int GetChapter() => _chapter;
    public int GetStartVerse() => _startVerse;
    public int? GetEndVerse() => _endVerse;

    public override string ToString()
    {
        return _endVerse.HasValue
            ? $"{_book} {_chapter}:{_startVerse}-{_endVerse}"
            : $"{_book} {_chapter}:{_startVerse}";
    }
}