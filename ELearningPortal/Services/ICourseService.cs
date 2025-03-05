using System.Collections.Generic;
using ElearningPortal.Models;

public interface ICourseService
{
    void AddCourse(string courseName, double price);
    List<Course> GetAllCourses();
    Course GetCourse(string courseId);  // Added method
    void EnrollStudent(string courseId); // Added method
}
