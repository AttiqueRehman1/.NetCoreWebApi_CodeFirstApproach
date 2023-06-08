using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Xml;
using testWebApiCore.DBContext;
using testWebApiCore.DTO_Models;
using testWebApiCore.Interface;
using testWebApiCore.Models;

namespace testWebApiCore.Repository
{
    public class BookRepo : IBook
    {
        MyDbContext _db;
        IMapper _mapper;
        public BookRepo(MyDbContext context, IMapper mapper)
        {
            _db = context;
            _mapper = mapper;

        }
        public void AddBook(Book book)
        {
            _db.Books.Add(book);
            _db.SaveChanges();
        }

        public List<BookDTO> GetBook()
        {
            try
            {
                var bookpbject = _db.Books.ToList();
                var mapbooks = _mapper.Map<List<BookDTO>>(bookpbject);
                if (mapbooks != null)
                    return mapbooks;
            }
            catch (Exception ex)
            {

            }
            return null;
        }


    }
}
