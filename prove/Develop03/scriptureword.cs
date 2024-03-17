public class ScriptureWord
{
    private string text;
    private bool isHidden;

    public ScriptureWord(string text)
    {
        this.text = text;
        isHidden = false;
    }

    public string Text
    {
        get { return text; }
    }

    public bool IsHidden
    {
        get { return isHidden; }
    }

    public void Hide()
    {
        isHidden = true;
    }
}