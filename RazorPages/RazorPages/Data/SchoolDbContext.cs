using Microsoft.EntityFrameworkCore;
using RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.Data
{
    public class SchoolDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }


        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {

        }
    }
}
