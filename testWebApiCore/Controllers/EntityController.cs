using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using testWebApiCore.DBContext;
using testWebApiCore.Models;
using System.Linq;

namespace testWebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntityController : ControllerBase
    {

        private readonly MyDbContext _db;

        public EntityController(MyDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        [Route("addEmploye")]
        public IActionResult add()
        {
            Employee emp1 = new Employee("attiqRehman", "Attiq@gmail", "012341234", "6th Road");
            Employee emp2 = new Employee("sajadRehman", "sajad@gmail", "54341234", "7th Road");
            Employee emp3 = new Employee("BongBong", "Bong@gmail", "3452341234", "8th Road");
            Employee emp4 = new Employee("UmarRehman", "Umar@gmail", "652341234", "9th Road");
            try
            {
                _db.AddRange(emp1, emp2, emp3, emp4);
                _db.SaveChanges();

                return Ok("Data added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to add data. Error: " + ex.Message);
            }
        }
        [HttpPost]
        [Route("addPeople")]
        public IActionResult addPeople()
        {
            Person person = new Person("sajad", 23, 01234123);
            Person person1 = new Person("John", 25, 0123456789);
            Person person2 = new Person("Alice", 30, 876543210);
            Person person3 = new Person("Michael", 40, 1234567890);
            Person person4 = new Person("Emma", 35, 0987654321);
            try
            {
                _db.AddRange(person1, person2, person3, person4, person);
                _db.SaveChanges();

                return Ok("Data added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to add data. Error: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("getPeopleData")]
        public IActionResult GetPeople()
        {

            try
            {
                var a = _db.People.ToList();
                //var ba = a.Where(c => c.Name.Contains("sajad", StringComparison.OrdinalIgnoreCase)).ToList();
                return Ok(a);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to Get data. Error: " + ex.Message);
            }
        }



    }
}
