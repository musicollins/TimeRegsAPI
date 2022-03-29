using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeRegApi.Model;
using TimeRegApi.UI.DataAccessUI;

namespace TimeRegApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesDataAccess dataAccess;

        public EmployeesController(IEmployeesDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> Get()
        {
            return Ok(dataAccess.GetEmployees());
        }

        [HttpGet("{employeeId}")]
        public async Task<ActionResult<Employee>> GetEById(int employeeId)
        {
            var employee = dataAccess.GetEById(employeeId);
            if (employee == null)
                return NotFound("Employee not found");
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<List<Employee>>> AddEmployee(Employee employee)
        {
            dataAccess.AddE(employee);
            return Ok(dataAccess.GetEmployees());
        }

        [HttpPut]
        public async Task<ActionResult<List<Employee>>> UpdateEmployee(Employee e)
        {
            var employee = dataAccess.GetEById(e.EmployeeId);
            if (employee == null)
                return NotFound("Employee not found");

            dataAccess.SaveEAsync(e);

            return Ok(dataAccess.GetEmployees());
        }

        [HttpDelete("{employeeId}")]
        public async Task<ActionResult<List<Employee>>> Delete(int employeeId)
        {
            var employee = dataAccess.GetEById(employeeId);
            if (employee == null)
                return NotFound("Employee not found");

            dataAccess.DeleteEAsync(employeeId);

            return Ok(dataAccess.GetEmployees());
        }
    }
}
