namespace testWebApiCore.Models
{
    public class Book
    {
        public int bookId { get; set; }
       
        public string bookTitle { get; set; }

        public int AuthorId { get; set; }
        public Author? Author { get; set; }

    }
}
