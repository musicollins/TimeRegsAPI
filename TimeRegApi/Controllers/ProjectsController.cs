using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeRegApi.Model;

namespace TimeRegApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private static List<Project> projects = new List<Project>
            {
                new Project {
                    ProjectId = 1,
                    ProjectName = "Test",
                    Company = "Aveer"
                },
                new Project {
                    ProjectId = 2,
                    ProjectName = "Testing",
                    Company = "Aveer"
                }
            };

        [HttpGet]
        public async Task<ActionResult<List<Project>>> Get()
        {
            return Ok(projects);
        }

        [HttpGet("{projectId}")]
        public async Task<ActionResult<Project>> Get(int projectId)
        {
            var project = projects.Find(p => p.ProjectId == projectId);
            if(project == null)
                return NotFound("Project not found");
            return Ok(project);
        }

        [HttpPost]
        public async Task<ActionResult<List<Project>>> AddProject(Project project)
        {
            projects.Add(project);
            return Ok(projects);
        }

        [HttpPut]
        public async Task<ActionResult<List<Project>>> UpdateProject(Project request)
        {
            var project = projects.Find(p => p.ProjectId == request.ProjectId);
            if (project == null)
                return NotFound("Project not found");

            project.ProjectName = request.ProjectName;
            project.Company = request.Company;
            project.Deadline = request.Deadline;
            project.GitHub = request.GitHub;
            project.Aktiv = request.Aktiv;

            return Ok(projects);
        }

        [HttpDelete("{projectId}")]
        public async Task<ActionResult<List<Project>>> Delete(int projectId)
        {
            var project = projects.Find(p => p.ProjectId == projectId);
            if (project == null)
                return NotFound("Project not found");

            projects.Remove(project);
            return Ok(projects);
        }
    }
}
