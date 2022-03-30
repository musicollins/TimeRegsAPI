using Microsoft.EntityFrameworkCore;

namespace TimeRegApi.Model
{
    public static class DataSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasData(
                new Project { ProjectId = 1, ProjectName = "Test", Company = "Aveer", GitHub = "Länk", Aktiv = true },
                new Project { ProjectId = 2, ProjectName = "Testing", Company = "Aveer", GitHub = "Länk 2", Aktiv = false }
                );
            modelBuilder.Entity<TimeReport>().HasData(
                new TimeReport { TimeReportId = 1, AfterHours = 2, Comment = "Testing", EmployeeId = 1, ProjectId = 2 },
                new TimeReport { TimeReportId = 2, PreperationHours = 5, Comment = "Testing2", EmployeeId = 2, ProjectId = 1 }
                );
            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeId = 1, FirstName = "Filip", LastName = "Lindberg", PhoneNumber = 112, Email = "Test@test.se", Password = "112233" },
                new Employee { EmployeeId = 2, FirstName = "Andre", LastName = "Lindqvist", PhoneNumber = 112, Email = "Test2@test.se", Password = "332211" }
                );
        }
    }
}
