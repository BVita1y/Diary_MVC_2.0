using System;
using System.ComponentModel.DataAnnotations;

namespace Diary_MVC_2._0.Models
{
    public class Case : Reminder
    {
        [Display(Name = "Finish date\nand time")]
        public DateTime FinishDateTime { get; set; }
    }
}
