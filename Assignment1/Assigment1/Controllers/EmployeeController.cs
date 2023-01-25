using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Assigment1.Data;
using Assigment1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Assigment1.Controllers
{

    public class EmployeeController : Controller
    {
        private readonly AppDbContext _db;

        public EmployeeController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {

            List<Department> dplist = new List<Department>();
            dplist = _db.Departments.ToList();
            ViewBag.list = dplist;
            return View();
        }

    }
}