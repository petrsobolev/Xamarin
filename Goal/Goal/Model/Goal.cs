using SQLite;
using System;

namespace Goal.Model
{
    [Table("Goals")]
    public class Goal
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string ShortName { get; set; }
        public string Description { get; set; }
        public DateTime ReachOn { get; set; }
        public bool Enable { get; set; }

        public Goal()
        {
            ReachOn = DateTime.Now;
        }

        public Goal(string ShortName, string Description, DateTime ReachOn, bool Enable)
        {
            this.ShortName = ShortName;
            this.Description = Description;
            this.ReachOn = ReachOn;
            this.Enable = Enable;
        }
    }
}
