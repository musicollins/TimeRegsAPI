using System.ComponentModel.DataAnnotations;

namespace TimeRegApi.Model
{
    public class TimeReport
    {
        [Key]
        public int TimeReportId { get; set; }
        public int EducationHours { get; set; }
        public int PreperationHours { get; set; }
        public int Other { get; set; }
        public int AfterHours { get; set; }
        public string Comment { get; set; }

    }
}
