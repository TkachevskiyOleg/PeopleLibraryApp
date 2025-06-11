using PeopleLibraryApp.Interfaces;
using System;

namespace PeopleLibraryApp.Services
{
    public class ConsoleOutputService : IOutputService
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
