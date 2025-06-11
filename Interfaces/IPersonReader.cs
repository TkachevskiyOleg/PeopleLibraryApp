using PeopleLibraryApp.Models;
using System.Collections.Generic;

namespace PeopleLibraryApp.Interfaces;

public interface IPersonReader
{
    List<Person> ReadPeople();
}
