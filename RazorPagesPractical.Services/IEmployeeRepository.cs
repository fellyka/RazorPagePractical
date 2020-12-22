using RazorPagesPractical.Models;
using System.Collections.Generic;

namespace RazorPagesPractical.Services
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployee(int id);
    }
}
