public class ScriptureWord
{
    private string _text;
    private bool _isHidden;

    public ScriptureWord(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public string Text
    {
        get { return _text; }
    }

    public bool IsHidden
    {
        get { return _isHidden; }
    }

    public void Hide()
    {
        _isHidden = true;
    }
}
