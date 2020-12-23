using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesPractical.Models;
using RazorPagesPractical.Services;

namespace RazorPagesPractical.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly IEmployeeRepository repo;
        private readonly IWebHostEnvironment webHostEnvironment;

        public EditModel(IEmployeeRepository repo, IWebHostEnvironment webHostEnvironment)
        {
            this.repo = repo;
            this.webHostEnvironment = webHostEnvironment;
        }

        public Employee Employee { get; set; }

        [BindProperty]
        public IFormFile Photo { get; set; }

        [BindProperty]
        public bool Notify { get; set; }

        public string Message { get; set; }

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
            if (Photo != null)
            {
                if(employee.PhotoPath != null) //Delete old photo before update
                { 
                    //Find photo path
                    string filePath = Path.Combine(webHostEnvironment.WebRootPath, "images", employee.PhotoPath);
                    //Delete photo
                    System.IO.File.Delete(filePath);
                }
                employee.PhotoPath = ProcessUploadFile();
            }

            Employee = repo.UpdateEmployee(employee);

            return RedirectToPage("Index");
        }

        //Handler method for the first form
        public void OnPostUpdateNotificationPreferences(int id)
        {
            if(Notify)
            {
                Message = "Thank you for turning on notifications";
            }

            else
            {
                Message = "You have turned off email notifications";
            }

            Employee = repo.GetEmployee(id);
        }
        
        private string ProcessUploadFile()
        {
            string uniqueFileName = null;
            if (Photo != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        } 
    }
}
