using PeopleLibraryApp.Interfaces;
using PeopleLibraryApp.Models;
using System;
using System.Collections.Generic;

namespace PeopleLibraryApp.Services;

public class ConsolePersonReader : IPersonReader
{
    public List<Person> ReadPeople()
    {
        var people = new List<Person>();

        string? firstName;
        do
        {
            Console.Write("First name: ");
            firstName = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(firstName));

        string? lastName;
        do
        {
            Console.Write("Last name: ");
            lastName = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(lastName));

        DateTime dateOfBirth;
        while (true)
        {
            Console.Write("Date of Birth (yyyy-MM-dd): ");
            string? dobInput = Console.ReadLine();
            if (DateTime.TryParse(dobInput, out dateOfBirth))
                break;

            Console.WriteLine("Invalid date format. Please try again.");
        }

        Console.Write("Info: ");
        string info = Console.ReadLine() ?? "";

        people.Add(new Person
        {
            FirstName = firstName,
            LastName = lastName,
            DateOfBirth = dateOfBirth,
            Info = info
        });

        return people;
    }
}
