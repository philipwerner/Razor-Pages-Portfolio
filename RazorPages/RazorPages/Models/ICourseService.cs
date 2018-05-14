using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.Models
{
    public interface ICourseService
    {
        Task OnPostDeleteAsync(int id);
        Course Find(int id);
        Task<Course> FindAsync(int id);
        IQueryable<Course> GetAll(int? count = null, int? page = null);
        Task<Course[]> GetAllAsync(int? count = null, int? page = null);
        Task SaveAsync(Course course);
    }
}
