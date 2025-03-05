//using ElearningPortal.Functionalities;
//using System;

//public class StudentPortal : IPortal
//{
//    private readonly ICourseService _courseService;

//    public StudentPortal(ICourseService courseService)
//    {
//        _courseService = courseService;
//    }

//    public void ShowMenu()
//    {
//        ShowCourses();
//    }

//    public void ShowCourses()
//    {
//        Console.WriteLine("\n📚 Available Courses:");
//        var courses = _courseService.GetAllCourses();

//        if (courses.Count == 0)
//        {
//            Console.WriteLine("⚠️ No courses available.");
//        }
//        else
//        {
//            foreach (var course in courses)
//            {
//                Console.WriteLine($"- {course.CourseName} (₹{course.Price})");
//            }
//        }
//    }
//}
using System;
using ElearningPortal.Services;
using ElearningPortal.Models;
using ElearningPortal.Functionalities;

namespace ElearningPortal.Functionalities
{
    public class StudentPortal : IPortal
    {
        private readonly ICourseService _courseService;
       
        private readonly PaymentService _paymentService;

        public StudentPortal(ICourseService courseService, PaymentService paymentService)
        {
            _courseService = courseService;
            _paymentService = paymentService;
        }


        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\n📚 Student Portal:");
                Console.WriteLine("1. View Available Courses");
                Console.WriteLine("2. Enroll in a Course");
                Console.WriteLine("3. Exit");

                Console.Write("\nSelect an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowCourses();
                        break;
                    case "2":
                        EnrollInCourse();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("⚠️ Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void ShowCourses()
        {
            Console.WriteLine("\n📚 Available Courses:");
            var courses = _courseService.GetAllCourses();

            if (courses.Count == 0)
            {
                Console.WriteLine("⚠️ No courses available.");
            }
            else
            {
                foreach (var course in courses)
                {
                    Console.WriteLine($"- {course.CourseName} (₹{course.Price}) - ID: {course.Id}");
                }
            }
        }

        private void EnrollInCourse()
        {
            Console.Write("Enter Course ID to enroll: ");
            string courseId = Console.ReadLine();
            var course = _courseService.GetCourse(courseId);

            if (course != null)
            {
                Console.WriteLine($"💰 Course Price: ₹{course.Price}");
                Console.WriteLine("Select Payment Method (1. Credit Card, 2. PayPal, 3. UPI): ");
                string paymentChoice = Console.ReadLine();
                PaymentMethod paymentMethod = null;

                if (paymentChoice == "1")
                {
                    paymentMethod = new CreditCardPayment(Convert.ToDecimal(course.Price));
                }
                else if (paymentChoice == "2")
                {
                    paymentMethod = new PayPalPayment(Convert.ToDecimal(course.Price));
                }
                else if (paymentChoice == "3")
                {
                    paymentMethod = new UPIPayment(Convert.ToDecimal(course.Price));
                }
                else
                {
                    Console.WriteLine("⚠️ Invalid payment method.");
                }

                if (paymentMethod != null)
                {
                    bool paymentSuccess = _paymentService.ProcessPayment(paymentMethod);
                    if (paymentSuccess)
                    {
                        Console.WriteLine($"🎉 Successfully enrolled in {course.CourseName}!");
                        _courseService.EnrollStudent(course.Id);
                    }
                    else
                    {
                        Console.WriteLine("❌ Payment failed! Try again.");
                    }
                }

                if (paymentMethod != null)
                {
                    bool paymentSuccess = _paymentService.ProcessPayment(paymentMethod);
                    if (paymentSuccess)
                    {
                        Console.WriteLine($"🎉 Successfully enrolled in {course.CourseName}!");
                        _courseService.EnrollStudent(courseId);
                    }
                    else
                    {
                        Console.WriteLine("❌ Payment failed! Try again.");
                    }
                }
                else
                {
                    Console.WriteLine("⚠️ Invalid payment method.");
                }
            }
            else
            {
                Console.WriteLine("⚠️ Course not found.");
            }
        }
    }
}

