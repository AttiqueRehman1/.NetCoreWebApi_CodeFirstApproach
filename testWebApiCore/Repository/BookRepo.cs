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

        public List<Book> GetBook()
        {
            try
            {
                var bookpbject = _db.Books.ToList();
                var mapbooks = _mapper.Map<List<BookDTO>>(bookpbject);
                return bookpbject;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public List<Author> GetAllAuthor()
        {
            try
            {
                var authorList = _db.Authors.ToList();
                //var MapperList = _mapper.Map<List<AuthorDTO>>(authorList);
                return authorList;
            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }
        void IBook.AddAuthor(string authorname)
        {

            var author = new Author
            {
                AuthorName = authorname
            };

            _db.Authors.Add(author);
            _db.SaveChanges();

        }

        public Book GetBookAuthorName(int bookid)
        {
            try
            {
                var book = _db.Books
                            .Include(x => x.Author)
                            .Where(b => b.bookId == bookid).FirstOrDefault();
                return book != null ? book : null;
            }
            catch (Exception)
            {

                throw;
            }

            //}
            //async Task<List<Author>> IBook.getAuthorBookListById(int authorid)
            //{
            //    var authorBookList = await _db.Authors
            //            .Include(x => x.Books).Where(c => c.AuthorId == authorid).ToListAsync();
            //    if (authorBookList != null)
            //        return authorBookList;
            //    else return null;

            //}
            //async Task<List<Author>> IBook.getAuthorBookListByName(string authorname)
            //{
            //    var authorBookList = await _db.Authors
            //           .Include(x => x.Books)
            //           .Where(c => c.AuthorName == authorname).ToListAsync();
            //    return authorBookList != null ? authorBookList : null;
            //}
            //async Task<List<Book>>? IBook.getBookName(string bkName)
            //{
            //    var bookName = await _db.Books
            //       .Where(b => b.bookTitle.Contains(bkName)).ToListAsync();
            //    return bookName != null ? bookName : null;
            //}
            //void IBook.AddAuthorInfo(AuthorInfo authorInfo)
            //{
            //    _db.authorInfos.Add(authorInfo);
            //    _db.SaveChanges();
            //}
            //async Task<List<Book>> IBook.getAuthoInfoAndBooks(string authorName)
            //{
            //    var authorInfo = await _db.Books
            //             .Include(x => x.Author)
            //             .ThenInclude(b => b.AuthorInfo)
            //             .Where(b => b.Author.AuthorName == authorName)
            //             .ToListAsync();
            //    return authorInfo != null ? authorInfo : null;
            //}
            //void IBook.AddBookDTO(BookDTO book)
            //{
            //    var bk = _mapper.Map<Book>(book);
            //    _db.Books.Add(bk);
            //    _db.SaveChanges();

            //}
            //void IBook.AddAuthorDTO(AuthorDTO authorDTO)
            //{
            //    var a = _mapper.Map<Author>(authorDTO);
            //    _db.Authors.Add(a);
            //    _db.SaveChanges();
            //}
            //async Task<BookDTO> IBook.DTOGetBookAuthorName(int bookid)
            //{
            //    var book = await _db.Books
            //           .Include(x => x.Author)
            //           .Where(b => b.bookId == bookid).FirstOrDefaultAsync();

            //    var asd = _mapper.Map<BookDTO>(book);
            //    asd.AuthorName = book.Author.AuthorName;
            //    return asd != null ? asd : null;
            //}
            //void IBook.DTOAddAuthorInfo(AuthorInfo_DTO authorInfo)
            //{
            //    var infoDTO = _mapper.Map<AuthorInfo>(authorInfo);
            //    _db.authorInfos.Add(infoDTO);
            //    _db.SaveChanges();
            //}
            //async Task<AuhhorInfo_BookInfo> IBook.DTOgetAuthoInfoAndBooks(string authorName)
            //{
            //    var authorInfo = await _db.Authors
            //                        .Include(a => a.AuthorInfo)
            //                        .Include(a => a.Books)
            //                        .Where(a => a.AuthorName == authorName)
            //                        .FirstOrDefaultAsync();


            //    var dto = _mapper.Map<AuhhorInfo_BookInfo>(authorInfo);
            //    return dto;
            //}


        }
        public List<Country> getCountries()
        {
            try
            {
                var cou = _db.Countries.ToList();
                return cou;
            }
            catch (Exception)
            {

                throw;
            }
        }


    }


}

