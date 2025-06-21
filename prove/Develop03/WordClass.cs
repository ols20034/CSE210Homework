class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }
    public string GetText() => _text;
    public bool IsHidden => _isHidden;
    public override string ToString()
    {
        return IsHidden ? "_____" : _text;
    }
}