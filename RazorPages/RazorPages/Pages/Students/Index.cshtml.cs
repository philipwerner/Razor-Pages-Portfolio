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
    public class IndexModel : PageModel
    {
        public int? Id { get; set; }
        [BindProperty]
        public Student Student { get; set; }
        internal IStudentService StudentService { get; }
        public IList<Student> Students { get; set; }


        public IndexModel(IStudentService ss)
        {
            StudentService = ss;
        }


        public async Task OnGetAsync()
        {
            Students = await StudentService.GetAllAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await StudentService.OnPostDeleteAsync(Id.GetValueOrDefault());

            return RedirectToPage();
        }
    }
} 