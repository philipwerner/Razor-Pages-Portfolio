# Student Management System 2.0

## The Site
http://newstudentmanagement.azurewebsites.net/

## Overview
This is a remake of the Student Enrollment project, this time using RazorPages.
The user still hass the ability to add, edit and delete both courses and 
students.

## CRUD
Within both the ```IStudentServices``` and the ```ICourseServices```
interfaces and the corresponding ```StudentServices``` and ```CourseServices```,
there are ```OnPostDeleteAsync``` for deleting the course or student. Also
there is the ```SaveAsync``` and ```IQueryable<Student/Course> GetAll```.

```OnPostDeleteAsync```: Used for deleting an item from the DB
```SaveAsync```: Used when adding or editing an item
```IQueryable<Student/Course> GetAll```/```Task<Student[]/Course[]> GetAllAsync```: Used on the Course/Student index to display all items

