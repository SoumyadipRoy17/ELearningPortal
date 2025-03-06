using System.Collections.Generic;
using ElearningPortal.Models;

namespace ElearningPortal.Services
{
    public interface INotificationService
    {
        void SendNotificationToAll(string message);
        List<Notification> GetNotificationsForUser(string userId);
    }
}
