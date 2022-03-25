using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeRegApi.Model
{
    public class Project
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Company { get; set; }
        public DateTime Deadline { get; set; }
        public string GitHub { get; set; }
        public bool Aktiv { get; set; }

        public void CloneIt(Project project)
        {
            ProjectName = project.ProjectName;
            Company = project.Company;
            Deadline = project.Deadline;
            GitHub = project.GitHub;
            Aktiv = project.Aktiv;
        }

        //public ICollection<TimeReport> TimeReports { get; set; }
    }
}
