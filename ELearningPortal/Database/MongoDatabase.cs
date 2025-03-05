//using MongoDB.Driver;
//using ElearningPortal.Models;
//using System.Collections.Generic;

//namespace ElearningPortal.Database
//{
//    public class Database
//    {
//        private readonly IMongoCollection<User> _users;

//        public Database()
//        {
//            var client = new MongoClient("mongodb+srv://soumyaroy172003:Soumya1234@elearning.huh4k.mongodb.net");
//            var database = client.GetDatabase("ElearningDB");
//            _users = database.GetCollection<User>("Users");
//        }

//        public User GetUser(string username)
//        {
//            var filter = Builders<User>.Filter.Eq(u => u.Username, username);
//            var projection = Builders<User>.Projection.Exclude("_id"); // Exclude _id from results
//            return _users.Find(filter).Project<User>(projection).FirstOrDefault();
//        }


//        public void AddUser(User user)
//        {
//            _users.InsertOne(user);
//        }
//    }
//}

//using MongoDB.Driver;
//using ElearningPortal.Models;
//using System.Collections.Generic;

//namespace ElearningPortal.Database
//{
//    public class MongoDatabase
//    {
//        private readonly IMongoCollection<User> _users;

//        public MongoDatabase()
//        {
//            var client = new MongoClient("mongodb+srv://soumyaroy172003:Soumya1234@elearning.huh4k.mongodb.net");
//            var database = client.GetDatabase("ElearningDB");
//            _users = database.GetCollection<User>("Users");
//        }

//        public User GetUser(string username)
//        {
//            return _users.Find(user => user.Username == username).FirstOrDefault();
//        }

//        public void AddUser(User user)
//        {
//            _users.InsertOne(user);
//        }

//        public List<User> GetStudents()
//        {
//            return _users.Find(user => user.Role == "Student").ToList();
//        }
//    }
//}

using MongoDB.Driver;
using System.Collections.Generic;
using ElearningPortal.Models;

namespace ElearningPortal.Database
{
    public class MongoDatabase : IDatabase
    {
        private readonly IMongoCollection<User> _users;
        private readonly IMongoCollection<Course> _courses;

        public MongoDatabase()
        {
            var client = new MongoClient("mongodb+srv://soumyaroy172003:Soumya1234@elearning.huh4k.mongodb.net");
            var database = client.GetDatabase("ElearningDB");
            _users = database.GetCollection<User>("Users");
            _courses = database.GetCollection<Course>("Courses");
        }

        public User GetUser(string username) => _users.Find(u => u.Username == username).FirstOrDefault();
        public void AddUser(User user) => _users.InsertOne(user);
        public List<User> GetStudents() => _users.Find(u => u.Role == "Student").ToList();
        public void AddCourse(Course course) => _courses.InsertOne(course);
        public List<Course> GetCourses() => _courses.Find(_ => true).ToList();
    }
}
