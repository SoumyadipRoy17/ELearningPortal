using System.Collections.Generic;
using ElearningPortal.Models;

namespace ElearningPortal.Database
{
    public interface IDatabase
    {
        User GetUser(string username);
        void AddUser(User user);
        List<User> GetStudents();
        void AddCourse(Course course);
        List<Course> GetCourses();
    }
}
