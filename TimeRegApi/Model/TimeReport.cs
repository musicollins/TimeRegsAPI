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

        public void CloneIt(TimeReport timeReport)
        {
            EducationHours = timeReport.EducationHours;
            PreperationHours = timeReport.PreperationHours;
            Other = timeReport.Other;
            AfterHours = timeReport.AfterHours;
            Comment = timeReport.Comment;
        }

        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
