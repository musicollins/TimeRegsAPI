using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeRegApi.Model;

namespace TimeRegApi.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class EmployeesController : ControllerBase
    //{
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
}
