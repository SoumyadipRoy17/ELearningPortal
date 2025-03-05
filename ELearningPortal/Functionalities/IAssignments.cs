using System;

namespace ElearningPortal.Functionalities
{
    public interface IAssignment
    {
        string Name { get; }
        void Submit();
    }

    public class WrittenAssignment : IAssignment
    {
        public string Name { get; }

        public WrittenAssignment(string name)
        {
            Name = name;
        }

        public void Submit()
        {
            Console.WriteLine($"📖 Written Assignment '{Name}' submitted successfully!");
        }
    }

    public class PracticalAssignment : IAssignment
    {
        public string Name { get; }

        public PracticalAssignment(string name)
        {
            Name = name;
        }

        public void Submit()
        {
            Console.WriteLine($"🔬 Practical Assignment '{Name}' submitted successfully!");
        }
    }
}
