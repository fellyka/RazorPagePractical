using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesPractical.Models;
using RazorPagesPractical.Services;

namespace RazorPagePractical.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly IEmployeeRepository repo;

        public IEnumerable<Employee> Employees { get; set; }

        public IndexModel(IEmployeeRepository repo)
        {
            this.repo = repo;
        }
        public void OnGet()
        {
            Employees = repo.GetEmployees();
        }
    }
}
