using testWebApiCore.Models;
using testWebApiCore.Repository;

namespace testWebApiCore.Interface
{
    public interface IBook
    {
        public List<Book> GetBook();
        public List<Author> GetAllAuthor();
        //Book GetBookById(int id);
        void AddBook(Book book);
        public void AddAuthor(string authorname);
        Book GetBookAuthorName(int bookid);
        public List<Country> getCountries();
        //Task<List<Author>> getAuthorBookListById(int authorid);
        //Task<List<Author>> getAuthorBookListByName(string authorname);
        //Task<List<Book>> getBookName(string bkName);
        //void AddAuthorInfo(AuthorInfo authorInfo);
        //Task<List<Book>> getAuthoInfoAndBooks(string authorName);
        //void AddBookDTO(BookDTO book);
        //void AddAuthorDTO(AuthorDTO authorDTO);
        //Task<BookDTO> DTOGetBookAuthorName(int bookid);
        //void DTOAddAuthorInfo(AuthorInfo_DTO authorInfo);
        //Task<AuhhorInfo_BookInfo> DTOgetAuthoInfoAndBooks(string authorName);
    }
}
