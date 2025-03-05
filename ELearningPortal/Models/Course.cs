using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Course
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("CourseName")]
    public string CourseName { get; set; }

    [BsonElement("Price")]
    public double Price { get; set; } // ✅ Added Price property
}
