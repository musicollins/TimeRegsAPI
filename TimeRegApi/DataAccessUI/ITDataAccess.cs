using TimeRegApi.Model;
using System.Collections.Generic;

namespace TimeRegApi.UI.DataAccessUI
{
    public interface ITDataAccess
    {

        //PROJECT
        IEnumerable<Project> GetProjects();
        Project GetPById(int projectid);
        void AddP(Project project);
        void SavePAsync(Project project);
        void DeletePAsync(int projectid);


        //EMPLOYEE
        IEnumerable<Employee> GetEmployees();
        Employee GetEById(int employeeid);
        void AddE(Employee employee);
        void SaveEAsync(Employee employee);
        void DeleteEAsync(int employeeid);


        //TIME REPORT
        IEnumerable<TimeReport> GetTimeReports();
        TimeReport GetTById(int timeReportid);
        void AddT(TimeReport timeReport);
        void SaveTAsync(TimeReport timeReport);
        void DeleteTAsync(int timeReportid);
    }
}