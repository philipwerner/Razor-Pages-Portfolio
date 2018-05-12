using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.Models
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Course Course { get; set; }
        public bool Veteran { get; set; }
    }
}
