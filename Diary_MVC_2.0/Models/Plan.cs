using System;
using System.ComponentModel.DataAnnotations;

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

        [StringLength(40, MinimumLength = 3)]
        [RegularExpression(@"[\w""]+[a-zA-Z0-9\.\,\#\!\&\?\;\:\@()""'\s-]*")]
        public string Subject { get; set; }

        [Required]
        [Display(Name = "Start date and time")]
        public DateTime StartDateTime { get; set; }

        public bool IsPerformed { get; set; }
    }
}
