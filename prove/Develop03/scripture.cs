public class Scripture
{
    private ScriptureReference reference;
    private string text;
    private List<ScriptureWord> words;

    public Scripture(ScriptureReference reference, string text)
    {
        this.reference = reference;
        this.text = text;
        words = text.Split(' ').Select(word => new ScriptureWord(word)).ToList();
    }

    public ScriptureReference Reference
    {
        get { return reference; }
    }

    public string Text
    {
        get { return text; }
    }

    public bool AllWordsHidden()
    {
        return words.All(word => word.IsHidden);
    }

   public void HideRandomWords(int count)
{
    if (count <= 0)
        return; // Return early if count is zero or negative

    // Count the number of visible words
    int visibleWordCount = words.Count(word => !word.IsHidden);

    // If there are no visible words remaining, return early
    if (visibleWordCount == 0)
        return;

    // Adjust the count to ensure at least one word is hidden
    count = Math.Max(count, 1);

    Random random = new Random();
    List<int> indices = Enumerable.Range(0, words.Count)
                                   .Where(index => !words[index].IsHidden) // Select indices of visible words only
                                   .OrderBy(x => random.Next())
                                   .Take(count)
                                   .ToList();

    foreach (int index in indices)
    {
        words[index].Hide();
    }
}


    public string Display()
    {
        return $"{reference}: {string.Join(" ", words.Select(word => word.IsHidden ? "___" : word.Text))}";
    }
}