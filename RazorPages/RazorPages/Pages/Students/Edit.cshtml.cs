using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPages.Data;
using RazorPages.Models;

namespace RazorPages.Pages.Students
{
    public class EditModel : PageModel
    {
        private SchoolDbContext _db;

        public EditModel(SchoolDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Student Student { get; set; }

        [TempData]
        public string Message { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Student = await _db.Students.FindAsync(id);

            if (Student == null)
            {
                Message = "Student not found.";
                return RedirectToPage("Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Attach(Student).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
                Message = "Student updated";
            }
            catch (DbUpdateConcurrencyException)
            {
                Message = "Student not found";
            }

            return RedirectToPage("Index");
        }
    }
}