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
        public int? Id { get; set; }
        [BindProperty]
        public Course Course { get; set; }
        internal ICourseService CourseService { get; }
        public IList<Course> Courses { get; set; }

        public IndexModel(ICourseService cs)
        {
            CourseService = cs;
        }

        public async Task OnGetAsync()
        {
            Courses = await CourseService.GetAllAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await CourseService.OnPostDeleteAsync(Id.GetValueOrDefault());

            return RedirectToPage();
        }
    }
}