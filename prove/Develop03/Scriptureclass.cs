class Scripture
{
    public ScriptureReference Reference { get; }
    private List<Word> Words;

    public Scripture(ScriptureReference reference, string text)
    {
        Reference = reference;
        Words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void HideRandomWords(int count)
    {
        Random random = new Random();
        List<Word> visibleWords = Words.Where(word => !word.IsHidden).ToList();

        if (visibleWords.Count == 0) return;

        for (int i = 0; i < count && visibleWords.Count > 0; i++)
        {
            Word wordToHide = visibleWords[random.Next(visibleWords.Count)];
            wordToHide.Hide();
            visibleWords.Remove(wordToHide);
        }
    }

    public override string ToString()
    {
        return $"{Reference}\n" + string.Join(" ", Words);
    }

    public bool AllWordsHidden()
    {
        return Words.All(word => word.IsHidden);
    }
}