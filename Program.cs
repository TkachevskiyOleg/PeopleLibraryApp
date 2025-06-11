using Microsoft.Extensions.DependencyInjection;
using PeopleLibraryApp.Interfaces;
using PeopleLibraryApp.Models;
using PeopleLibraryApp.Services;
using System;
using System.Collections.Generic;
using System.IO; // ← Для File.ReadAllText

var services = new ServiceCollection();

string filePath = @"people.txt";
string outputPath = @"output.txt";

// Реєстрація сервісів
services.AddSingleton<ISeparatorDetector, SeparatorDetector>();
services.AddSingleton<IPersonWriter>(provider => new FilePersonWriter(outputPath));
services.AddSingleton<IPersonReader>(provider =>
{
    var detector = provider.GetRequiredService<ISeparatorDetector>();
    return new FilePersonReader(filePath, detector);
});

var provider = services.BuildServiceProvider();
var reader = provider.GetRequiredService<IPersonReader>();
var writer = provider.GetRequiredService<IPersonWriter>();

List<Person> people = reader.ReadPeople();

Console.WriteLine("people:\n");

foreach (var person in people)
{
    Console.WriteLine($"{person.FirstName} {person.LastName}, {person.Age} років");
    writer.WritePerson(person);
}

Console.WriteLine($"\n{outputPath}.");
Console.WriteLine($"\n{outputPath}:\n");
Console.WriteLine(File.ReadAllText(outputPath));
