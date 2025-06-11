using PeopleLibraryApp.Interfaces;
using PeopleLibraryApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PeopleLibraryApp.Services;

public class FilePersonReader : IPersonReader
{
    private readonly string _filePath;
    private readonly ISeparatorDetector _separatorDetector;

    public FilePersonReader(string filePath, ISeparatorDetector separatorDetector)
    {
        _filePath = filePath;
        _separatorDetector = separatorDetector;
    }

    public List<Person> ReadPeople()
    {
        var content = File.ReadAllText(_filePath);
        string separator = _separatorDetector.DetectSeparator(content);
        var entries = content.Split(separator, StringSplitOptions.RemoveEmptyEntries);

        List<Person> people = new();

        foreach (var entry in entries)
        {
            var lines = entry.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            string firstName = lines.FirstOrDefault(l => l.StartsWith("First name:"))?.Split(':')[1].Trim() ?? "";
            string lastName = lines.FirstOrDefault(l => l.StartsWith("Last name:"))?.Split(':')[1].Trim() ?? "";
            string dobStr = lines.FirstOrDefault(l => l.StartsWith("Date of Birth:"))?.Split(':')[1].Trim() ?? "";
            string info = lines.FirstOrDefault(l => l.StartsWith("Info:"))?.Split(':')[1].Trim() ?? "";

            DateTime.TryParse(dobStr, out DateTime dob);

            people.Add(new Person
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dob,
                Info = info
            });
        }

        return people;
    }
}
