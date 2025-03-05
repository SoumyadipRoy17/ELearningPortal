using System;
using System.Collections.Generic;

namespace ElearningPortal.Services
{
    public static class TestService
    {
        private static readonly List<string> Tests = new List<string>
        {
            "MCQ Test: Basics of C#",
            "Coding Test: Implement Dijkstra’s Algorithm",
            "Short Answer: Explain OOP Principles"
        };

        public static void ShowTests()
        {
            Console.WriteLine("\n🔍 Available Tests:");
            foreach (var test in Tests)
            {
                Console.WriteLine($"- {test}");
            }
        }
    }
}
