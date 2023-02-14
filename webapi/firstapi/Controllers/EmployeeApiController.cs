using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using firstapi.data;
using Microsoft.AspNetCore.Mvc;

namespace firstapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeApiController : ControllerBase
    {
        private readonly traineedb16Context _db;
        public EmployeeApiController(traineedb16Context db)
        {
            _db = db;
        }
        [HttpGet]
        [Route("action")]
        public IActionResult Get()
        {
            if (ModelState.IsValid)
            {
                return Ok(_db.Employeees.ToList());

            }
            else
            {
                return BadRequest("Data not p");
            }

        }
        [HttpPost]
        [Route("Create")]
        public IActionResult post(Employeee e)
        {
            if (ModelState.IsValid)
            {

                _db.Employeees.Add(e);
                _db.SaveChanges();
                return Ok();
            }
            return BadRequest("Your Data Is Not Proper");
        }
    }
}