using PeopleLibraryApp.Interfaces;
using PeopleLibraryApp.Models;
using System.Collections.Generic;

namespace PeopleLibraryApp.Services
{
	public class BookService
	{
		private readonly IOutputService _outputService;

		public BookService(IOutputService outputService)
		{
			_outputService = outputService;
		}

		public void PrintBook(Book book)
		{
			_outputService.Write(book.ToString());
		}

		public void PrintBooks(IEnumerable<Book> books)
		{
			foreach (var book in books)
			{
				PrintBook(book);
				_outputService.Write(new string('-', 30));
			}
		}
	}
}
