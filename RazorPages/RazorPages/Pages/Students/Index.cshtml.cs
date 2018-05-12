using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Data;
using static RazorPages.Models.Student;

namespace RazorPages.Pages.Students
{
    public class IndexModel : PageModel
    {
        private SchoolDbContext _db;

        public IndexModel(SchoolDbContext db)
        {
            _db = db;
        }

        public IList<Student> Students { get; set; }

        public async Task OnGetAsync()
        {
            Students = await _db.Students.ToListAsync();
        }
    }
} 