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
    public class LocationApiController : ControllerBase
    {
        private readonly Traineedb16Context _db;
        public LocationApiController(Traineedb16Context db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(_db.Locations.ToList());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var x = _db.Locations.Find(id);
            return Ok(x);

        }
        [HttpPost]
        public async Task<IActionResult> Post(Location l)
        {
            _db.Locations.Add(l);
            _db.SaveChangesAsync();
            return Ok();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var x = _db.Locations.Find(id);
            _db.Remove(x);
            _db.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> update([FromBody] Location l)
        {
            _db.Entry(l).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
            return Ok();
        }
    }
}