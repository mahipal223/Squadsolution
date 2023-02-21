using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assignmen1webapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace assignmen1webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentApiController : ControllerBase
    {
        private readonly Traineedb16Context _db;

        public DepartmentApiController(Traineedb16Context db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult GetAll()
        {

            return Ok(_db.Departments.ToList());
        }
        [HttpPost]
        public IActionResult Post(Department dpj)
        {
            _db.Departments.Add(dpj);
            _db.SaveChanges();
            return Ok("Data Inserted");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _db.Departments.Find(id);
            _db.Departments.Remove(result);
            _db.SaveChanges();
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            try
            {
                if (id != null)
                {
                    var x = _db.Departments.Find(id);
                    return Ok(x);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [HttpPut]
        public IActionResult update(Department dp)
        {
            _db.Entry(dp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
            return Ok();
        }
    }
}