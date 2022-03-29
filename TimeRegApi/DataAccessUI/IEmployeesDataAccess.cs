using TimeRegApi.Model;
using System.Collections.Generic;

namespace TimeRegApi.UI.DataAccessUI
{
    public interface IEmployeesDataAccess
    {
        //EMPLOYEE
        IEnumerable<Employee> GetEmployees();
        Employee GetEById(int employeeid);
        void AddE(Employee employee);
        void SaveEAsync(Employee employee);
        void DeleteEAsync(int employeeid);
    }
}