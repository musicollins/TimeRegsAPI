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
            var project = dataAccess.GetById(projectId);
            if (project == null)
                return NotFound("Project not found");
            return Ok(project);
        }

        [HttpPost]
        public async Task<ActionResult<List<Project>>> AddProject(Project project)
        {
            dataAccess.Add(project);
            return Ok(dataAccess.GetProjects());
        }

        [HttpPut]
        public async Task<ActionResult<List<Project>>> UpdateProject(Project p)
        {
            var project = dataAccess.GetById(p.ProjectId);
            if (project == null)
                return NotFound("Project not found");

            //project.ProjectName = p.ProjectName;
            //project.Company = p.Company;
            //project.Deadline = p.Deadline;
            //project.GitHub = p.GitHub;
            //project.Aktiv = p.Aktiv;
            dataAccess.SaveAsync(project);

            return Ok(dataAccess.GetProjects());
        }

        [HttpDelete("{projectId}")]
        public async Task<ActionResult<List<Project>>> Delete(int projectId)
        {
            var project = dataAccess.GetById(projectId);
            if (project == null)
                return NotFound("Project not found");

            dataAccess.DeleteAsync(projectId);

            return Ok(dataAccess.GetProjects());
        }
    }
}
