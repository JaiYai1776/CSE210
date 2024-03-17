public class ScriptureReference
{
    private string _reference;

    public ScriptureReference(string reference)
    {
        _reference = reference;
    }

    public override string ToString()
    {
        return _reference;
    }
}
