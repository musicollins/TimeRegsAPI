﻿using System.ComponentModel.DataAnnotations;

namespace TimeRegApi.Model
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public void CloneIt(Employee employee)
        {
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            PhoneNumber = employee.PhoneNumber;
            Email = employee.Email;
            Password = employee.Password;
        }

    }
}
