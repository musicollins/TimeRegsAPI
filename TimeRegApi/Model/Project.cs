using System.ComponentModel.DataAnnotations;

namespace TimeRegApi.Model
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Company { get; set; }
        public DateTime Deadline { get; set; }
        public string GitHub { get; set; }
        public bool Aktiv { get; set; }

    }
}
