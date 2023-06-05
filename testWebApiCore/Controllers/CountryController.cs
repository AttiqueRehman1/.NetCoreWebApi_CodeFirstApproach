using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using testWebApiCore.DBContext;
using testWebApiCore.Models;

namespace testWebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly MyDbContext _db;
        public CountryController(MyDbContext db)
        {
            _db = db;
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










    }
}
