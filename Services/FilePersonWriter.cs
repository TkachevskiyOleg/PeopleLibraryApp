using PeopleLibraryApp.Interfaces;
using PeopleLibraryApp.Models;
using System.IO;

namespace PeopleLibraryApp.Services;

public class FilePersonWriter : IPersonWriter
{
    private readonly string _filePath;

    public FilePersonWriter(string filePath)
    {
        _filePath = filePath;
    }

    public void WritePerson(Person person)
    {
        File.AppendAllText(_filePath, person + "\n" + new string('-', 30) + "\n");
    }
}
