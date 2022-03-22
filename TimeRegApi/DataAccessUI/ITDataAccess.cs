using TimeRegApi.Model;
using System.Collections.Generic;

namespace TimeRegApi.UI.DataAccessUI
{
    public interface ITDataAccess
    {
        IEnumerable<Project> GetProjects();
        Project GetById(int projectid);
        void Add(Project project);
        void SaveAsync(Project project);
        void DeleteAsync(int projectid);
    }
}