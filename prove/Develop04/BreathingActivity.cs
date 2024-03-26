// Breathing Activity class inheriting from Activity
class BreathingActivity : Activity
{
public BreathingActivity(int duration) : base(duration)
{
}

public override void StartActivity()
{
base.StartActivity();
Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
Console.WriteLine("Let's begin:");
   SpinAnimation(5);

DateTime endTime = DateTime.Now.AddSeconds(duration);

while (DateTime.Now < endTime)
{
Console.WriteLine("Breathe in...");
VisualAnimation("..ooOO");
Console.WriteLine("Breathe out...");
VisualAnimation("OOoo..");

if (DateTime.Now < endTime)
{
  // Wait for a second between cycles if the time is remaining
  Thread.Sleep(1000);
}
}

EndActivity();
}

// Method to create visual animation
private void VisualAnimation(string symbols)
{
foreach (char symbol in symbols)
{
Console.Write(symbol);
Thread.Sleep(1000);
}
Console.WriteLine();
}
}
