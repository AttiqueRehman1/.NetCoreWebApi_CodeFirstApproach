using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using testWebApiCore.DBContext;
using testWebApiCore.DTO_Models;
using testWebApiCore.Interface;
using testWebApiCore.Models;


namespace testWebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBook _bookrepo;
        public BookController(IBook bookrepo)
        {
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
        public ActionResult AddAuthor(string name)
        {
            try
            {
                _bookrepo.AddAuthor(name);
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
                var getbooklsit = _bookrepo.GetBook();
                if (getbooklsit != null)
                    return Ok(getbooklsit);
                else
                    return NotFound("Not Found any list...");
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
                var a = _bookrepo.GetAllAuthor();
                if (a != null)
                    return Ok(a);
                else
                    return NotFound("No Author Found...");
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
                var a = _bookrepo.GetBookAuthorName(bookid);
                // var author = _db.Authors.Where(a => a.AuthorId == book.AuthorId).FirstOrDefault();
                if (a == null)
                {
                    return NotFound("Book not found");
                }
                return Ok(a);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /*
        [HttpGet]
        [Route("api/bookListbyId/{authorid}")]
        public ActionResult getAuthorBookListById(int authorid)
        {
            try
            {
                var a = _bookrepo.getAuthorBookListById(authorid);
                if (a == null)
                {
                    return NotFound("Book not found");
                }
                return Ok(a);
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
                var a = _bookrepo.getAuthorBookListByName(authorname);
                if (a == null)
                {
                    return NotFound("Book not found");
                }
                return Ok(a);
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

                var a = _bookrepo.getBookName(bkName);

                if (a == null)
                {
                    return NotFound("Book not found");
                }
                return Ok(a);
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
                _bookrepo.AddAuthorInfo(authorInfo);
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
                var a = _bookrepo.getAuthoInfoAndBooks(authorName);
                if (a == null)
                {
                    return NotFound("Book not found");
                }
                return Ok(a);
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
                _bookrepo.AddBookDTO(book);
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
                _bookrepo.AddAuthorDTO(author);
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
                var a = _bookrepo.DTOGetBookAuthorName(bookid);
                if (a == null)
                {
                    return NotFound("Book not found");
                }
                return Ok(a);
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
                _bookrepo.DTOAddAuthorInfo(authorInfo);
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
                var a = _bookrepo.DTOgetAuthoInfoAndBooks(authorName);
                //dto.Books = authorInfo.Books.Select(b => b.bookTitle).ToList();

                if (a == null)
                {
                    return NotFound("Book not found");
                }
                return Ok(a);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        */

    }
}
