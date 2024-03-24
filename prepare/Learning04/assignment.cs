public class Assignment
{
    protected string _studentName; // Changed to protected to allow access in derived classes
    protected string _topic; // Changed to protected to allow access in derived classes

    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }
}