﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ElearningPortal.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] 
        public string Id { get; set; }

        [BsonElement("Username")] 
        public string Username { get; set; }

        [BsonElement("Password")]
        public string Password { get; set; }

        [BsonElement("Role")]
        public string Role { get; set; }
    }
}
