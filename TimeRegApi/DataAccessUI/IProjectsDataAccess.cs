using TimeRegApi.Model;
using System.Collections.Generic;

namespace TimeRegApi.UI.DataAccessUI
{
    public interface IProjectsDataAccess
    {
        //PROJECT
        IEnumerable<Project> GetProjects();
        Project GetPById(int projectid);
        void AddP(Project project);
        void SavePAsync(Project project);
        void DeletePAsync(int projectid);
    }
}