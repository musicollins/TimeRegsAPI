using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeRegApi.Data;
using TimeRegApi.Model;
using TimeRegApi.UI.DataAccessUI;

namespace TimeRegApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        //private readonly TRDbContext _context;
        //public ProjectsController(TRDbContext context)
        //{
        //    _context = context;
        //}

        //[HttpGet]
        //public async Task<ActionResult<List<Project>>> Get()
        //{
        //    return await _context.Projects.ToListAsync();
        //}

        //[HttpGet("{projectid}")]
        //public async Task<ActionResult<Project>> Get(int projectid)
        //{
        //    var project = await _context.Projects.FindAsync(projectid);

        //    if (project == null)
        //    {
        //        return NotFound();
        //    }

        //    return project;
        //}

        //[HttpPost]
        //public async Task<ActionResult<List<Project>>> Create(Project project)
        //{
        //    _context.Projects.Add(project);
        //    await _context.SaveChangesAsync();

        //    return await _context.Projects.ToListAsync();
        //}

        //[HttpPut]
        //public async Task<ActionResult<List<Project>>> Update(Project request)
        //{
        //    var dbProject = await _context.Projects.FindAsync(request.ProjectId);

        //    if (dbProject == null)
        //    {
        //        return NotFound();
        //    }

        //    dbProject.ProjectName = request.ProjectName;
        //    dbProject.Company = request.Company;
        //    dbProject.Deadline = request.Deadline;
        //    dbProject.GitHub = request.GitHub;
        //    dbProject.Aktiv = request.Aktiv;

        //    await _context.SaveChangesAsync();

        //    return await _context.Projects.ToListAsync();
        //}

        //[HttpDelete("prpjectid")]
        //public async Task<ActionResult<List<Project>>> Delete(int projectid)
        //{
        //    var dbProject = await _context.Projects.FindAsync(projectid);

        //    if (dbProject == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Projects.Remove(dbProject);
        //    await _context.SaveChangesAsync();

        //    return await _context.Projects.ToListAsync();
        //}



        private readonly TDataAccess dataAccess;

        public ProjectsController(TDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        [HttpGet]
        public async Task<ActionResult<List<Project>>> Get()
        {
            return Ok(dataAccess.GetProjects());
        }

        [HttpGet("{projectId}")]
        public async Task<ActionResult<Project>> GetById(int projectId)
        {
            var project = dataAccess.GetPById(projectId);
            if (project == null)
                return NotFound("Project not found");
            return Ok(project);
        }

        [HttpPost]
        public async Task<ActionResult<List<Project>>> AddProject(Project project)
        {
            dataAccess.AddP(project);
            return Ok(dataAccess.GetProjects());
        }

        [HttpPut]
        public async Task<ActionResult<List<Project>>> UpdateProject(Project p)
        {
            var project = dataAccess.GetPById(p.ProjectId);
            if (project == null)
                return NotFound("Project not found");

            //project.ProjectName = p.ProjectName;
            //project.Company = p.Company;
            //project.Deadline = p.Deadline;
            //project.GitHub = p.GitHub;
            //project.Aktiv = p.Aktiv;
            dataAccess.SavePAsync(project);

            return Ok(dataAccess.GetProjects());
        }

        [HttpDelete("{projectId}")]
        public async Task<ActionResult<List<Project>>> Delete(int projectId)
        {
            var project = dataAccess.GetPById(projectId);
            if (project == null)
                return NotFound("Project not found");

            dataAccess.DeletePAsync(projectId);

            return Ok(dataAccess.GetProjects());
        }
    }
}
