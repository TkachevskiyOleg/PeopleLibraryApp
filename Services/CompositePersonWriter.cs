using PeopleLibraryApp.Interfaces;
using PeopleLibraryApp.Models;
using System.Collections.Generic;

namespace PeopleLibraryApp.Services
{
	public class CompositePersonWriter : IPersonWriter
	{
		private readonly IEnumerable<IPersonWriter> _writers;

		public CompositePersonWriter(IEnumerable<IPersonWriter> writers)
		{
			_writers = writers;
		}

		public void WritePerson(Person person)
		{
			foreach (var writer in _writers)
			{
				writer.WritePerson(person);
			}
		}
	}
}
