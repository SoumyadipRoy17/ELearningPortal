using System;
using System.Collections.Generic;

namespace ElearningPortal.Services
{
    public static class AssignmentService
    {
        private static readonly List<string> Assignments = new List<string>
        {
            "Essay: Explain the SOLID Principles",
            "Project: Build a Library Management System in C#",
            "Case Study: Analyze an Open-Source Project"
        };

        public static void ShowAssignments()
        {
            Console.WriteLine("\n📄 Available Assignments:");
            foreach (var assignment in Assignments)
            {
                Console.WriteLine($"- {assignment}");
            }
        }
    }
}
