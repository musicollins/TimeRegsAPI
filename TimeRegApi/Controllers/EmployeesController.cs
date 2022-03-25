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
        //    private static List<Employee> employees = new List<Employee>
        //        {
        //            new Employee { EmployeeId = 1,
        //                FirstName = "Filip",
        //                LastName = "Lindberg",
        //                PhoneNumber = 112
        //            },
        //            new Employee {
        //                EmployeeId = 2,
        //                FirstName = "Andre",
        //                LastName = "Lindqvist",
        //                PhoneNumber = 112
        //            }
        //        };

        //    [HttpGet]
        //    public async Task<ActionResult<List<Employee>>> Get()
        //    {
        //        return Ok(employees);
        //    }

        //    [HttpGet("{employeeId}")]
        //    public async Task<ActionResult<Employee>> Get(int employeeId)
        //    {
        //        var employee = employees.Find(p => p.EmployeeId == employeeId);
        //        if (employee == null)
        //            return NotFound("Project not found");
        //        return Ok(employee);
        //    }

        //    [HttpPost]
        //    public async Task<ActionResult<List<Employee>>> AddEmployee(Employee employee)
        //    {
        //        employees.Add(employee);
        //        return Ok(employees);
        //    }

        //    [HttpPut]
        //    public async Task<ActionResult<List<Employee>>> UpdateEmployee(Employee request)
        //    {
        //        var employee = employees.Find(p => p.EmployeeId == request.EmployeeId);
        //        if (employee == null)
        //            return NotFound("Project not found");

        //        employee.FirstName = request.FirstName;
        //        employee.LastName = request.LastName;
        //        employee.PhoneNumber = request.PhoneNumber;
        //        employee.Email = request.Email;
        //        employee.Password = request.Password;

        //        return Ok(employees);
        //    }

        //    [HttpDelete("{employeeId}")]
        //    public async Task<ActionResult<List<Employee>>> Delete(int employeeId)
        //    {
        //        var employee = employees.Find(p => p.EmployeeId == employeeId);
        //        if (employee == null)
        //            return NotFound("Project not found");

        //        employees.Remove(employee);
        //        return Ok(employees);
        //    }
        //}

        private readonly TDataAccess dataAccess;

        public EmployeesController(TDataAccess dataAccess)
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

            //project.ProjectName = p.ProjectName;
            //project.Company = p.Company;
            //project.Deadline = p.Deadline;
            //project.GitHub = p.GitHub;
            //project.Aktiv = p.Aktiv;
            dataAccess.SaveEAsync(employee);

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
