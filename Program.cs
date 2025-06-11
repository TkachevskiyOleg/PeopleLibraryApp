using Microsoft.Extensions.DependencyInjection;
using PeopleLibraryApp.Interfaces;
using PeopleLibraryApp.Models;
using PeopleLibraryApp.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

string peopleFilePath = @"people.txt";
string peopleOutputPath = @"output.txt";

string booksFilePath = @"books.txt";
string booksOutputPath = @"books_output.txt";

var services = new ServiceCollection();

services.AddSingleton<ISeparatorDetector, SeparatorDetector>();
services.AddSingleton<IPersonWriter>(provider => new FilePersonWriter(peopleOutputPath));
services.AddSingleton<IPersonReader>(provider =>
{
    var detector = provider.GetRequiredService<ISeparatorDetector>();
    return new FilePersonReader(peopleFilePath, detector);
});

services.AddSingleton<IOutputService, ConsoleOutputService>();
services.AddSingleton<BookService>();
services.AddSingleton(provider => new BookFileLoader(booksFilePath));

var provider = services.BuildServiceProvider();

var reader = provider.GetRequiredService<IPersonReader>();
var writer = provider.GetRequiredService<IPersonWriter>();

List<Person> people = reader.ReadPeople();

Console.WriteLine("People:\n");

foreach (var person in people)
{
    Console.WriteLine($"{person.FirstName} {person.LastName}, {person.Age} років");
    writer.WritePerson(person);
}

Console.WriteLine($"\n{peopleOutputPath}.");
Console.WriteLine($"\n{peopleOutputPath}:\n");
Console.WriteLine(File.ReadAllText(peopleOutputPath));

var bookLoader = provider.GetRequiredService<BookFileLoader>();
var books = bookLoader.LoadBooks().ToList();

var bookService = provider.GetRequiredService<BookService>();

Console.WriteLine("\nBooks:\n");
bookService.PrintBooks(books);

var fileBookOutput = new FileOutputService(booksOutputPath);
var fileBookService = new BookService(fileBookOutput);
fileBookService.PrintBooks(books);

Console.WriteLine($"\n{booksOutputPath}.");
Console.WriteLine($"\n{booksOutputPath}:\n");
Console.WriteLine(File.ReadAllText(booksOutputPath));
