//using System;
//using ElearningPortal.Database;
//using ElearningPortal.Services;

//namespace ElearningPortal.Functionalities
//{
//    public class ProfessorPortal : IPortal
//    {
//        private readonly ICourseService _courseService;
//        private readonly IDatabase _database;

//        public ProfessorPortal(ICourseService courseService, IDatabase database) // ✅ Now accepts two parameters
//        {
//            _courseService = courseService;
//            _database = database;
//        }

//        public void ShowMenu()
//        {
//            Console.WriteLine("\n🎓 Professor Portal:");
//            Console.WriteLine("1. Add Course");
//            Console.WriteLine("2. View Students Enrolled");
//            Console.WriteLine("3. Exit");

//            Console.WriteLine("\nSelect an option:");
//            string choice = Console.ReadLine();

//            if (choice == "3")
//            {
//                Console.WriteLine("👋 Exiting the portal...");
//                return;
//            }

//            if (choice == "1")
//            {
//                Console.WriteLine("Enter course name to add:");
//                string courseName = Console.ReadLine();
//                _courseService.AddCourse(courseName); // ✅ Now uses ICourseService
//                Console.WriteLine($"✅ Course '{courseName}' added successfully!");
//            }
//            else if (choice == "2")
//            {
//                var students = _database.GetStudents();

//                if (students.Count == 0)
//                {
//                    Console.WriteLine("⚠️ No students enrolled yet.");
//                }
//                else
//                {
//                    Console.WriteLine("📜 List of enrolled students:");
//                    foreach (var student in students)
//                    {
//                        Console.WriteLine($"- {student.Username}");
//                    }
//                }
//            }
//        }
//    }
//}
using ElearningPortal.Functionalities;
using System;

public class ProfessorPortal : IPortal
{
    private readonly ICourseService _courseService;

    public ProfessorPortal(ICourseService courseService)
    {
        _courseService = courseService;
    }


    public void ShowMenu()
    {
        ManageCourses();
    }

    public void ManageCourses()
    {
        Console.WriteLine("\n🎓 Professor Portal:");
        Console.WriteLine("1. Add Course");
        Console.WriteLine("2. View All Courses");
        Console.WriteLine("3. Exit");
        while (true)
        {
            Console.Write("\nSelect an option: ");
            string choice = Console.ReadLine();

            if (choice == "3")
            {
                Console.WriteLine("👋 Exiting the portal...");
                return;
            }

            if (choice == "1")
            {
                Console.Write("Enter course name: ");
                string courseName = Console.ReadLine();

                Console.Write("Enter course price: ");
                if (double.TryParse(Console.ReadLine(), out double price))
                {
                    _courseService.AddCourse(courseName, price);
                }
                else
                {
                    Console.WriteLine("❌ Invalid price. Please enter a numeric value.");
                }
            }
            else if (choice == "2")
            {
                var courses = _courseService.GetAllCourses();
                Console.WriteLine("\n📚 Available Courses:");
                foreach (var course in courses)
                {
                    Console.WriteLine($"- {course.CourseName} (₹{course.Price})");
                }

            }
        }
    }
}

