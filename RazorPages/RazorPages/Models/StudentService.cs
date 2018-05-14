using Microsoft.EntityFrameworkCore;
using RazorPages.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.Models
{
    public class StudentService : IStudentService
    {
        private SchoolDbContext _context;

        public StudentService()
        {
            var options = new DbContextOptionsBuilder<SchoolDbContext>()
                .UseInMemoryDatabase("SchoolEnrollment")
                .Options;
            _context = new SchoolDbContext(options);
        }

        public StudentService(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task OnPostDeleteAsync(int id)
        {
            _context.Students.Attach(new Student { Id = id }).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public Student Find(int id)
        {
            return _context.Students.FirstOrDefault(s => s.Id == id);
        }

        public Task<Student> FindAsync(int id)
        {
            return _context.Students.FirstOrDefaultAsync(s => s.Id == id);
        }

        public IQueryable<Student> GetAll(int? count = null, int? page = null)
        {
            var realCount = count.GetValueOrDefault(10);

            return _context.Students
                    .Skip(realCount * page.GetValueOrDefault(0))
                    .Take(realCount);
        }

        public Task<Student[]> GetAllAsync(int? count = null, int? page = null)
        {
            return GetAll(count, page).ToArrayAsync();
        }

        public async Task SaveAsync(Student student)
        {
            var exsistant = student.Id == default(int);

            _context.Entry(student).State = exsistant ? EntityState.Added : EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}
