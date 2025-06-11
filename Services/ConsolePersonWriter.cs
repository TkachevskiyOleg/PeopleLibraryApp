using PeopleLibraryApp.Interfaces;
using PeopleLibraryApp.Models;
using System;

namespace PeopleLibraryApp.Services;

public class ConsolePersonWriter : IPersonWriter
{
    public void WritePerson(Person person)
    {
        Console.WriteLine(person);
        Console.WriteLine(new string('-', 30));
    }
}
