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
    public class IndexModel : PageModel
    {
        private SchoolDbContext _db;

        public IndexModel(SchoolDbContext db)
        {
            _db = db;
        }

        public IList<Course> Courses { get; set; }

        public async Task OnGetAsync()
        {
            Courses = await _db.Courses.ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            _db.Courses.Attach(new Course { Id = id }).State = EntityState.Deleted;
            await _db.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}