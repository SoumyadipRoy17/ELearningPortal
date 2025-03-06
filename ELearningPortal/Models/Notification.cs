//using MongoDB.Bson;
//using MongoDB.Bson.Serialization.Attributes;
//using System;

//namespace ElearningPortal.Models
//{
//    public class Notification
//    {
//        [BsonId]
//        [BsonRepresentation(BsonType.ObjectId)]
//        public string Id { get; set; }

//        public string Message { get; set; }
//        public DateTime Timestamp { get; set; } = DateTime.Now;

//        public bool IsRead { get; set; } = false;  // Track if the notification is read

//        public string UserId { get; set; }  // Associate with a specific user or "All" for global
//    }
//}

using MongoDB.Bson;
using System;
using MongoDB.Bson.Serialization.Attributes;

namespace ElearningPortal.Models
{
    public class Notification
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserId { get; set; } // "All" for global notifications
    }
}
