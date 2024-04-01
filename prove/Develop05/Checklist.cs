using System; 
  public class Checklist : Goal
      {
          private int _reachBonus;
          private int _bonusPoints;

          public Checklist() : base()
          {
              this._reachBonus = SetReachBonus();
              this._bonusPoints = SetBonusPoints();
          }
          public Checklist(string name, string description, double points, int timesFinished, int reach, int bonus) :
              base(name, description, points, timesFinished)
          {
              this._reachBonus = reach;
              this._bonusPoints = bonus;
          }

          protected int SetReachBonus()
          {
              Console.Write("How many times does this goal need to be accomplished for a bonus? ");
              return int.Parse(Console.ReadLine());
          }
          protected int SetBonusPoints()
          {
              Console.Write("What is the bonus for accomplishing it that many times?");
              return int.Parse(Console.ReadLine());
          }
          public override int GetReachBonus()
          {
              return this._reachBonus;
          }
          public override int GetBonusPoints()
          {
              return this._bonusPoints;
          }

          public override void ListGoal()
          {
              base.ListGoal();
              Console.Write($" --- Currently completed: {this._timesCompleted}/{this._reachBonus}\n");
          }
          public override bool IsComplete()
          {
              if (this._timesCompleted >= this._reachBonus)
              {
                  return true;
              }
              else
              {
                  return false;
              }
          }
          public override double RecordEvent()
          {
              base.RecordEvent();
              if (IsComplete())
              {
                  return AwardPoints(this._bonusPoints + this._points);
              }
              else
              {
                  return AwardPoints(this._points);
              }
          }
          public override string SerializeSelf()
          {
              return "checklist:" + base.SerializeSelf() + $":{this.GetReachBonus()}:{this.GetBonusPoints()}";
          }
      }