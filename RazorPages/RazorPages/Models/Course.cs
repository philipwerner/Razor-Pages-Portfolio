using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string Instructor { get; set; }
        public string Language { get; set; }
    }
}
