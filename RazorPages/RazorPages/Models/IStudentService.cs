using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.Models
{
    public interface IStudentService
    {
        Task OnPostDeleteAsync(int id);
        Student Find(int id);
        Task<Student> FindAsync(int id);
        IQueryable<Student> GetAll(int? count = null, int? page = null);
        Task<Student[]> GetAllAsync(int? count = null, int? page = null);
        Task SaveAsync(Student student);
    }
}
