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
        private readonly ITimeReportsDataAccess dataAccess;

        public TimeReportsController(ITimeReportsDataAccess dataAccess)
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

            dataAccess.SaveTAsync(t);

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
