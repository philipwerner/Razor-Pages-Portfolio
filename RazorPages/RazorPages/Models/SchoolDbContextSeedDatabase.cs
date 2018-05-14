using RazorPages.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.Models
{
    public static class SchoolDbContextSeedDatabase
    {
        static object synchblock = new object();
        static volatile bool seeded = false;
        public static void SeedTheData(this SchoolDbContext context)
        {
            if(!seeded && context.Courses.Count() == 0 && context.Students.Count() == 0)
            {
                lock (synchblock)
                {
                    if (!seeded)
                    {
                        var courses = GenerateCourses();
                        context.Courses.AddRange(courses);
                        var students = GenerateStudents();
                        context.Students.AddRange(students);
                        context.SaveChanges();
                        seeded = true;
                    }
                }
            }
        }

        public static Course[] GenerateCourses()
        {
            return new Course[]
            {
                new Course
                {
                    Name = "Python",
                    Instructor = "Scott",
                    Language = "Python",
                    Level = 401,
                },
                new Course
                {
                    Name = "C# Asp.Net",
                    Instructor = "Amanda",
                    Language = "C#",
                    Level = 401,
                },
            };
        }

        public static Student[] GenerateStudents()
        {
            return new Student[]
            {
                new Student
                {
                    FirstName = "Sarah",
                    LastName = "Doe",
                    Veteran = false,
                },
                new Student
                {
                    FirstName = "Jeffery",
                    LastName = "Alton",
                    Veteran = false,
                },
                new Student
                {
                    FirstName = "Stephen",
                    LastName = "Goodjohn",
                    Veteran = true,
                },
            };
        }
    }
}
