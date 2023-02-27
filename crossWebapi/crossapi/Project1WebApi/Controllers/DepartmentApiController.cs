using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project1Model;

namespace Project1WebApi.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    // [Route("api/[controller]/[action]")]
    public class DepartmentApiController : ControllerBase
    {
        private readonly Traineedb6Context _db;
        public DepartmentApiController(Traineedb6Context db)
        {
            _db=db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            
            return Ok(_db.Department1s.ToList());
        }
    }
}