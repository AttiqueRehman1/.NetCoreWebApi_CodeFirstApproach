using testWebApiCore.DTO_Models;
using testWebApiCore.Models;

namespace testWebApiCore.Interface
{
    public interface IBook
    {
        List<BookDTO> GetBook();
        //Book GetBookById(int id);
        void AddBook(Book book);
    }
}
