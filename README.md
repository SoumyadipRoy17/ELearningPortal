# ELearningPortal

## Overview

ELearningPortal is a simple backend-only project designed to manage an e-learning system. It uses **MongoDB** as the database for storing courses, users, and progress-related data.

## Features

- **Course Management:** Create, update, and delete courses.
- **User Enrollment:** Students can enroll in courses.
- **Progress Tracking:** Monitor student progress in courses.
- **Database-Driven:** All data is stored and managed using MongoDB.

## Technologies Used

- **Database:** MongoDB
- **Backend:** Plain script (no Node.js or web framework involved)

## Installation & Setup

### Prerequisites

Ensure you have the following installed:

- [MongoDB](https://www.mongodb.com/)

### Steps to Run the Project

1. **Clone the repository:**
   ```bash
   git clone https://github.com/SoumyadipRoy17/ELearningPortal.git
   cd ELearningPortal
**2.Start the MongoDB server (if running locally):**

bash
Copy
Edit
mongod
**3.Import Data (if needed):**

bash
Copy
Edit
mongoimport --db elearning --collection courses --file courses.json --jsonArray
4.Run the scripts as needed to interact with the database.

**5.Database Structure**
The database consists of collections like:

Users Collection (users)

json
Copy
Edit
{
  "_id": "ObjectId",
  "name": "John Doe",
  "email": "john@example.com",
  "role": "student"
}
Courses Collection (courses)

json
Copy
Edit
{
  "_id": "ObjectId",
  "title": "Introduction to Python",
  "description": "Learn Python from scratch",
  "instructor": "Jane Smith"
}
Contributing
**6.Contributions are welcome! To contribute:**

**7.Fork the repository.**
Create a new branch for your changes.
Commit and push your changes.
Open a pull request.
**License**
This project is licensed under the **MIT License**. See the LICENSE file for details.

Contact
For questions or suggestions, please open an issue in this repository.
License
This project is licensed under the MIT License. See the LICENSE file for details.

**Contact**
For questions or suggestions, please open an issue in this repository.


