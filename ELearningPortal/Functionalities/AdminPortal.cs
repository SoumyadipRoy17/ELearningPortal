using System;
using ElearningPortal.Services;

namespace ElearningPortal.Functionalities
{
    public class AdminPortal:IPortal
    {
        private readonly INotificationService _notificationService;

        public AdminPortal(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\n🔧 Admin Portal - Manage Notifications:");
                Console.WriteLine("1. Send Notification to All Users");
                Console.WriteLine("2. Exit");

                Console.Write("\nSelect an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        SendNotificationToAll();
                        break;
                    case "2":
                        return;
                    default:
                        Console.WriteLine("⚠️ Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void SendNotificationToAll()
        {
            Console.Write("\nEnter notification message: ");
            string message = Console.ReadLine();
            _notificationService.SendNotificationToAll(message);
        }
    }
}
