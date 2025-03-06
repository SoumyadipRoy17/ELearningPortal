//using System;
//using ElearningPortal.Services;
//using ElearningPortal.Functionalities;
//using ElearningPortal.Database;
//using MongoDB.Driver;

//namespace ElearningPortal
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            IDatabase database = new MongoDatabase();
//            IAuthService authService = new AuthService(database);
//            IPortal portal = null;

//            Console.WriteLine("Enter username:");
//            string username = Console.ReadLine();
//            Console.WriteLine("Enter password:");
//            string password = Console.ReadLine();

//            var user = authService.Login(username, password);

//            if (user != null)
//            {
//                Console.WriteLine($"✅ Login successful! Welcome {user.Role}.");

//                // Fix: Pass the correct IMongoDatabase instance to CourseService
//                var mongoClient = new MongoClient("mongodb+srv://soumyaroy172003:Soumya1234@elearning.huh4k.mongodb.net");
//                var mongoDatabase = mongoClient.GetDatabase("ElearningDB");
//                ICourseService courseService = new CourseService(mongoDatabase);

//                if (user.Role == "Student")
//                {
//                    portal = new StudentPortal(courseService);
//                }
//                else
//                {
//                    portal = new ProfessorPortal(courseService);
//                }

//                portal.ShowMenu();
//            }
//            else
//            {
//                Console.WriteLine("⚠️ User not found. Registering new user...");
//                Console.WriteLine("Are you a Student or a Professor? (Enter 'Student' or 'Professor'):");
//                string role = Console.ReadLine();

//                authService.Register(username, password, role);
//                Console.WriteLine("✅ User registered successfully! Please restart the application and log in.");
//            }
//        }
//    }
//}

using System;
using ElearningPortal.Services;
using ElearningPortal.Functionalities;
using ElearningPortal.Database;
using MongoDB.Driver;

namespace ElearningPortal
{
    class Program
    {
        static void Main(string[] args)
        {
            IDatabase database = new MongoDatabase();
            IAuthService authService = new AuthService(database);
            IPortal portal = null;

            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();

            var user = authService.Login(username, password);

            if (user != null)
            {
                Console.WriteLine($"✅ Login successful! Welcome {user.Role}.");

                // Fix: Pass the correct IMongoDatabase instance to CourseService
                var mongoClient = new MongoClient("mongodb+srv://soumyaroy172003:Soumya1234@elearning.huh4k.mongodb.net");
                var mongoDatabase = mongoClient.GetDatabase("ElearningDB");
                var notificationService = new NotificationService(mongoDatabase);

                ICourseService courseService = new CourseService(mongoDatabase);
                PaymentService paymentService = new PaymentService();
                PaymentHandler paymentHandler = new PaymentHandler(paymentService);

                if (user.Role == "Student")
                {
                    portal = new StudentPortal(courseService, paymentHandler, notificationService, user.Id);
                }
                else if (user.Role == "Admin")
                {
                    portal = new AdminPortal(notificationService);
                }
                else
                {
                    portal = new ProfessorPortal(courseService, notificationService, user.Id);
                }

                portal.ShowMenu();
            }
            else
            {
                Console.WriteLine("⚠️ User not found. Registering new user...");
                Console.WriteLine("Are you a Student or a Professor? (Enter 'Student' or 'Professor'):");
                string role = Console.ReadLine();

                authService.Register(username, password, role);
                Console.WriteLine("✅ User registered successfully! Please restart the application and log in.");
            }
        }
    }
}

