using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testWebApiCore.DBContext;
using testWebApiCore.DTO_Models;
using testWebApiCore.Interface;
using testWebApiCore.Models;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using static System.Reflection.Metadata.BlobBuilder;

namespace testWebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly MyDbContext _db;
        private IMapper _mapper;
        IBook _bookrepo;
        public BookController(MyDbContext db, IMapper mapper, IBook bookrepo)
        {
            _db = db;
            _mapper = mapper;
            _bookrepo = bookrepo;
        }

        [HttpPost]
        [Route("AddBook")]
        public ActionResult AddBook(Book book)
        {
            try
            {
                _bookrepo.AddBook(book);
                return Ok("Book Add successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddAuthor")]
        public ActionResult AddAuthor(Author author)
        {
            try
            {
                _db.Authors.Add(author);
                _db.SaveChanges();
                return Ok("Author Add sucessfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("GetBooks")]
        public ActionResult GetBook()
        {
            try
            {
                return Ok(_bookrepo.GetBook());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("GetAuthor")]
        public ActionResult GetAllAuthors()
        {
            try
            {
                var authorList = _db.Authors.ToList();
                var MapperList = _mapper.Map<List<AuthorDTO>>(authorList);
                return Ok(MapperList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("GetBookAuthorName/{bookid}")]
        public ActionResult GetBookAuthorName(int bookid)
        {
            try
            {
                var book = _db.Books
                    .Include(x => x.Author)
                    .Where(b => b.bookId == bookid).FirstOrDefault();
                // var author = _db.Authors.Where(a => a.AuthorId == book.AuthorId).FirstOrDefault();
                if (book == null)
                {
                    return NotFound("Book not found");
                }

                return Ok(book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/bookListbyId/{authorid}")]
        public ActionResult getAuthorBookListById(int authorid)
        {
            try
            {
                var authorBookList = _db.Authors
                    .Include(x => x.Books).Where(c => c.AuthorId == authorid).ToList();
                if (authorBookList == null)
                {
                    return NotFound("Book not found");
                }
                return Ok(authorBookList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/bookListbyName/{authorname}")]
        public ActionResult getAuthorBookListByName(string authorname)
        {
            try
            {
                var authorBookList = _db.Authors
                    .Include(x => x.Books)
                    .Where(c => c.AuthorName == authorname).FirstOrDefault();
                if (authorBookList == null)
                {
                    return NotFound("Book not found");
                }
                return Ok(authorBookList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("api/getBookName")]
        public ActionResult getBookName(string bkName)
        {
            try
            {
                var bookName = _db.Books
                .Where(b => b.bookTitle.Contains(bkName)).ToList();


                if (bookName == null)
                {
                    return NotFound("Book not found");
                }
                return Ok(bookName);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddAuthorInfo")]
        public ActionResult AddAuthorInfo(AuthorInfo authorInfo)
        {
            try
            {
                _db.authorInfos.Add(authorInfo);
                _db.SaveChanges();
                return Ok("AuthorInfo Add successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/getAuthoInfoAndBooks")]
        public ActionResult getAuthoInfoAndBooks(string authorName)
        {
            try
            {
                var authorInfo = _db.Books
                    .Include(x => x.Author)
                    .ThenInclude(b => b.AuthorInfo)
                    .Where(b => b.Author.AuthorName == authorName)
                    .ToList();


                if (authorInfo == null)
                {
                    return NotFound("Book not found");
                }
                return Ok(authorInfo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddBookDTO")]
        public ActionResult AddBookDTO(BookDTO book)
        {
            try
            {
                var bk = _mapper.Map<Book>(book);
                _db.Books.Add(bk);
                _db.SaveChanges();

                return Ok("Book Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("AddAuthorDTO")]
        public ActionResult AddAuthorDTO(AuthorDTO author)
        {
            try
            {
                var a = _mapper.Map<Author>(author);
                _db.Authors.Add(a);
                _db.SaveChanges();
                return Ok("Author Add sucessfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet]
        [Route("DTOGetBookAuthorName/{bookid}")]
        public ActionResult DTOGetBookAuthorName(int bookid)
        {
            try
            {
                var book = _db.Books
                    .Include(x => x.Author)
                    .Where(b => b.bookId == bookid).FirstOrDefault();

                var asd = _mapper.Map<BookDTO>(book);
                asd.AuthorName = book.Author.AuthorName;

                if (book == null)
                {
                    return NotFound("Book not found");
                }

                return Ok(asd);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("DTOAddAuthorInfo")]
        public ActionResult DTOAddAuthorInfo(AuthorInfo_DTO authorInfo)
        {
            try
            {
                var infoDTO = _mapper.Map<AuthorInfo>(authorInfo);
                _db.authorInfos.Add(infoDTO);
                _db.SaveChanges();
                return Ok("AuthorInfo Add successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/DTOgetAuthoInfoAndBooks")]
        public ActionResult DTOgetAuthoInfoAndBooks(string authorName)
        {
            try
            {
                var authorInfo = _db.Authors
                    .Include(a => a.AuthorInfo)
                    .Include(a => a.Books)
                    .Where(a => a.AuthorName == authorName)
                    .FirstOrDefault();


                var dto = _mapper.Map<AuhhorInfo_BookInfo>(authorInfo);
                //dto.Books = authorInfo.Books.Select(b => b.bookTitle).ToList();

                if (authorInfo == null)
                {
                    return NotFound("Book not found");
                }
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
