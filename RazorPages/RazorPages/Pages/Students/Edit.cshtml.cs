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
        public int? Id { get; set; }
        [BindProperty]
        public Student Student { get; set; }
        internal IStudentService StudentService { get; set; }

        public EditModel(IStudentService ss)
        {
            StudentService = ss;
        }


        [TempData]
        public string Message { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Student = await StudentService.FindAsync(id);

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

            Student student = await StudentService.FindAsync(Id.GetValueOrDefault());
            student.FirstName = Student.FirstName;
            student.LastName = Student.LastName;
            student.Course = Student.Course;
            student.Veteran = Student.Veteran;

            try
            {
                await StudentService.SaveAsync(student);
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