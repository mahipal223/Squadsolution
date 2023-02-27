using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment4.Models;
using Assignment4.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assignment4Webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HaveKnowOfApiController : ControllerBase
    {
        private readonly traineedb16Context _db;
        public HaveKnowOfApiController(traineedb16Context db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (ModelState.IsValid)
            {
                var HaveKnowlist = _db.HaveKnowledge1s.Select(x => new SelectListItem()
                {
                    Text = x.HaveKnowName,
                    Value = x.HaveKnowId.ToString(),
                }).ToList();
                EmplyeeViewModel vm = new EmplyeeViewModel();
                vm.HaveKnowleadeof = HaveKnowlist;
                return Ok(vm);
            }

            return BadRequest("Your Data in Empty");
        }

    }
}