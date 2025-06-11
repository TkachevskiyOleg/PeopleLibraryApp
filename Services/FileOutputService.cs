using PeopleLibraryApp.Interfaces;
using System;
using System.IO;

namespace PeopleLibraryApp.Services
{
    public class FileOutputService : IOutputService
    {
        private readonly string _filePath;

        public FileOutputService(string filePath)
        {
            _filePath = filePath;
        }

        public void Write(string message)
        {
            File.AppendAllText(_filePath, message + Environment.NewLine);
        }
    }
}
