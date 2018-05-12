using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public IList<Course> Courses { get; set; }

        public void OnGet()
        {
        }
    }
}