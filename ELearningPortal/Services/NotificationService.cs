//using System;
//using System.Collections.Generic;
//using MongoDB.Driver;
//using ElearningPortal.Models;

//namespace ElearningPortal.Services
//{
//    public class NotificationService
//    {
//        private readonly IMongoCollection<Notification> _notifications;

//        public NotificationService(IMongoDatabase database)
//        {
//            _notifications = database.GetCollection<Notification>("Notifications");
//        }

//        // ✅ Add a new notification
//        public void AddNotification(string message, string userId = "All")
//        {
//            var notification = new Notification { Message = message, UserId = userId };
//            _notifications.InsertOne(notification);
//        }

//        // ✅ Fetch unread notifications for a specific user
//        public List<Notification> GetUnreadNotifications(string userId)
//        {
//            return _notifications.Find(n => (n.UserId == "All" || n.UserId == userId) && !n.IsRead).ToList();
//        }

//        // ✅ Mark notifications as read
//        public void MarkNotificationsAsRead(string userId)
//        {
//            var filter = Builders<Notification>.Filter.Where(n => (n.UserId == "All" || n.UserId == userId) && !n.IsRead);
//            var update = Builders<Notification>.Update.Set(n => n.IsRead, true);
//            _notifications.UpdateMany(filter, update);
//        }
//    }
//}
using System;
using System.Collections.Generic;
using ElearningPortal.Models;
using MongoDB.Driver;

namespace ElearningPortal.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IMongoCollection<Notification> _notifications;
        
        public NotificationService(IMongoDatabase database)
        {
            _notifications = database.GetCollection<Notification>("Notifications");
        }

        public void SendNotificationToAll(string message)
        {
            var notification = new Notification
            {
                Message = message,
                CreatedAt = DateTime.Now,
                UserId = "All"
            };
            _notifications.InsertOne(notification);
            Console.WriteLine(" Notification sent to all users.");
        }

        public List<Notification> GetNotificationsForUser(string userId)
        {
            return _notifications.Find(n => n.UserId == "All" || n.UserId == userId).ToList();
        }
    }
}

