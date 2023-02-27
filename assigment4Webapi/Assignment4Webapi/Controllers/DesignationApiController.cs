using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment4Webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DesignationApiController : ControllerBase
    {
        private readonly traineedb16Context _db;
        public DesignationApiController(traineedb16Context db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (ModelState.IsValid)
            {
                return Ok(_db.Designation1s.ToList());
            }

            return BadRequest("Your Data in Empty");
        }
    }
}