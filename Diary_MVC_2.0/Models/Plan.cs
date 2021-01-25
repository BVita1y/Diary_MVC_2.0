using System;

namespace Diary_MVC_2._0.Models
{
    public class Plan
    {
        public enum PlanType
        {
            Reminder,
            Case,
            Meeting
        }

        public int Id { get; set; }
        public PlanType Type { get; set; }
        public string Subject { get; set; }
        public DateTime StartDateTime { get; set; }
        public bool IsPerformed { get; set; }
    }
}
