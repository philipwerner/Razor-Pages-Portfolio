using Microsoft.EntityFrameworkCore;
using RazorPages.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.Models
{
    public class CourseService : ICourseService
    {
        private SchoolDbContext _context;

        public CourseService()
        {
            var options = new DbContextOptionsBuilder<SchoolDbContext>()
                            .UseInMemoryDatabase("SchoolEnrollment")
                            .Options;
            _context = new SchoolDbContext(options);
        }

        public CourseService(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task OnPostDeleteAsync(int id)
        {
            _context.Courses.Attach(new Course { Id = id}).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public Task<Course> FindAsync(int id)
        {
            return _context.Courses.FirstOrDefaultAsync(s => s.Id == id);

        }

        public Course Find(int id)
        {
            return _context.Courses.FirstOrDefault(s => s.Id == id);
        }

        public IQueryable<Course> GetAll(int? count = null, int? page = null)
        {
            var realCount = count.GetValueOrDefault(10);

            return _context.Courses
                    .Skip(realCount * page.GetValueOrDefault(0))
                    .Take(realCount);
        }

        public Task<Course[]> GetAllAsync(int? count = null, int? page = null)
        {
            return GetAll(count, page).ToArrayAsync();
        }

        public async Task SaveAsync(Course course)
        {
            var exsistant = course.Id == default(int);

            _context.Entry(course).State = exsistant ? EntityState.Added : EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}
