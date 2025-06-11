using System;

namespace PeopleLibraryApp.Models;

public class Person
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public required string Info { get; set; }

    public int Age => DateTime.Now.Year - DateOfBirth.Year -
                      (DateTime.Now.DayOfYear < DateOfBirth.DayOfYear ? 1 : 0);

    public override string ToString()
    {
        return $"First name: {FirstName}\nLast name: {LastName}\nDate of Birth: {DateOfBirth:yyyy-MM-dd}\nInfo: {Info}";
    }
}
