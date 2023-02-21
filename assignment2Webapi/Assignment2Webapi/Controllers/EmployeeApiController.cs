using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assignment2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2Webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeApiController : ControllerBase
    {
        private readonly Traineedb16Context _db;
        public EmployeeApiController(Traineedb16Context db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(_db.Employeees.ToList());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var x = _db.Employeees.Find(id);
            return Ok(x);

        }
        [HttpPost]
        public async Task<IActionResult> Post(Employeee emp)
        {
            _db.Employeees.Add(emp);
            _db.SaveChangesAsync();
            return Ok();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var x = _db.Employeees.Find(id);
            if (x != null)
            {
                x.IsDelete = true;
            }
            _db.SaveChanges();
            return Ok();
        }
        [HttpDelete("Isactive/{id}")]
        public async Task<IActionResult> isactive(int id)
        {
            var x = _db.Employeees.Find(id);
            if (x != null)
            {
                x.IsActive = false;
            }
            _db.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> update([FromBody] Employeee e)
        {
            _db.Entry(e).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
            return Ok();
        }
        // [HttpPatch("id")]
        // public async Task<IActionResult> softDelete(int id)
        // {
        //     var x = _db.Employeees.Find(id);
        //     if (x != null)
        //     {
        //         x.IsActive = true;
        //     }
        //     _db.SaveChanges();
        //     return Ok();
        // }
    }
}