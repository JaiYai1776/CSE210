using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

//For extras I added a leveling system that checks your total points and levels you up based on the amount of points you have.
//I also added a feature to remove completed items from the list and add them to a completed list. (This feature currently does 
// not save the completed goals to the save file only shows them in current session and will be lost when the program is closed.)
class Program
{
    static List<Goal> CompletedGoals = new List<Goal>();
    public static void ListGoals(List<Goal> Goals)
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < Goals.Count; i++)
        {
            Console.Write($"{i + 1}.");
            Goals[i].ListGoal();
        }
    }

    static void WriteString(string value, bool newLine = false, int speed = 10)
    {
        foreach (char character in value)
        {
            Console.Write(character);
            Thread.Sleep(speed);
        }
        if (newLine)
        {
            Console.WriteLine();
        }
    }

    static void ViewCompletedGoals()
    {
        Console.WriteLine("\nCompleted Goals:");
        if (CompletedGoals.Count == 0)
        {
            Console.WriteLine("No goals have been completed yet.");
        }
        else
        {
            for (int i = 0; i < CompletedGoals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {CompletedGoals[i].GetName()}");
            }
        }
    }
    static void SaveGoals(List<Goal> goals, List<Goal> completedGoals, string fileName)
    {
        int level = 0;
        double points = 0;
        using StreamWriter file = new StreamWriter(fileName);
        file.WriteLine(points + ":" + level);
        foreach (var goal in goals)
        {
            file.WriteLine(goal.SerializeSelf());
        }
        foreach (var completedGoal in CompletedGoals)
        {
            file.WriteLine(completedGoal.SerializeSelf());
        }
    }
public static int LevelUp(int level, double points)
{
    int newLevel = level;

    switch (level)
    {
        case 1:
            if (points >= 10) { newLevel = 2; }
            break;
        case 2:
            if (points >= 12) { newLevel = 3; }
            break;
        case 3:
            if (points >= 48) { newLevel = 4; }
            break;
        case 4:
            if (points >= 130) { newLevel = 5; }
            break;
        case 5:
            if (points >= 283) { newLevel = 6; }
            break;
        case 6:
            if (points >= 537) { newLevel = 7; }
            break;
        case 7:
            if (points >= 922) { newLevel = 8; }
            break;
        case 8:
            if (points >= 1472) { newLevel = 9; }
            break;
        case 9:
            if (points >= 2225) { newLevel = 10; }
            break;
        case 10:
            if (points >= 3219) { newLevel = 11; }
            break;
        case 11:
            if (points >= 4497) { newLevel = 12; }
            break;
        case 12:
            if (points >= 6101) { newLevel = 13; }
            break;
        case 13:
            if (points >= 8079) { newLevel = 14; }
            break;
        case 14:
            if (points >= 10477) { newLevel = 15; }
            break;
        case 15:
            if (points >= 13346) { newLevel = 16; }
            break;
        case 16:
            if (points >= 16736) { newLevel = 17; }
            break;
        case 17:
            if (points >= 20701) { newLevel = 18; }
            break;
        case 18:
            if (points >= 25297) { newLevel = 19; }
            break;
        case 19:
            if (points >= 30580) { newLevel = 20; }
            break;
        case 20:
            if (points >= 36608) { newLevel = 21; }
            break;
        case 21:
            if (points >= 43440) { newLevel = 22; }
            break;
        case 22:
            if (points >= 51140) { newLevel = 23; }
            break;
        case 23:
            if (points >= 59769) { newLevel = 24; }
            break;
        case 24:
            if (points >= 69392) { newLevel = 25; }
            break;
        case 25:
            if (points >= 80074) { newLevel = 26; }
            break;
        case 26:
            if (points >= 91884) { newLevel = 27; }
            break;
        case 27:
            if (points >= 104890) { newLevel = 28; }
            break;
        case 28:
            if (points >= 119161) { newLevel = 29; }
            break;
        case 29:
            if (points >= 134769) { newLevel = 30; }
            break;
        case 30:
            if (points >= 151787) { newLevel = 31; }
            break;
        case 31:
            if (points >= 170288) { newLevel = 32; }
            break;
        case 32:
            if (points >= 190348) { newLevel = 33; }
            break;
        case 33:
            if (points >= 212043) { newLevel = 34; }
            break;
        case 34:
            if (points >= 235451) { newLevel = 35; }
            break;
        case 35:
            if (points >= 260651) { newLevel = 36; }
            break;
        case 36:
            if (points >= 287722) { newLevel = 37; }
            break;
        case 37:
            if (points >= 316746) { newLevel = 38; }
            break;
        case 38:
            if (points >= 347806) { newLevel = 39; }
            break;
        case 39:
            if (points >= 380984) { newLevel = 40; }
            break;
        case 40:
            if (points >= 416365) { newLevel = 41; }
            break;
        case 41:
            if (points >= 454036) { newLevel = 42; }
            break;
        case 42:
            if (points >= 494082) { newLevel = 43; }
            break;
        case 43:
            if (points >= 536592) { newLevel = 44; }
            break;
        case 44:
            if (points >= 581655) { newLevel = 45; }
            break;
        case 45:
            if (points >= 629361) { newLevel = 46; }
            break;
        case 46:
            if (points >= 679800) { newLevel = 47; }
            break;
        case 47:
            if (points >= 733066) { newLevel = 48; }
            break;
        case 48:
            if (points >= 789250) { newLevel = 49; }
            break;
        case 49:
            if (points >= 848448) { newLevel = 50; }
            break;
        case 50:
            if (points >= 910754) { newLevel = 51; }
            break;
        case 51:
            if (points >= 1045077) { newLevel = 52; }
            break;
        case 52:
            if (points >= 1117288) { newLevel = 53; }
            break;
        case 53:
            if (points >= 1192999) { newLevel = 54; }
            break;
        case 54:
            if (points >= 1272308) { newLevel = 55; }
            break;
        case 55:
            if (points >= 1355317) { newLevel = 56; }
            break;
        case 56:
            if (points >= 1442127) { newLevel = 57; }
            break;
        case 57:
            if (points >= 1532842) { newLevel = 58; }
            break;
        case 58:
            if (points >= 1627565) { newLevel = 59; }
            break;
        case 59:
            if (points >= 1726400) { newLevel = 60; }
            break;
        case 60:
            if (points >= 1829454) { newLevel = 61; }
            break;
        case 61:
            if (points >= 1936832) { newLevel = 62; }
            break;
        case 62:
            if (points >= 2048643) { newLevel = 63; }
            break;
        case 63:
            if (points >= 2164993) { newLevel = 64; }
            break;
        case 64:
            if (points >= 2285993) { newLevel = 65; }
            break;
        case 65:
            if (points >= 2411752) { newLevel = 66; }
            break;
        case 66:
            if (points >= 2542381) { newLevel = 67; }
            break;
        case 67:
            if (points >= 2677992) { newLevel = 68; }
            break;
        case 68:
            if (points >= 2818698) { newLevel = 69; }
            break;
        case 69:
            if (points >= 2964611) { newLevel = 70; }
            break;
        case 70:
            if (points >= 3115845) { newLevel = 71; }
            break;
        case 71:
            if (points >= 3272517) { newLevel = 72; }
            break;
        case 72:
            if (points >= 3434741) { newLevel = 73; }
            break;
        case 73:
            if (points >= 3602635) { newLevel = 74; }
            break;
        case 74:
            if (points >= 3776316) { newLevel = 75; }
            break;
        case 75:
            if (points >= 3955902) { newLevel = 76; }
            break;
        case 76:
            if (points >= 4141512) { newLevel = 77; }
            break;
        case 77:
            if (points >= 4333266) { newLevel = 78; }
            break;
        case 78:
            if (points >= 4531285) { newLevel = 79; }
            break;
        case 79:
            if (points >= 4735691) { newLevel = 80; }
            break;
        case 80:
            if (points >= 4946606) { newLevel = 81; }
            break;
        case 81:
            if (points >= 5164152) { newLevel = 82; }
            break;
        case 82:
            if (points >= 5388453) { newLevel = 83; }
            break;
        case 83:
            if (points >= 5619635) { newLevel = 84; }
            break;
        case 84:
            if (points >= 5857822) { newLevel = 85; }
            break;
        case 85:
            if (points >= 6103141) { newLevel = 86; }
            break;
        case 86:
            if (points >= 6355719) { newLevel = 87; }
            break;
        case 87:
            if (points >= 6615682) { newLevel = 88; }
            break;
        case 88:
            if (points >= 6883160) { newLevel = 89; }
            break;
        case 89:
            if (points >= 7158281) { newLevel = 90; }
            break;
        case 90:
            if (points >= 7441176) { newLevel = 91; }
            break;
        case 91:
            if (points >= 7731975) { newLevel = 92; }
            break;
        case 92:
            if (points >= 8030809) { newLevel = 93; }
            break;
        case 93:
            if (points >= 8337811) { newLevel = 94; }
            break;
        case 94:
            if (points >= 8653112) { newLevel = 95; }
            break;
        case 95:
            if (points >= 8976848) { newLevel = 96; }
            break;
        case 96:
            if (points >= 9309151) { newLevel = 97; }
            break;
        case 97:
            if (points >= 9650156) { newLevel = 98; }
            break;
        case 98:
            if (points >= 10000000) { newLevel = 99; }
            break;
        case 99:
            if (points >= 10358819) { newLevel = 100; }
            break;
    }

    Console.WriteLine($"New level: {newLevel}");
    if (level < newLevel)
    {
        WriteString($"Congratulations! You are Level {newLevel}!", true);
    }
    return newLevel;
}


 static void Main(string[] args)
    {
        int input;
        List<Goal> Goals = new List<Goal>();
        double points = 0;
        int level = 1;
        string name = "";

        while (true)
        {
            Console.WriteLine($"\nWelcome to the Goal Tracker! You are Level {level} and have {points} points.");
            level = LevelUp(level, points);
            Console.WriteLine("Menu Items:\n"
                            + "\t1. Create New Goal\n"
                            + "\t2. List Goals\n"
                            + "\t3. Save Goals\n"
                            + "\t4. Load Goals\n"
                            + "\t5. Record Event\n"
                            + "\t6. View Completed Goals (This feature does not save the completed goals only shows them in current session)\n"
                            + "\t7. Quit");
            Console.Write("Select a choice from the menu:");
            input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Console.WriteLine("The types of Goals are:\n"
                            + "\t1. Simple Goal\n"
                            + "\t2. Eternal Goal\n"
                            + "\t3. Checklist Goal");
                    Console.Write("Which type of goal would you like to create? ");
                    input = int.Parse(Console.ReadLine());
                    switch (input)
                    {
                        case 1:
                            Goals.Add(new Simple());
                            break;
                        case 2:
                            Goals.Add(new Eternal());
                            break;
                        case 3:
                            Goals.Add(new Checklist());
                            break;
                    }
                    break;
                case 2:
                    ListGoals(Goals);
                    break;
                case 3:
                    Console.Write("What would you like to name the file? ");
                    name = Console.ReadLine() + ".txt";
                    using (StreamWriter file = new StreamWriter(name))
                    {
                        file.WriteLine(points + ":" + level);
                        for (int i = 0; i < Goals.Count; i++)
                        {
                            file.WriteLine(Goals[i].SerializeSelf());
                        }
                    }
                    break;
                case 4:
                    if (name == "")
                    {
                        Console.WriteLine("Please enter the filename(leave out the extension. Ex.: .txt): ");
                        name = Console.ReadLine() + ".txt";
                    }
                    if (File.Exists(name))
                    {
                        string[] lines = File.ReadAllLines(name);
                        points = double.Parse(lines[0].Split(":")[0]);
                        level = int.Parse(lines[0].Split(":")[1]);
                        for (int i = 1; i < lines.Length; i++)
                        {
                            string[] values = lines[i].Split(":");
                            switch (values[0])
                            {
                                case "simple":
                                    Goals.Add(new Simple(values[1], values[2], double.Parse(values[3]), int.Parse(values[4])));
                                    break;
                                case "eternal":
                                    Goals.Add(new Eternal(values[1], values[2], double.Parse(values[3]), int.Parse(values[4])));
                                    break;
                                case "checklist":
                                    Goals.Add(new Checklist(values[1], values[2], double.Parse(values[3]), int.Parse(values[4]), int.Parse(values[5]), int.Parse(values[6])));
                                    break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("File does not exist!");
                    }
                    break;
                case 5:
                    ListGoals(Goals);
                    Console.Write("\nWhich goal did you accomplish? ");
                    input = int.Parse(Console.ReadLine());
                    points += Goals[input - 1].RecordEvent();
                    if (Goals[input - 1].IsComplete())
                    {
                        CompletedGoals.Add(Goals[input - 1]);
                        Goals.RemoveAt(input - 1);
                    }
                    break;
                case 6:
                    ViewCompletedGoals();
                    break;
                case 7:
                    return;
            }
            // WriteString($"\nYou have {points} points.", true);
        }
    }
}
