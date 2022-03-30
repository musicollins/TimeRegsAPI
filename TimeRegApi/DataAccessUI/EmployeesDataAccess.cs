using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TimeRegApi.Data;
using TimeRegApi.Model;

namespace TimeRegApi.UI.DataAccessUI
{
    public class EmployeesDataAccess : IEmployeesDataAccess
    {
        private readonly TRDbContext _tRDbContext;

        public EmployeesDataAccess(TRDbContext tRDbContext)
        {
            _tRDbContext = tRDbContext;
        }

        //EMPLOYEE
        public IEnumerable<Employee> GetEmployees()
        {
            return _tRDbContext.Employees.ToList();
        }

        public Employee GetEById(int employeeid)
        {
            return _tRDbContext.Employees.AsNoTracking().Single(e => e.EmployeeId == employeeid);
        }

        public void SaveEAsync(Employee employee)
        {
            //Retrieve the object first, then update it!
            var b = _tRDbContext.Employees.SingleOrDefault(p => p.EmployeeId == employee.EmployeeId);
            //CloneIt Method exists in the book model for the purposes of updating object
            //before it is saved into the database
            b.CloneIt(employee);

            //_tDbContext.Entry(book).State = EntityState.Modified;
            _tRDbContext.SaveChanges();
        }

        public void DeleteEAsync(int employeeid)
        {
            var b = _tRDbContext.Employees.SingleOrDefault(p => p.EmployeeId == employeeid);

            _tRDbContext.Employees.Remove(b);
            _tRDbContext.SaveChanges();
        }

        public void AddE(Employee employee)
        {
            _tRDbContext.Employees.Add(employee);

            var b = _tRDbContext.Employees.SingleOrDefault(p => p.EmployeeId == employee.EmployeeId);

            _tRDbContext.SaveChanges();
        }
    }
}
