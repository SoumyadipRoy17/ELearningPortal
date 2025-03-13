//using System;
//using System.Collections.Generic;
//using ElearningPortal.Database;
//using ElearningPortal.Models;
//using MongoDB.Driver;

//namespace ElearningPortal.Services
//{
//    public class CourseService : ICourseService
//    {
//        private readonly IMongoCollection<Course> _courses;

//        public CourseService(IDatabase db)
//        {
//            _courses = database.GetCollection<Course>("Courses");
//        }

//        public void AddCourse(string courseName, double price)
//        {
//            var course = new Course { CourseName = courseName, Price = price };
//            _courses.InsertOne(course);
//            Console.WriteLine($"✅ Course '{courseName}' added with price: ₹{price}");
//        }
//        public List<Course> GetAllCourses()
//        {
//            return _db.GetCourses();
//        }
//    }
//}

//using ElearningPortal.Database;
//using MongoDB.Driver;
//using System;
//using System.Collections.Generic;

//public class CourseService : ICourseService
//{
//    private readonly IMongoCollection<Course> _courses;

//    public CourseService(IMongoDatabase database)
//    {
//        _courses = database.GetCollection<Course>("Courses");
//    }

//    public void AddCourse(string courseName, double price)
//    {
//        var course = new Course { CourseName = courseName, Price = price };
//        var mongoClient = new MongoClient("mongodb+srv://soumyaroy172003:Soumya1234@elearning.huh4k.mongodb.net");
//        var mongoDatabase = mongoClient.GetDatabase("ElearningDB"); // Ensure consistent casing
//        _courses.InsertOne(course);
//        Console.WriteLine($"✅ Course '{courseName}' added with price: ₹{price}");
//    }

//    public List<Course> GetAllCourses()
//    {
//        return _courses.Find(_ => true).ToList();
//    }
//}

using ElearningPortal.Database;
using ElearningPortal.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace ElearningPortal.Services
{
    public class CourseService : ICourseService
    {
        private readonly IMongoCollection<Course> _courses;

        public CourseService(IMongoDatabase database)
        {
            _courses = database.GetCollection<Course>("Courses");
        }

        public void AddCourse(string courseName, double price)
        {
            var course = new Course { CourseName = courseName, Price = price };
            _courses.InsertOne(course);
            Console.WriteLine($"Course '{courseName}' added with price: Rs{price}");
        }

        public List<Course> GetAllCourses()
        {
            return _courses.Find(_ => true).ToList();
        }

        public Course GetCourse(string courseId)
        {
            return _courses.Find(c => c.Id == courseId).FirstOrDefault();
        }

        public void EnrollStudent(string courseId)
        {
            Console.WriteLine($" Student successfully enrolled in course with ID {courseId}.");
        }
    }
}


