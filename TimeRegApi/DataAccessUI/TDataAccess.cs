using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TimeRegApi.Data;
using TimeRegApi.Model;

namespace TimeRegApi.UI.DataAccessUI
{
    public class TDataAccess : ITDataAccess
    {
        private readonly TRDbContext _tRDbContext;

        public TDataAccess(TRDbContext tRDbContext)
        {
            _tRDbContext = tRDbContext;
        }

        //PROJECT
        public IEnumerable<Project> GetProjects()
        {
            return _tRDbContext.Projects.ToList();
        }

        public Project GetPById(int projectid)
        {
            return _tRDbContext.Projects.AsNoTracking().Single(e => e.ProjectId == projectid);
        }

        public void SavePAsync(Project project)
        {
            //Retrieve the object first, then update it!
            var b = _tRDbContext.Projects.SingleOrDefault(p => p.ProjectId == project.ProjectId);
            //CloneIt Method exists in the book model for the purposes of updating object
            //before it is saved into the database
            b.CloneIt(project);

            //_tRDbContext.Entry(project).State = EntityState.Modified;
            _tRDbContext.SaveChanges();
        }

        public void DeletePAsync(int projectid)
        {
            var b = _tRDbContext.Projects.SingleOrDefault(p => p.ProjectId == projectid);

            _tRDbContext.Projects.Remove(b);
            _tRDbContext.SaveChanges();
        }

        public void AddP(Project project)
        {
            _tRDbContext.Projects.Add(project);

            var b = _tRDbContext.Projects.SingleOrDefault(p => p.ProjectId == project.ProjectId);

            _tRDbContext.SaveChanges();
        }


        //EMPLOYEE
        public IEnumerable<Employee> GetEmployees()
        {
            return _tRDbContext.Employees.ToList();
        }

        public Employee GetEById(int employeeid)
        {
            return _tRDbContext.Employees.AsNoTracking().Single(e => e.EmployeeId == employeeid);
        }

        public void SaveEAsync(Employee employee)
        {
            //Retrieve the object first, then update it!
            var b = _tRDbContext.Employees.SingleOrDefault(p => p.EmployeeId == employee.EmployeeId);
            //CloneIt Method exists in the book model for the purposes of updating object
            //before it is saved into the database
            b.CloneIt(employee);

            //_tDbContext.Entry(book).State = EntityState.Modified;
            _tRDbContext.SaveChanges();
        }

        public void DeleteEAsync(int employeeid)
        {
            var b = _tRDbContext.Employees.SingleOrDefault(p => p.EmployeeId == employeeid);

            _tRDbContext.Employees.Remove(b);
            _tRDbContext.SaveChanges();
        }

        public void AddE(Employee employee)
        {
            _tRDbContext.Employees.Add(employee);

            var b = _tRDbContext.Employees.SingleOrDefault(p => p.EmployeeId == employee.EmployeeId);

            _tRDbContext.SaveChanges();
        }


        //TIMEREPORT    
        public IEnumerable<TimeReport> GetTimeReports()
        {
            return _tRDbContext.TimeReports.ToList();
        }

        public TimeReport GetTById(int timeReportid)
        {
            return _tRDbContext.TimeReports.AsNoTracking().Single(e => e.TimeReportId == timeReportid);
        }

        public void SaveTAsync(TimeReport timeReport)
        {
            //Retrieve the object first, then update it!
            var b = _tRDbContext.TimeReports.SingleOrDefault(p => p.TimeReportId == timeReport.TimeReportId);
            //CloneIt Method exists in the book model for the purposes of updating object
            //before it is saved into the database
            b.CloneIt(timeReport);

            //_tDbContext.Entry(book).State = EntityState.Modified;
            _tRDbContext.SaveChanges();
        }

        public void DeleteTAsync(int timeReportid)
        {
            var b = _tRDbContext.TimeReports.SingleOrDefault(p => p.TimeReportId == timeReportid);

            _tRDbContext.TimeReports.Remove(b);
            _tRDbContext.SaveChanges();
        }

        public void AddT(TimeReport timeReport)
        {
            _tRDbContext.TimeReports.Add(timeReport);

            var b = _tRDbContext.TimeReports.SingleOrDefault(p => p.TimeReportId == timeReport.TimeReportId);

            _tRDbContext.SaveChanges();
        }
    }
}
