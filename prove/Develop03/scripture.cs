public class Scripture
{
    private ScriptureReference _reference;
    private string _text;
    private List<ScriptureWord> _words;

    public Scripture(ScriptureReference reference, string text)
    {
        _reference = reference;
        _text = text;
        _words = _text.Split(' ').Select(word => new ScriptureWord(word)).ToList();
    }

    public ScriptureReference Reference
    {
        get { return _reference; }
    }

    public string Text
    {
        get { return _text; }
    }

    public bool AllWordsHidden()
    {
        return _words.All(word => word.IsHidden);
    }

    public void HideRandomWords(int count)
    {
        if (count <= 0)
            return; // Return early if count is zero or negative

        // Count the number of visible words
        int visibleWordCount = _words.Count(word => !word.IsHidden);

        // If there are no visible words remaining, return early
        if (visibleWordCount == 0)
            return;

        // Adjust the count to ensure at least one word is hidden
        count = Math.Max(count, 1);

        Random random = new Random();
        List<int> indices = Enumerable.Range(0, _words.Count)
                                       .Where(index => !_words[index].IsHidden) // Select indices of visible words only
                                       .OrderBy(x => random.Next())
                                       .Take(count)
                                       .ToList();

        foreach (int index in indices)
        {
            _words[index].Hide();
        }
    }

    public string Display()
    {
        return $"{_reference}: {string.Join(" ", _words.Select(word => word.IsHidden ? "___" : word.Text))}";
    }
}
