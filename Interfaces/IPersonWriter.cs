using PeopleLibraryApp.Models;

namespace PeopleLibraryApp.Interfaces;

public interface IPersonWriter
{
    void WritePerson(Person person);
}
