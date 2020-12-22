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
    public class EditModel : PageModel
    {
        private IEmployeeRepository repo;

        public EditModel(IEmployeeRepository repo)
        {
            this.repo = repo;
        }

        public Employee Employee { get; set; }

        public IActionResult OnGet(int id)
        {
          Employee =  repo.GetEmployee(id);
          
          if(Employee == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page(); //re-render page

        }

        public IActionResult OnPost(Employee employee)
        {
            Employee = repo.UpdateEmployee(employee);

            return RedirectToPage("Index");
        }
    }
}
