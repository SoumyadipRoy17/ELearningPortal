using System;

namespace ElearningPortal.Functionalities
{
    public interface ITest
    {
        string Title { get; }
        void Attempt();
        void Submit();
    }

    public class MCQTest : ITest
    {
        public string Title { get; }

        public MCQTest(string title)
        {
            Title = title;
        }

        public void Attempt()
        {
            Console.WriteLine($"📝 Attempting MCQ Test: {Title}");
        }

        public void Submit()
        {
            Console.WriteLine($"✅ MCQ Test '{Title}' submitted successfully!");
        }
    }

    public class CodingTest : ITest
    {
        public string Title { get; }

        public CodingTest(string title)
        {
            Title = title;
        }

        public void Attempt()
        {
            Console.WriteLine($"💻 Attempting Coding Test: {Title}");
        }

        public void Submit()
        {
            Console.WriteLine($"✅ Coding Test '{Title}' submitted successfully!");
        }
    }
}
