using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using testWebApiCore.DBContext;
using testWebApiCore.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult add(Employee employee)
        {

            try
            {
                _db.Employees.Add(employee);

                _db.SaveChanges();

                return Ok("Data added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to add data. Error: " + ex.Message);
            }
        }
        
        [HttpPost]
        [Route("addPErson")]
        public IActionResult addPErson(Person person)
        {

            try
            {
                _db.People.Add(person);
                _db.SaveChanges();
                return Ok("Data added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to add data. Error: " + ex.Message);
            }
        }

     

        //[HttpPost]
        //[Route("updateName")]
        //public IActionResult updateName(Person person)
        //{
        //    try
        //    {
        //        var existingPerson = _db.People.FirstOrDefault(p => p.Id == person.Id);
        //        if (existingPerson != null)
        //        {
        //            existingPerson.Name = person.Name;
        //            _db.SaveChanges();
        //            return Ok("Data added successfully.");
        //        }
        //        else
        //        {
        //            return NotFound("Person not found.");
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest("Failed to add data. Error: " + ex.Message);
        //    }
        //}

        //[HttpPost]
        //[Route("addPeopleParamter")]
        //public IActionResult addPeopleParamter(string name, int age, int phone)
        //{
        //    Person per = new Person();
        //    per.Age = age;
        //    per.Phone = phone;
        //    per.Name = name;
        //    try
        //    {
        //        _db.Add(per);
        //        _db.SaveChanges();

        //        return Ok("Data added successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest("Failed to add data. Error: " + ex.Message);
        //    }
        //}

        //[HttpGet]
        //[Route("getPeopleData")]
        //public IActionResult GetPeople()
        //{

        //    try
        //    {
        //        var a = _db.People.ToList();
        //        if (a.Count == 0)
        //        {
        //            return NotFound("Not data Found");
        //        }
        //        // get people data where name is sajad
        //        //var ba = a.Where(c => c.Name.Contains("sajad", StringComparison.OrdinalIgnoreCase)).ToList();
        //        return Ok(a);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest("Failed to Get data. Error: " + ex.Message);
        //    }
        //}
        //[HttpDelete]
        //[Route("DeletePeopleWithID")]
        //public IActionResult DeletePeople(int id)
        //{

        //    try
        //    {
        //        if (!int.TryParse(id.ToString(), out int personId) || id <= 0)
        //        {
        //            return BadRequest("Invalid number. Please provide a valid ID.");
        //        }
        //        var dlt = _db.People.FirstOrDefault(c => c.Id == id);
        //        if (dlt != null)
        //        {
        //            _db.Remove(dlt);
        //            _db.SaveChanges();
        //            return Ok($"Person with Id {personId} & Name  {dlt.Name} Successfully Delete ");

        //        }
        //        else
        //        {
        //            return NotFound("not found");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest("Failed to Get data. Error: " + ex.Message);
        //    }
        //}
        //[HttpDelete]
        //[Route("DropPeopleTAble")]
        //public IActionResult DropPeopleTAble()
        //{

        //    try
        //    {

        //        _db.Database.ExecuteSqlRaw("drop table People");
        //        return Ok("People table dropped successfully.");
        //    }


        //    catch (Exception ex)
        //    {
        //        return BadRequest("Failed to drop table " + ex.Message);
        //    }
        //}
        //[HttpDelete]
        //[Route("DeleteAllPeople")]
        //public IActionResult DeleteAllPeople()
        //{

        //    try
        //    {
        //        var dlt = _db.People.ToList();
        //        if (dlt != null)
        //        {
        //            _db.RemoveRange(dlt);
        //            _db.SaveChanges();
        //            return Ok("Delete All Data Successfully");

        //        }
        //        else
        //        {
        //            return NotFound("not found");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest("Failed to Get data. Error: " + ex.Message);
        //    }
        //}





    }
}
