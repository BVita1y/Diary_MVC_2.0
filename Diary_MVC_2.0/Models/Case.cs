using System;
using System.ComponentModel.DataAnnotations;

namespace Diary_MVC_2._0.Models
{
    public class Case : Reminder
    {
        [Display(Name = "End date and time")]
        public DateTime FinishDateTime { get; set; }
    }
}
