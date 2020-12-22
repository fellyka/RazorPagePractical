using RazorPagesPractical.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace RazorPagesPractical.Services
{
   public class MockEmployee : IEmployeeRepository
   {
        private List<Employee> employees;

        public MockEmployee()
        {
            employees = new List<Employee>()
            {
                new Employee() {Id = 1, Name = "Jeanne", Department = Dept.HR, Email  = "jeanne@fellyka.co.za",
                                PhotoPath = "jeanne.png"},
                new Employee() {Id = 2, Name = "Carla", Department = Dept.None, Email  = "carla@fellyka.co.za",
                                PhotoPath = "carla.png"},
                new Employee() {Id = 3, Name = "Mark", Department = Dept.Payroll, Email  = "mark@fellyka.co.za",
                                PhotoPath = "mark.jpg"},
                new Employee() {Id = 4, Name = "Gerard", Department = Dept.IT, Email  = "gerard@fellyka.co.za"}
            };
        }

        public Employee GetEmployee(int id)
        {
            return employees.FirstOrDefault(e => e.Id == id);
        }

        public Employee UpdateEmployee(Employee updatedEmployee)
        {
            Employee employee = employees.FirstOrDefault(e => e.Id == updatedEmployee.Id);
            if(employee != null)
            {
                employee.Name = updatedEmployee.Name;
                employee.Email = updatedEmployee.Email;
                employee.Department = updatedEmployee.Department;
                employee.PhotoPath = updatedEmployee.PhotoPath;
            }

            return employee;
        }

        IEnumerable<Employee> IEmployeeRepository.GetEmployees()
        {
            return employees;
        }
   }
}
