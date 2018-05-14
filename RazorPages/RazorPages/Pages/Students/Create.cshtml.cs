using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Data;
using RazorPages.Models;

namespace RazorPages.Pages.Students
{
    public class CreateModel : PageModel
    {
        private SchoolDbContext _db;

        public CreateModel(SchoolDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Student Student { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Students.Add(Student);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}