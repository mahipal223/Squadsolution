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
    }
}