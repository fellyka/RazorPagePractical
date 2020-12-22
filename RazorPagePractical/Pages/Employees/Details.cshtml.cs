using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesPractical.Models;
using RazorPagesPractical.Services;

namespace RazorPagesPractical.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        private IEmployeeRepository repo;

        public DetailsModel(IEmployeeRepository repo)
        {
            this.repo = repo;
        }

        public Employee Employee { get; private set; }

        public void OnGet(int id)
        {
            Employee = repo.GetEmployee(id);
        }
    }
}
