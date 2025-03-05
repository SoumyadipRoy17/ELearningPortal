using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ElearningPortal.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] // ✅ This ensures MongoDB handles `_id` properly
        public string Id { get; set; }

        [BsonElement("Username")] // Optional, explicitly map to MongoDB field name
        public string Username { get; set; }

        [BsonElement("Password")]
        public string Password { get; set; }

        [BsonElement("Role")]
        public string Role { get; set; }
    }
}
