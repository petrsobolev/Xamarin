using SQLite;
using System;
using SQLiteNetExtensions.Attributes;

namespace Goal.Model
{
    [Table("Tasks")]
    public class Task
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(Goal))]
        public int IdOfGoal { get; set; }

        public string ShortName { get; set; }
        public string Description { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime ReachOn { get; set; }
        public int PercentageOfCompletion { get; set; }
        public bool Done { get; set; }

        public Task()
        {
            StartAt = DateTime.Now;
            ReachOn = DateTime.Now;
        }

        public Task(int IdOfGoal, string ShortName, string Description, DateTime StartAt, DateTime ReachOn, int PercentageOfCompletion, bool Done)
        {
            this.IdOfGoal = IdOfGoal;
            this.ShortName = ShortName;
            this.Description = Description;
            this.StartAt = StartAt;
            this.ReachOn = ReachOn;
            this.PercentageOfCompletion = PercentageOfCompletion;
            this.Done = Done;
        }
    }
}
