using System;
using System.Collections.Generic;

static class PromptGenerator
{
    private static List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is a skill or hobby you want to develop further, and what steps will you take to improve it?",
        "Reflect on a recent conversation that challenged your perspective. What did you learn from it?",
        "Describe a place you've never been to but would love to visit someday. What draws you to that place?",
        "Think about a book or movie that deeply impacted you. How did it change your outlook or inspire you?",
        "Write about a memorable childhood experience that shaped who you are today.",
        "Consider a difficult decision you've had to make recently. What factors influenced your choice?",
        "Reflect on a time when you overcame a fear or obstacle. How did you feel afterward?",
        "Imagine yourself ten years from now. What do you hope to have accomplished by then?",
        "Describe a moment of unexpected kindness you witnessed or received. How did it affect you?",
        "Think about a goal you've set for yourself. What steps will you take to achieve it, and how will you measure your progress?"
    };

    public static string GenerateRandomPrompt()
    {
        Random rand = new Random();
        int index = rand.Next(prompts.Count);
        return prompts[index];
    }
}
