using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPages.Data;
using RazorPages.Models;

namespace RazorPages.Pages.Courses
{
    public class EditModel : PageModel
    {
        private SchoolDbContext _db;

        public EditModel(SchoolDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Course Course { get; set; }

        [TempData]
        public string Message { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            Course = await _db.Courses.FindAsync(id);

            if (Course == null)
            {
                Message = "Course not found";
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

            _db.Attach(Course).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
                Message = "Course updated";
            }
            catch (DbUpdateConcurrencyException)
            {
                Message = "Course not found";
            }

            return RedirectToPage("Index");
        }


    }
}