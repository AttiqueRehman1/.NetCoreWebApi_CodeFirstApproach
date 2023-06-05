using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testWebApiCore.DBContext;
using testWebApiCore.Models;

namespace testWebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly MyDbContext _db;
        public BookController(MyDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        [Route("AddBook")]
        public ActionResult AddBook(Book book)
        {
            try
            {
                _db.Books.Add(book);
                _db.SaveChanges();
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

                return Ok(_db.Books.ToList());
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

                return Ok(_db.Authors.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("api/Books/{bookid}")]
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
                    .Include(x => x.Books.Where(x=>x.bookId>7))
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

    }
}
