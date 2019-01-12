using System;

namespace WebApiStatelessSample
{
    public class CustomAction : ICustomAction
    {
        public void OnEntry(string message)
        {
            Console.WriteLine($"OnEntry {message}");
        }

        public void OnExit(string message)
        {
            Console.WriteLine($"OnExit {message}");
        }
    }

    public interface ICustomAction
    {
        void OnExit(string message);
        void OnEntry(string message);
    }
}