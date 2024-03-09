using System;

public enum Mood
{
    Happy,
    Sad,
    Excited,
    Calm,
    Angry,
    Anxious,
    Content,
    Stressed,
    Other
}

public class MoodTracker
{
    public Mood CurrentMood { get; private set; }

    public MoodTracker()
    {
        // By default, set the mood to "Other"
        CurrentMood = Mood.Other;
    }

    public void SetMood(Mood mood)
    {
        CurrentMood = mood;
    }

    public void DisplayCurrentMood()
    {
        Console.WriteLine($"Current mood: {CurrentMood}");
    }
}
