using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace Diary_MVC_2._0.Models
{
    public class PlansViewModel
    {
        public enum DAYSLIMIT
        {
            list,
            day,
            week,
            month,
        }

        public List<Plan> Plans { get; set; }
        public SelectList Types { get; set; }

        public string PlanType { get; set; }
        public DAYSLIMIT Limit { get; set; }
        public DateTime? SelectedDate { get; set; }
        public string KeyPhrase { get; set; }
    }
}
