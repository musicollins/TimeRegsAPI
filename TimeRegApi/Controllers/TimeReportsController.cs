using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeRegApi.Model;
using TimeRegApi.UI.DataAccessUI;

namespace TimeRegApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeReportsController : ControllerBase
    {
        //    private static List<TimeReport> timeReports = new List<TimeReport>
        //        {
        //            new TimeReport {
        //                TimeReportId = 1,
        //                AfterHours = 2,
        //                Comment = "Testing"
        //            },
        //            new TimeReport {
        //                TimeReportId = 2,
        //                PreperationHours = 5,
        //                Comment = "Testing2"
        //            }
        //        };
        //    [HttpGet]
        //    public async Task<ActionResult<List<TimeReport>>> Get()
        //    {
        //        return Ok(timeReports);
        //    }

        //    [HttpGet("{timeReportId}")]
        //    public async Task<ActionResult<TimeReport>> Get(int timeReportId)
        //    {
        //        var timeReport = timeReports.Find(p => p.TimeReportId == timeReportId);
        //        if (timeReport == null)
        //            return NotFound("Project not found");
        //        return Ok(timeReport);
        //    }

        //    [HttpPost]
        //    public async Task<ActionResult<List<TimeReport>>> AddTimeReport(TimeReport TimeReport)
        //    {
        //        timeReports.Add(TimeReport);
        //        return Ok(timeReports);
        //    }

        //    [HttpPut]
        //    public async Task<ActionResult<List<TimeReport>>> UpdateTimeReport(TimeReport request)
        //    {
        //        var timeReport = timeReports.Find(p => p.TimeReportId == request.TimeReportId);
        //        if (timeReport == null)
        //            return NotFound("Project not found");

        //        timeReport.EducationHours = request.EducationHours;
        //        timeReport.PreperationHours = request.PreperationHours;
        //        timeReport.Other = request.Other;
        //        timeReport.AfterHours = request.AfterHours;
        //        timeReport.Comment = request.Comment;

        //        return Ok(timeReport);
        //    }

        //    [HttpDelete("{timeReportId}")]
        //    public async Task<ActionResult<List<TimeReport>>> Delete(int timeReportId)
        //    {
        //        var timeReport = timeReports.Find(p => p.TimeReportId == timeReportId);
        //        if (timeReport == null)
        //            return NotFound("Project not found");

        //        timeReports.Remove(timeReport);
        //        return Ok(timeReports);
        //    }

        private readonly TDataAccess dataAccess;

        public TimeReportsController(TDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        [HttpGet]
        public async Task<ActionResult<List<TimeReport>>> Get()
        {
            return Ok(dataAccess.GetTimeReports());
        }

        [HttpGet("{timeReportId}")]
        public async Task<ActionResult<TimeReport>> GetTById(int timeReportId)
        {
            var timeReport = dataAccess.GetTById(timeReportId);
            if (timeReport == null)
                return NotFound("Project not found");
            return Ok(timeReport);
        }

        [HttpPost]
        public async Task<ActionResult<List<TimeReport>>> AddTimeReport(TimeReport timeReport)
        {
            dataAccess.AddT(timeReport);
            return Ok(dataAccess.GetTimeReports());
        }

        [HttpPut]
        public async Task<ActionResult<List<TimeReport>>> UpdateTimeReport(TimeReport t)
        {
            var timeReport = dataAccess.GetTById(t.TimeReportId);
            if (timeReport == null)
                return NotFound("Time report not found");

            //project.ProjectName = p.ProjectName;
            //project.Company = p.Company;
            //project.Deadline = p.Deadline;
            //project.GitHub = p.GitHub;
            //project.Aktiv = p.Aktiv;
            dataAccess.SaveTAsync(timeReport);

            return Ok(dataAccess.GetTimeReports());
        }

        [HttpDelete("{timeReportId}")]
        public async Task<ActionResult<List<TimeReport>>> Delete(int timeReportId)
        {
            var timeReport = dataAccess.GetTById(timeReportId);
            if (timeReport == null)
                return NotFound("Time report not found");

            dataAccess.DeleteTAsync(timeReportId);

            return Ok(dataAccess.GetTimeReports());
        }
    }
}
