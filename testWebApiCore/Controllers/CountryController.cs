using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using testWebApiCore.DBContext;
using testWebApiCore.Interface;
using testWebApiCore.Models;

namespace testWebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly MyDbContext _db;
        private readonly IBook _book;
        public CountryController(MyDbContext db, IBook book)
        {
            _db = db;
            _book = book;
        }

        [HttpPost]
        [Route("AddCountries")]
        public ActionResult AddCountries(Country country)
        {
            try
            {
                _db.Countries.Add(country);
                _db.SaveChanges();
                return Ok("Add sucessfully");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("GetCountries")]
        public ActionResult GetCountries()
        {
            try
            {
                var cc = _book.getCountries();

                return Ok(cc);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }










    }
}
