using System.ComponentModel.DataAnnotations;

namespace Diary_MVC_2._0.Models
{
    public class Meeting : Case
    {
        [RegularExpression(@"[\w""]+[a-zA-Z0-9\.\,\#\!\&\?\;\:\@()""'\s-]*")]
        public string Place { get; set; }
    }
}
