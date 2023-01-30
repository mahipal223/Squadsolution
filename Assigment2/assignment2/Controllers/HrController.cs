using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using assignment2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace assignment2.Controllers
{
    [Route("[controller]")]
    public class HrController : Controller
    {

        private readonly Traineedb16Context _db;
        public HrController(Traineedb16Context db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }


    }
}