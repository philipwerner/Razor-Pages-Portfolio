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
        public int? Id { get; set; }
        [BindProperty]
        public Course Course { get; set; }
        internal ICourseService CourseService { get; set; }
        [TempData]
        public string Message { get; set; }

        public EditModel(ICourseService cs)
        {
            CourseService = cs;
        }
        
        public async Task<IActionResult> OnGet(int id)
        {
            Course = await CourseService.FindAsync(id);

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

            Course course = await CourseService.FindAsync(Id.GetValueOrDefault());
            course.Name = Course.Name;
            course.Level = Course.Level;
            course.Language = Course.Language;
            course.Instructor = Course.Instructor;

            try
            {
                await CourseService.SaveAsync(course);
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