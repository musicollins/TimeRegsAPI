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
        public IEnumerable<Project> GetProjects()
        {
            return _tRDbContext.Projects.ToList();
        }

        public Project GetById(int projectid)
        {
            return _tRDbContext.Projects.AsNoTracking().Single(e => e.ProjectId == projectid);
        }

        public void SaveAsync(Project project)
        {
            //Retrieve the object first, then update it!
            var b = _tRDbContext.Projects.SingleOrDefault(p => p.ProjectId == project.ProjectId);
            //CloneIt Method exists in the book model for the purposes of updating object
            //before it is saved into the database
            b.CloneIt(project);
            
            //_tDbContext.Entry(book).State = EntityState.Modified;
            _tRDbContext.SaveChanges();
        }

        public void DeleteAsync(int projectid)
        {
            var b = _tRDbContext.Projects.SingleOrDefault(p => p.ProjectId == projectid);

            _tRDbContext.Projects.Remove(b);
            _tRDbContext.SaveChanges();
        }

        public void Add(Project project)
        {
            _tRDbContext.Projects.Add(project);
            var b = _tRDbContext.Projects.SingleOrDefault(p => p.ProjectId == project.ProjectId);
        }
    }
}
