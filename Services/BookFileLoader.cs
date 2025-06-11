using PeopleLibraryApp.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace PeopleLibraryApp.Services
{
    public class BookFileLoader
    {
        private readonly string _filePath;

        public BookFileLoader(string filePath)
        {
            _filePath = filePath;
        }

        public IEnumerable<Book> LoadBooks()
        {
            var content = File.ReadAllText(_filePath);

            var bookBlocks = Regex.Split(content, @"(\r?\n){2,}");

            foreach (var block in bookBlocks)
            {
                var lines = block.Split(new[] { '\r', '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
                if (lines.Length < 4) continue;

                yield return new Book
                {
                    Title = lines[0].Trim(),
                    AuthorFullName = lines[1].Trim(),
                    Style = lines[2].Trim(),
                    Year = int.TryParse(lines[3], out var y) ? y : 0,
                    AdditionalInfo = lines.Length > 4 ? lines[4].Trim() : string.Empty
                };
            }
        }
    }
}
