namespace PeopleLibraryApp.Models
{
    public class Book
    {
        public string Title { get; set; }
        public string AuthorFullName { get; set; }
        public string Style { get; set; }
        public int Year { get; set; }
        public string AdditionalInfo { get; set; }

        public override string ToString()
        {
            return $"Назва: {Title}\nАвтор: {AuthorFullName}\nСтиль: {Style}\nРік видання: {Year}\nІнше: {AdditionalInfo}";
        }
    }
}
